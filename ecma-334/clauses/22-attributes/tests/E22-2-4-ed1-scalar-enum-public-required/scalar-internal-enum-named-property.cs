/*
Rules: E22-2-4-ed1-scalar-enum-public-required
Authority: ECMA-334 1st ed 24.1.3
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E22-2-4-ed1-scalar-enum-public-required-scalar-internal-enum-named-property.cs.part
Mutate: internal enum Pulse
Into: public enum Pulse
*/
// ECMA-334 1st ed 24.1.3, p. 311 (PDF p. 325), lines 11-12. Refuse use of an enum as a
// positional or named attribute parameter when the enum's declared accessibility is not
// public.

internal enum Pulse { Quiet = 0 }

public class Enclosure
{
    private class SealAttribute : System.Attribute
    {
        public SealAttribute() { }
        private Pulse chosen;
        public Pulse Pick
        {
            get { return chosen; }
            set { chosen = value; }
        }
    }

    [Seal(Pick = 0)]
    private class Decorated { }

    public static void Exercise() { }
}

class EnumEntry
{
    public static int Main() { return 0; }
}
