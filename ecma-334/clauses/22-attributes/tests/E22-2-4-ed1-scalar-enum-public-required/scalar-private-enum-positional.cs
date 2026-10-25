/*
Rules: E22-2-4-ed1-scalar-enum-public-required
Authority: ECMA-334 1st ed 24.1.3
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E22-2-4-ed1-scalar-enum-public-required-scalar-private-enum-positional.cs.part
Mutate: private enum Pulse
Into: public enum Pulse
*/
// ECMA-334 1st ed 24.1.3, p. 311 (PDF p. 325), lines 11-12. Refuse use of an enum as a
// positional or named attribute parameter when the enum's declared accessibility is not
// public.

public class Enclosure
{
    private enum Pulse { Quiet = 0 }

    private class SealAttribute : System.Attribute
    {
        public SealAttribute(Pulse token) { }
    }

    [Seal(0)]
    private class Decorated { }

    public static void Exercise() { }
}

class EnumEntry
{
    public static int Main() { return 0; }
}
