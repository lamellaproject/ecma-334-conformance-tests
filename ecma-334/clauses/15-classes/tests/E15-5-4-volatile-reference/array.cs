/*
Rules: E15-5-4-volatile-reference
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile int[] Value;
Into: public volatile int[] Other;
*/
using System;
class Holder { public volatile int[] Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        int[] input = new int[1];
        value.Value = input;
        Check(value.Value == input, "volatile-array-reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
