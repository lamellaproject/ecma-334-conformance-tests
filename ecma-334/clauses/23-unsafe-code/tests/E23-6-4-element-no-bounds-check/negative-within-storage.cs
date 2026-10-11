/*
Rules: E23-6-4-element-no-bounds-check
Authority: ECMA-334 7th ed 23.6.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = middle[-1];
Into: int result = middle[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[3];
        storage[0] = 5; storage[1] = 23; storage[2] = 41;
        int* middle = storage + 2;
        // The negative index stays inside the allocation; no undefined out-of-bounds access is used.
        int result = middle[-1];
        Check(result == 23, "negative-pointer-index");
        middle[-2] = 17;
        Check(storage[0] == 17, "negative-pointer-index-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
