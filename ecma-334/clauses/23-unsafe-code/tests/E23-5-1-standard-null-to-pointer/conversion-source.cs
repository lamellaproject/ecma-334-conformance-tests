/*
Rules: E23-5-1-standard-null-to-pointer
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Holder box = null;
Into: Holder box = &value;
*/
using System;
unsafe struct Holder
{
    public bool IsNull;
    public static implicit operator Holder(int* address)
    {
        return new Holder { IsNull = address == null };
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 53;
        Holder box = null;
        Check(box.IsNull, "standard-null-source-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
