/*
Rules: E12-8-9-1-syntax; E12-8-9-1-method-group-invocation; E12-8-9-1-delegate-value-invocation; E12-8-9-1-argument-values; E12-8-9-1-value-result; E12-8-9-1-value-result-type
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Double(9)
Into: Double(10)
*/
using System;
delegate int Operation(int input);
class Program
{
    static int checks, failures;
    static int Double(int input) { return input * 2; }
    static void Store(ref int target, int value) { target = value; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var result = Double(9);
        Check(result == 18 && Kind(result) == 1, "method-invocation-result-and-type");
        Operation op = Double;
        Check(op(11) == 22, "delegate-typed-primary");
        int variable = 0;
        Store(ref variable, 13);
        Check(variable == 13, "argument-provides-variable-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
