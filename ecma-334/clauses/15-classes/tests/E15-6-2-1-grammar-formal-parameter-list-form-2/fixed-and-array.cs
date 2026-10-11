/*
Rules: E15-6-2-1-grammar-formal-parameter-list-form-2
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int offset, params int[] values
Into: params int[] values, int offset
*/
using System;
class Program
{
    static int Sum(int offset, params int[] values)
    {
        int result = offset;
        for (int index = 0; index < values.Length; index++) result += values[index];
        return result;
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Sum(11) == 11, "fixed-argument-and-omitted-params");
        Check(Sum(11, 2, 3) == 16, "fixed-argument-and-expanded-params");
        Check(Sum(11, new int[] { 5, 7 }) == 23, "fixed-argument-and-normal-params");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
