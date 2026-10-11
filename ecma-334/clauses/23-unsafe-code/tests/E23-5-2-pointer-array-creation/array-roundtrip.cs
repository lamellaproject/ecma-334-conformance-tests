/*
Rules: E23-5-2-pointer-array-creation; E23-5-2-array-to-system-array; E23-5-2-system-array-to-pointer-array
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int*[] items = new int*[2];
Into: int*[] items = new int*[3];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 29;
        // 23.5.2, p. 554 says "usafe", an evident typo; this test follows the intent, "unsafe".
        int*[] items = new int*[2];
        items[0] = &value;
        Check(items.Length == 2 && items[1] == null, "pointer-array-creation");
        Array view = items;
        Check((object)view == (object)items, "array-reference-conversion");
        int*[] restored = (int*[])view;
        Check(restored == items && *restored[0] == 29, "array-explicit-roundtrip");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
