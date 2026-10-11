/*
Rules: E6-2-5-namespace-type-exemption
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Crate<int> item
Into: Crate<string> item
*/
using System;
class Crate<T> { public int Number = 27; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate<int> item = new Crate<int>();
        Check(item.Number == 27, "type-name-keeps-generic-list-before-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
