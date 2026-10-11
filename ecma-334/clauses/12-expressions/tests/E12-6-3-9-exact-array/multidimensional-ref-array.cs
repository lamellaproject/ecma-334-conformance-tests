/*
Rules: E12-6-3-9-exact-array
Authority: ECMA-334 7th ed 12.6.3.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Identity(ref values)
Into: Identity(ref scalar)
*/
using System;
class Program
{
    static int checks, failures;
    static T Identity<T>(ref T[,] array) { return array[0, 0]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] values = { { 14 } };
        int scalar = 14;
        int result = Identity(ref values);
        Check(result == 14, "exact-array-inference-recurses-through-equal-rank");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
