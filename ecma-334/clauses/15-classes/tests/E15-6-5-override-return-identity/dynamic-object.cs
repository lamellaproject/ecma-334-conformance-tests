/*
Rules: E15-6-5-override-return-identity
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public override dynamic Read() { return new Token(); }
Into: public override int Read() { return 0; }
*/
using System;
class Token { }
class Root { public virtual object Read() { return null; } }
class Leaf : Root { public override dynamic Read() { return new Token(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Check(value.Read() is Token, "dynamic-object-identity-conversion-permits-override-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
