/*
Rules: E7-3-label-space; E7-3-label-declaration-names; E7-3-goto-label-references; E7-7-1-label-scope; E7-7-1-local-variable-scope
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: goto target;
Into: goto missing;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int target = 17;
        goto target;
        target: Check(target == 17, "label-and-local-use-separate-spaces");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
