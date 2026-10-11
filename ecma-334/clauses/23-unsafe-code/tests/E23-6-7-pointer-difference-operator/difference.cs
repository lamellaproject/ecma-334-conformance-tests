/*
Rules: E23-6-7-pointer-difference-operator; E23-6-7-pointer-difference-value; E23-6-7-pointer-difference-type
Authority: ECMA-334 7th ed 23.6.7
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: long difference = last - first;
Into: long difference = first - last;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Classify(int value) { return 1; }
    static int Classify(long value) { return 2; }
    static unsafe void Main()
    {
        int* storage = stackalloc int[5];
        int* first = storage + 1;
        int* last = storage + 4;
        long difference = last - first;
        Check(difference == 3, "positive-pointer-difference");
        Check(first - last == -3, "negative-pointer-difference");
        Check((byte*)last - (byte*)first == difference * sizeof(int), "pointer-difference-scale");
        Check(Classify(last - first) == 2, "pointer-difference-is-long");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
