/*
Rules: E20-4-ed1-return-type-identity
Authority: ECMA-334 1st ed 22.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E20-4-ed1-return-type-identity/method-return-identity-witness.cs.part
Mutate: static Leaf Build()
Into: static Root Build()
*/
// ECMA-334 1st ed 22.1, p. 301 (PDF p. 315), line 39 requires identical return types. The
// 7th edition's 20.4 permits an implicit reference return conversion.
using System;
class Root { }
class Leaf : Root { }
delegate Root Receiver();
class Entry
{
    static Leaf Build() { return new Leaf(); }
    public static int Main()
    {
        Receiver receiver = new Receiver(Build);
        receiver();
        Console.WriteLine("OK 0");
        return 0;
    }
}
