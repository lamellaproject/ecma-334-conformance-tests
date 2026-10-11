/*
Rules: E23-5-1-implicit-null-to-pointer
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int* pointer = null;
Into: int* pointer = &value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 31;
        int* pointer = null;
        void* untyped = null;
        int** nested = null;
        Check(pointer == null, "null-int-pointer");
        Check(untyped == null, "null-void-pointer");
        Check(nested == null, "null-nested-pointer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
