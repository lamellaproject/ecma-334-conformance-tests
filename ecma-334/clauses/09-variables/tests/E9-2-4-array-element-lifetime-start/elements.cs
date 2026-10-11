/*
Rules: E9-2-4-array-element-lifetime-start; E9-2-4-array-element-initial-value; E9-2-4-array-element-initially-assigned; E9-3-array-element-default-initialization; E9-4-2-array-element-assigned
Authority: ECMA-334 7th ed 9.2.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int[] elements = new int[3];
Into: int[] elements = new int[] { 8, 8, 8 };
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] elements = new int[3];
        Check(elements[0] == 0 && elements[1] == 0 && elements[2] == 0, "all-elements-exist-initially-assigned");
        elements[1] = 55;
        Check(elements[0] == 0 && elements[1] == 55 && elements[2] == 0, "distinct-element-storages");
        int[] alias = elements;
        elements = null;
        Check(alias[1] == 55, "storage-survives-through-array-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
