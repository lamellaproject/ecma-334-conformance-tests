/*
Rules: E13-6-4-function-capture; E13-6-4-call-before-declaration; E13-6-4-form-value-function; E13-6-4-form-function-header; E13-6-4-form-function-block; E13-6-4-function-declaration-end-reachable
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: state += 2;
Into: state += 3;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int state = 1;
        int first = Next();
        int Next() { state += 2; return state; }
        int second = Next();
        Check(first == 3 && second == 5, "local-function-before-and-after-declaration");
        Check(state == 5, "local-function-captures-variable-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
