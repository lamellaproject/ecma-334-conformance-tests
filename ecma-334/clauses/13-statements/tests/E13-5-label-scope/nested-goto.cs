/*
Rules: E13-5-label-scope; E13-5-form-label; E13-5-labels-in-blocks; E13-5-label-declaration; E13-5-label-goto-reference; E13-5-label-declaration-space; E13-5-labeled-execution; E13-5-goto-label-reachability; E13-1-form-labeled
Authority: ECMA-334 7th ed 13.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: { goto mark; }
Into: { mark = 5; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int mark = 0;
        { goto mark; }
        mark = 9;
        mark: mark += 2;
        Check(mark == 2, "nested-goto-and-independent-variable-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
