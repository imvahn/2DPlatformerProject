using UnityEngine;

public class Instrument : MonoBehaviour
{
    public static Instrument Piano { get; private set; }
    public static Instrument Drums { get; private set; }
    public static Instrument Flute { get; private set; }
    public static Instrument Guitar { get; private set; }

    private string instrumentString;

    private void Awake()
    {
        // Initialize the instruments with appropriate values
        Piano = new Instrument("Piano");
        Drums = new Instrument("Drums");
        Flute = new Instrument("Flute");
        Guitar = new Instrument("Guitar");
    }

    private Instrument(string s)
    {
        instrumentString = s;
    }
    
    public override string ToString()
    {
        return instrumentString;
    }

    public static bool operator ==(Instrument instrument, string instrumentString)
    {
        if (ReferenceEquals(instrument, null) && instrumentString == null)
            return true;

        if (ReferenceEquals(instrument, null) || instrumentString == null)
            return false;

        return instrument.instrumentString == instrumentString;
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
        return instrumentString == other.instrumentString;
    }

    public override int GetHashCode()
    {
        return instrumentString.GetHashCode();
    }
}
