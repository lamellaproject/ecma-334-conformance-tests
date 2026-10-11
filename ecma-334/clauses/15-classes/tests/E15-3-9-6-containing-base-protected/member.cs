/*
Rules: E15-3-9-6-containing-base-protected; E15-3-9-6-containing-accessibility
Authority: ECMA-334 7th ed 15.3.9.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected static int Code
Into: private static int Code
*/
using System;
class Root { protected static int Code = 367; }
class Host : Root { public class Node { public int Read() { return Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Host.Node().Read() == 367, "nested-type-accesses-containing-base-protected-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
