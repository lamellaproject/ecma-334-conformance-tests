/*
Rules: E9-2-1-variable-categories
Authority: ECMA-334 7th ed 9.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: reference = value + input;
Into: reference = value - input;
*/
using System;
class Program
{
    static int checks, failures, shared;
    int member;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Combine(int value, in int input, ref int reference, out int output)
    {
        reference = value + input;
        output = reference + 1;
    }
    static void Main()
    {
        Program instance = new Program();
        instance.member = 6;
        int[] elements = new int[] { 4 };
        int result;
        Combine(instance.member, in elements[0], ref shared, out result);
        Check(shared == 10, "static-instance-array-value-input-reference");
        Check(result == 11, "output-local");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
