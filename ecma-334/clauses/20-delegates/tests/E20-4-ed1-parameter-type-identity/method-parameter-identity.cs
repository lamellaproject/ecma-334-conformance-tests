/*
Rules: E20-4-ed1-parameter-type-identity
Authority: ECMA-334 1st ed 22.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E20-4-ed1-parameter-type-identity/method-parameter-identity-witness.cs.part
Mutate: static void Capture(Root value)
Into: static void Capture(Leaf value)
*/
// ECMA-334 1st ed 22.1, p. 301 (PDF p. 315), lines 35-38 requires the same parameter
// types. The 1st edition's 14.5.10.3 applies compatibility to explicit method-group
// creation.
using System;
class Root { }
class Leaf : Root { }
delegate void Receiver(Leaf value);
class Entry
{
    static void Capture(Root value) { }
    public static int Main()
    {
        Receiver receiver = new Receiver(Capture);
        receiver(new Leaf());
        Console.WriteLine("OK 0");
        return 0;
    }
}
