/*
Rules: E17-1-reference-type; E17-2-1-instance-reference; E17-3-instance-type
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int[] second = first
Into: int[] second = new int[1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] first = new int[1];
        int[] second = first;
        second[0] = 37;
        Check(first == second, "reference-equality");
        Check(first[0] == 37, "shared-storage");
        Array baseValue = first;
        Check(baseValue is int[], "instance-is-array-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
