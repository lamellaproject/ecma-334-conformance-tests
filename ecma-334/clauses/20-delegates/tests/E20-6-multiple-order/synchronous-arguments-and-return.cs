/*
Rules: E20-6-multiple-order; E20-6-multiple-arguments; E20-6-last-return-value; E20-1-invoke-each-entity
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Calculate composed = first + second + third;
Into: Calculate composed = first + third + second;
*/
using System;
delegate int Calculate(int value);
class Program
{
    static int checks, failures;
    static string trace = "";
    static int arguments, a, b, c;
    static int Argument() { arguments++; return 127; }
    static int A(int value) { trace += "A"; a = value; return value + 2; }
    static int B(int value) { trace += "B"; b = value; return value + 3; }
    static int C(int value) { trace += "C"; c = value; return value + 5; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Calculate first = A, second = B, third = C;
        Calculate composed = first + second + third;
        int result = composed(Argument());
        Check(trace == "ABC", "synchronous-list-order");
        Check(arguments == 1, "argument-expression-evaluated-once");
        Check(a == 127 && b == 127 && c == 127, "same-arguments-to-each-target");
        Check(result == 132, "last-target-return-value");
        Check(composed.GetInvocationList().Length == 3, "each-list-entry-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
