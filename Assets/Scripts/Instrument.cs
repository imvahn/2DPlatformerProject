using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    public static Instrument piano;
    public static Instrument drums;
    public static Instrument flute;
    public static Instrument guitar;


    public Instrument() { }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public static Instrument operator ==(Instrument a, Instrument b)
    {
        return a == b;
    }

    public static Instrument operator !=(Instrument a, Instrument b)
    {
        return (a != b);
    }
}
