/*
Rules: E22-5-3-2-ed1-class-conditional-method
Authority: ECMA-334 1st ed 24.4.2
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E22-5-3-2-ed1-class-conditional-method/static-method.cs.part
Mutate: public struct Envelope
Into: public class Envelope
*/
#define LAMELLA_PULSE
// ECMA-334 1st ed 24.4.2, p. 316 (PDF p. 330), line 29. Refuse a Conditional method whose
// declaration is in a struct rather than a class.

public struct Envelope
{
    [System.Diagnostics.Conditional("LAMELLA_PULSE")]
    public static void Signal()
    {
    }
}

class Exercise
{
    static void Main()
    {
        Envelope.Signal();
    }
}
