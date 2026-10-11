/*
Rules: E9-2-7-output-parameter-referent; E9-2-7-output-parameter-category; E9-2-7-output-parameter-reference-variable; E9-2-7-output-parameter-lifetime-start; E9-2-7-output-argument-unassigned; E9-2-7-output-argument-completion-assigned; E9-4-1-output-argument-not-read
Authority: ECMA-334 7th ed 9.2.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value = 58;
Into: value = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Fill(out int value) { value = 58; }
    static void Main()
    {
        int cell;
        Fill(out cell);
        Check(cell == 58, "unassigned-local-assigned-after-call");
        int[] elements = new int[] { 6 };
        Fill(out elements[0]);
        Check(elements[0] == 58, "out-referent-is-array-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
