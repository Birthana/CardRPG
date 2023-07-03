using System;
using UnityEngine;

[Serializable]
public class Effect
{
    [HideInInspector][SerializeReference]private Target target_;

    public Effect()
    {
    }

    public Effect(Target target) 
    {
        target_ = target;
    }

    public Target GetTarget() 
    {
        return target_;
    }

    public virtual void Cast() { }

    public virtual string GetDescription() { return $""; }
}