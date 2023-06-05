using System;
using System.Collections;

[Serializable]
public class Target
{
    public virtual bool IsCanceled() { return false; }

    public virtual Enemy GetTarget() { return null; }

    public virtual IEnumerator Targeting() { return null; }

    public virtual string GetDesciption() { return $"DEFAULT"; }
}
