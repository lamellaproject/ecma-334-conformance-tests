/*
Rules: E12-8-17-type-object; E12-8-17-type-form; E12-8-17-unique-type-object; E12-8-17-ambiguous-name-interpretation
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Type first = typeof(Signed);
Into: Type first = typeof(uint);
*/
using System;
using Signed = System.Int32;
class Marker { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type first = typeof(Signed);
        Check(first == typeof(int), "typeof-indicated-aliased-type");
        Check(object.ReferenceEquals(first, typeof(System.Int32)), "one-type-object-per-type");
        Check(typeof(Marker) == new Marker().GetType(), "simple-name-operand-is-type-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
