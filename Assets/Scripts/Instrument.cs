using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    private string instrumentName;

    public static readonly Instrument piano = new Instrument("piano");
    public static readonly Instrument drums = new Instrument("drums");
    public static readonly Instrument flute = new Instrument("flute");
    public static readonly Instrument guitar = new Instrument("guitar");

    private Instrument(string name)
    {
        instrumentName = name;
    }

    public override string ToString()
    {
        return instrumentName;
    }

    public static bool operator ==(Instrument instrument, string instrumentString)
    {
        if (ReferenceEquals(instrument, null) && instrumentString == null)
            return true;

        if (ReferenceEquals(instrument, null) || instrumentString == null)
            return false;

        return instrument.instrumentName == instrumentString;
    }

    public static bool operator !=(Instrument instrument, string instrumentString)
    {
        return !(instrument == instrumentString);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Instrument other = (Instrument)obj;
        return instrumentName == other.instrumentName;
    }

    public override int GetHashCode()
    {
        return instrumentName.GetHashCode();
    }
}

