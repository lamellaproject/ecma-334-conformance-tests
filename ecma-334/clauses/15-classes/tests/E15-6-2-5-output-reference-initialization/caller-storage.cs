/*
Rules: E15-6-2-5-output-reference-initialization; E15-6-2-5-output-parameter-classification; E15-6-2-5-output-argument-unassigned-allowed; E15-6-2-5-output-argument-assigned-after
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Write(out first, out second, true)
Into: Write(out second, out first, true)
*/
using System;
class Program
{
    static void Write(out int first, out int second, bool choose)
    {
        if (choose) first = 11; else first = 17;
        second = first + 2;
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first, second;
        Write(out first, out second, true);
        Check(first == 11, "first-output-initialized-through-caller-reference");
        Check(second == 13, "second-output-assigned-and-readable-after-call");
        Write(out first, out second, false);
        Check(first == 17, "output-assignment-on-alternate-return-path");
        Check(second == 19, "previously-assigned-caller-variable-replaced-by-output");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
