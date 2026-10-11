/*
Rules: E23-7-form-declarator-list; E23-7-declares-local; E23-7-initializes-local; E23-7-scope-later-initializers; E23-7-scope-embedded-statement
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: second = Observe(first, other)
Into: second = Observe(first, items)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static int Classify(int* value) { return 1; }
    static int Classify(void* value) { return 2; }
    static int[] Observe(int* first, int[] result)
    {
        calls++;
        Check(*first == 7, "earlier-local-in-later-initializer");
        return result;
    }
    static void Main()
    {
        int[] items = { 7 }, other = { 23 };
        fixed (int* first = items, second = Observe(first, other))
        {
            Check(*first == 7, "first-fixed-initializer");
            Check(*second == 23, "second-fixed-initializer");
            Check(calls == 1, "later-initializer-once");
            Check(Classify(first) == 1, "declared-fixed-pointer-type");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
