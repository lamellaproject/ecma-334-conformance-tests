/*
Rules: E12-6-4-3-specific-type-parameter; E12-6-4-3-prefer-specific; E12-6-4-3-specific-sequence
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Choice<int>().Pick(7)
Into: new Choice<long>().Pick(7L)
*/
using System;
class Choice<T>
{
    public int Pick(T value) { return 1; }
    public int Pick(int value) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Choice<int>().Pick(7) == 2, "concrete-uninstantiated-parameter-more-specific-than-type-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
