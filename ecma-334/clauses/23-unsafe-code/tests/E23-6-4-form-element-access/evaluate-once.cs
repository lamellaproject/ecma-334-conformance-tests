/*
Rules: E23-6-4-form-element-access; E23-6-4-element-indirection-equivalence
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Observe(pointer)[Index()] = 43;
Into: Observe(pointer)[0] = 43;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string trace = "";
    static int* Observe(int* value) { trace += "p"; return value; }
    static long Index() { trace += "i"; return 1; }
    static void Main()
    {
        int* pointer = stackalloc int[2];
        pointer[0] = 7; pointer[1] = 19;
        Observe(pointer)[Index()] = 43;
        Check(trace == "pi", "pointer-then-index-once");
        Check(pointer[0] == 7 && pointer[1] == 43, "element-referent-write");
        Check(*(pointer + 1) == 43, "element-indirection-equivalence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
