/*
Rules: E23-9-var-pointer-stackalloc; E23-9-stackalloc-pointer-type
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: var memory = stackalloc int[2] { 13, 31 };
Into: void* memory = stackalloc int[2] { 13, 31 };
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe int Classify(int* value) { return 1; }
    static unsafe int Classify(void* value) { return 2; }
    static unsafe void Main()
    {
        var memory = stackalloc int[2] { 13, 31 };
        Check(Classify(memory) == 1, "var-infers-exact-element-pointer-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
