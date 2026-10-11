/*
Rules: E13-6-2-1-declarator-order; E13-6-2-1-local-variable-declaration; E13-6-2-1-form-explicit-local; E13-6-2-1-declarator-name; E13-6-2-1-declarator-initial-value; E13-6-2-1-local-value-name; E13-6-2-1-initializer-assignment-state; E13-6-2-3-form-explicit-declaration; E13-6-2-3-form-explicit-declarator-list; E13-6-2-3-form-explicit-declarator; E13-6-2-3-initializer-expression; E13-6-2-3-explicit-local-type; E13-6-2-3-explicit-initial-value; E13-6-1-form-variable-declaration; E13-6-1-declarations-in-block; E13-3-1-block-declarations; E13-1-form-declaration
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Next(first + 1)
Into: Next(4)
*/
using System;
class Program
{
    static int checks, failures;
    static long trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static long Next(long digit) { trace = trace * 10 + digit; return digit; }
    static int Kind(int n) { return 1; }
    static int Kind(long n) { return 2; }
    static void Main()
    {
        long first = Next(1), second = Next(first + 1), third;
        third = 3;
        Check(first == 1 && second == 2 && third == 3, "declarator-names-values-and-assignment");
        Check(trace == 12, "declarators-processed-left-to-right");
        Check(Kind(first) == 2 && Kind(second) == 2, "declared-type-controls-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
