/*
Rules: E22-2-4-parameter-array; E22-3-argument-array
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int[] { 7, 12 }
Into: new int[] { 8, 12 }
*/
using System;
class MarkAttribute : Attribute { public int[] Values; public MarkAttribute(int[] values) { Values = values; } }
[Mark(new int[] { 7, 12 })] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] a = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Values;
        Check(a.Length == 2, "array-length");
        Check(a[0] == 7 && a[1] == 12, "array-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
