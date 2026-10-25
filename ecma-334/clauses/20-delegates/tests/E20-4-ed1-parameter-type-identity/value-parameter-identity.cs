/*
Rules: E20-4-ed1-parameter-type-identity
Authority: ECMA-334 1st ed 22.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E20-4-ed1-parameter-type-identity/value-parameter-identity-witness.cs.part
Mutate: delegate void Receiver(Leaf value);
Into: delegate void Receiver(Root value);
*/
// ECMA-334 1st ed 14.5.10.3, p. 150 (PDF p. 164), line 12 applies the 1st edition's 22.1
// type identity. Only the target declaration's corresponding parameter type is repaired.
using System;
class Root { }
class Leaf : Root { }
delegate void Source(Root value);
delegate void Receiver(Leaf value);
class Entry
{
    static void Capture(Root value) { }
    public static int Main()
    {
        Source source = new Source(Capture);
        Receiver receiver = new Receiver(source);
        receiver(new Leaf());
        Console.WriteLine("OK 0");
        return 0;
    }
}
