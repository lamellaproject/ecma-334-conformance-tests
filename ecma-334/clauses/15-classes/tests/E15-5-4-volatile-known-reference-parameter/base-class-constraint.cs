/*
Rules: E15-5-4-volatile-known-reference-parameter
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile T Value;
Into: public volatile T Other;
*/
using System;
class Basis { }
class Leaf : Basis { }
class Holder<T> where T : Basis { public volatile T Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder<Leaf> value = new Holder<Leaf>();
        Leaf input = new Leaf();
        value.Value = input;
        Check(value.Value == input, "volatile-base-class-constrained-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
