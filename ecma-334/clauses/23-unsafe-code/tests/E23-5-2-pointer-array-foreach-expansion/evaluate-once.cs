/*
Rules: E23-5-2-pointer-array-foreach-expansion; E23-5-2-foreach-array-evaluate-once; E23-5-2-foreach-body-execution
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: foreach (int* current in Observe(items))
Into: foreach (int* current in items)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static int*[] Observe(int*[] value) { calls++; return value; }
    static void Main()
    {
        int first = 7, second = 19;
        int*[] items = { &first, &second };
        int count = 0, sum = 0;
        foreach (int* current in Observe(items))
        {
            count++;
            sum += *current;
            items = null;
        }
        Check(calls == 1, "array-expression-evaluated-once");
        Check(count == 2, "stored-array-reference-used");
        Check(sum == 26, "body-after-iteration-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
