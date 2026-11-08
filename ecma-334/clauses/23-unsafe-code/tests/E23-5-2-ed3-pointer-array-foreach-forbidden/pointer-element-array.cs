/*
Rules: E23-5-2-ed3-pointer-array-foreach-forbidden
Authority: ECMA-334 3rd ed 15.8.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E23-5-2-ed3-pointer-array-foreach-forbidden/pointer-element-array.cs.part
Mutate: foreach (int* item in items) count++;
Into: for (int index = 0; index < items.Length; index++) count++;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static unsafe int Main()
    {
        int first = 41, second = 43;
        int*[] items = new int*[] { &first, &second };
        int count = 0;
        foreach (int* item in items) count++;
        Check(count == 2, "pointer-array-traversal-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
