/*
Rules: E23-5-1-standard-pointer-to-void
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Holder box = pointer;
Into: Holder box = (int*)null;
*/
using System;
unsafe struct Holder
{
    public void* Address;
    public static implicit operator Holder(void* address)
    {
        return new Holder { Address = address };
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 53;
        int* pointer = &value;
        Holder box = pointer;
        Check(box.Address == pointer, "standard-pointer-source-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
