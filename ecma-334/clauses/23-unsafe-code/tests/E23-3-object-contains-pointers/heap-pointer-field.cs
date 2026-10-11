/*
Rules: E23-3-object-contains-pointers
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: holder.Pointer = &value;
Into: holder.Pointer = null;
*/
using System;
unsafe class Holder { public int* Pointer; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            Holder holder = new Holder();
            int value = 71;
            holder.Pointer = &value;
            Check(holder.Pointer != null && *holder.Pointer == 71, "object-contains-pointer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
