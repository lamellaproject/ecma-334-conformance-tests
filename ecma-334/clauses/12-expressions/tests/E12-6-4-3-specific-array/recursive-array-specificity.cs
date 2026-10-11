/*
Rules: E12-6-4-3-specific-array
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Choice<int>().Pick(new int[1, 1])
Into: new Choice<long>().Pick(new long[1, 1])
*/
using System;
class Choice<T>
{
    public int Pick(T[,] value) { return 1; }
    public int Pick(int[,] value) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Choice<int>().Pick(new int[1, 1]) == 2, "same-rank-array-specificity-recurses-into-element-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
