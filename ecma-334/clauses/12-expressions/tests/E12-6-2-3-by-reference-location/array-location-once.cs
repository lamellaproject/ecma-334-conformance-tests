/*
Rules: E12-6-2-3-by-reference-location
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref values[index++]
Into: ref values[++index]
*/
using System;
class Program
{
    static int checks, failures;
    static void Update(ref int target, int amount) { target += amount; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 11, 17 }; int index = 0; Update(ref values[index++], 7);
        Check(values[0] == 18 && values[1] == 17, "evaluated-reference-storage-location");
        Check(index == 1, "reference-expression-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
