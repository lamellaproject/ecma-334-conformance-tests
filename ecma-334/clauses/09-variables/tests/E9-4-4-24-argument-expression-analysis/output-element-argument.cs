/*
Rules: E9-4-4-24-argument-expression-analysis; E9-4-4-24-successive-argument-entry
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: out elements[index = 1]
Into: out elements[1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Fill(out int value, int which) { value = which + 70; }
    static void Main()
    {
        int index;
        int[] elements = new int[2];
        Fill(out elements[index = 1], index);
        Check(index == 1, "out-modifier-keeps-index-expression-assignment");
        Check(elements[0] == 0 && elements[1] == 71, "next-argument-sees-index-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
