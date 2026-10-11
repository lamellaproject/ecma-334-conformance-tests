/*
Rules: E23-3-pointer-array-element; E23-3-non-array-type
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: a[0] = &value;
Into: a[0] = null;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 67;
            int*[] a = new int*[2];
            Check(a[0] == null && a[1] == null, "pointer-array-default-elements");
            a[0] = &value;
            Check(a[0] != null && *a[0] == 67, "pointer-array-element");
            Check(!typeof(int*).IsArray && typeof(int*[]).IsArray, "non-array-pointer-type");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
