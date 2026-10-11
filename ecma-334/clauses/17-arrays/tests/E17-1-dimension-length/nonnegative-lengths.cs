/*
Rules: E17-1-dimension-length; E17-1-lengths-on-creation; E17-3-creation-expression
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int[ReadLength()]
Into: new int[1]
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int ReadLength() { calls++; return 3; }
    static void Main()
    {
        int[] values = new int[ReadLength()];
        Check(calls == 1 && values.Length == 3, "runtime-length");
        Check(new int[0].Length == 0, "zero-permitted");
        bool rejected = false;
        int negative = -1;
        try { int[] invalid = new int[negative]; }
        catch (OverflowException) { rejected = true; }
        catch (Exception) { }
        Check(rejected, "negative-cannot-be-length");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
