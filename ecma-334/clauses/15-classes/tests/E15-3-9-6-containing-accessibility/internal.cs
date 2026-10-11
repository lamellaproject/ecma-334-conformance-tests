/*
Rules: E15-3-9-6-containing-accessibility
Authority: ECMA-334 7th ed 15.3.9.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal static int Code
Into: private static int Code
*/
using System;
class Surface { internal static int Code = 373; }
class Host { public class Node { public int Read() { return Surface.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Host.Node().Read() == 373, "nested-type-has-containing-assembly-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
