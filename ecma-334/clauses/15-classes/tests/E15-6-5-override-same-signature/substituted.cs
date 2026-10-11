/*
Rules: E15-6-5-override-same-signature; E15-6-5-override-classification; E15-6-5-override-accessible-public
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public override int Read(int value)
Into: public new int Read(int value)
*/
using System;
class Root<T> { public virtual T Read(T value) { return value; } }
class Leaf : Root<int> { public override int Read(int value) { return value + 6; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root<int> value = new Leaf();
        Check(value.Read(23) == 29, "type-substitution-matches-override-parameter-and-return-types");
        Check(((Leaf)value).Read(31) == 37, "public-override-replaces-inherited-generic-base-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
