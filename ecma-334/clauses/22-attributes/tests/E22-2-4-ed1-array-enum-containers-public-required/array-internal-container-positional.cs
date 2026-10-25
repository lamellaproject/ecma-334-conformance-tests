/*
Rules: E22-2-4-ed1-array-enum-containers-public-required
Authority: ECMA-334 1st ed 24.1.3
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E22-2-4-ed1-array-enum-containers-public-required-array-internal-container-positional.cs.part
Mutate: internal class Region
Into: public class Region
*/
// ECMA-334 1st ed 24.1.3, p. 311 (PDF p. 325), line 13. Refuse use of a one-dimensional
// enum array as a positional or named attribute parameter when a containing type of the
// enum has non-public declared accessibility.

internal class Region
{
    public enum Pulse { Quiet = 0 }
}

public class Enclosure
{
    private class SealAttribute : System.Attribute
    {
        public SealAttribute(Region.Pulse[] token) { }
    }

    [Seal(new Region.Pulse[] { })]
    private class Decorated { }

    public static void Exercise() { }
}

class EnumEntry
{
    public static int Main() { return 0; }
}
