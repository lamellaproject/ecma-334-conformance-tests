/*
Rules: E7-1-ordinary-call-accessible-type; E7-1-type-accessibility-modifiers
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: private class Hidden
Into: public class Hidden
*/
class Envelope
{
    private class Hidden { public static void Read() { } }
}
class Program
{
    static void Main() { Envelope.Hidden.Read(); }
}
