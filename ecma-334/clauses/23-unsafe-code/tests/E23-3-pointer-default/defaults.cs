/*
Rules: E23-3-pointer-default
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int* p = default(int*);
Into: int* p = (int*)1;
*/
using System;
unsafe struct Item { public int* Pointer; }
unsafe class Holder { public void* Pointer; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int* p = default(int*);
            void* q = default(void*);
            Item item = default(Item);
            Holder holder = new Holder();
            Check(p == null && q == null, "explicit-default-pointers");
            Check(item.Pointer == null, "struct-field-default");
            Check(holder.Pointer == null, "class-field-default");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
