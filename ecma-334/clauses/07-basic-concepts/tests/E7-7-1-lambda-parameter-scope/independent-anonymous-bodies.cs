/*
Rules: E7-7-1-lambda-parameter-scope; E7-7-1-anonymous-method-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value => value * 2
Into: renamed => value * 2
*/
using System;
delegate int Operation(int input);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Operation first = value => value * 2;
        Operation second = delegate(int value) { if (value < 0) return -value; return value + 1; };
        Check(first(137) == 274, "lambda-parameter-in-expression-body");
        Check(second(-139) == 139 && second(149) == 150, "anonymous-method-parameter-throughout-block");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
