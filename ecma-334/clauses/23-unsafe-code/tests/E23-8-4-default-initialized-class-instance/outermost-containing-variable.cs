/*
Rules: E23-8-4-default-initialized-class-instance
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Owner owner = new Owner();
Into: Owner owner = Filled();
*/
using System;
unsafe struct Data { public fixed ushort Values[3]; }
struct Wrapper { public Data Data; }
class Owner { public Wrapper Root; }

unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Owner Filled() { Owner value = new Owner(); fixed (ushort* pointer = value.Root.Data.Values) { pointer[1] = 1; } return value; }
    static void Main()
    {
        Owner owner = new Owner();
        fixed (ushort* pointer = owner.Root.Data.Values)
            Check(pointer[0] == 0 && pointer[1] == 0 && pointer[2] == 0, "nested-instance-buffer-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
