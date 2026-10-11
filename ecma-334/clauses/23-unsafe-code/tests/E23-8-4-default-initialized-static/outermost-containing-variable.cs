/*
Rules: E23-8-4-default-initialized-static
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Wrapper root;
Into: static Wrapper root = Filled();
*/
using System;
unsafe struct Data { public fixed ushort Values[3]; }
struct Wrapper { public Data Data; }

unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Wrapper root;
    static Wrapper Filled() { Wrapper value = new Wrapper(); value.Data.Values[1] = 1; return value; }
    static void Main()
    {
        Check(root.Data.Values[0] == 0 && root.Data.Values[1] == 0 && root.Data.Values[2] == 0, "nested-static-buffer-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
