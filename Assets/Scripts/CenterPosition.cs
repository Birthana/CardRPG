using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPosition
{
    public int numberOfIndexes;
    public float spacing;

    public CenterPosition(int numberOfIndexes, float spacing)
    {
        this.numberOfIndexes = numberOfIndexes;
        this.spacing = spacing;
    }

    public Vector3 CalcPositionAt(int cardIndex)
    {
        float positionOffset = CalcPositionOffsetAt(cardIndex);
        return new Vector3(CalcX(positionOffset), CalcY(), CalcZ(cardIndex));
    }

    float CalcPositionOffsetAt(int index) { return index - ((float)numberOfIndexes - 1) / 2; }

    float CalcX(float positionOffset) { return Mathf.Sin(positionOffset * Mathf.Deg2Rad) * spacing * 10; }

    float CalcY() { return 0; }

    float CalcZ(int index) { return numberOfIndexes - index; }

}
