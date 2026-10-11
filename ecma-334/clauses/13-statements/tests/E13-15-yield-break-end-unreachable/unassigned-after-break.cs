/*
Rules: E13-15-yield-break-end-unreachable
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: yield break;
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Use(int value) { }
    static IEnumerator<int> Items() { yield break; int unassigned; Use(unassigned); }
    static void Main()
    {
        IEnumerator<int> cursor = Items();
        Check(!cursor.MoveNext(), "yield-break-unreachable-read-does-not-execute");
        cursor.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
