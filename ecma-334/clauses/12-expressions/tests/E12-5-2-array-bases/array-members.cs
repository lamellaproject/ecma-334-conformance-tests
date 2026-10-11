/*
Rules: E12-5-2-array-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int[] values = new int[3];
Into: int[] values = new int[4];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[3]; Array array = values; object boxed = array;
        Check(values.Length == 3 && array.Length == 3, "array-base-length-member");
        Check(values.Equals(boxed), "array-object-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
