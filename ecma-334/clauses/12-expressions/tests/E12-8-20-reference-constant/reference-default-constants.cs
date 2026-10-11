/*
Rules: E12-8-20-reference-constant
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const Marker value = default(Marker);
Into: const Marker value = new Marker();
*/
using System;
class Marker { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const Marker value = default(Marker);
        const object root = default(object);
        const string text = default(string);
        Check(value == null && root == null, "class-and-object-default-constants");
        Check(text == null, "string-default-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
