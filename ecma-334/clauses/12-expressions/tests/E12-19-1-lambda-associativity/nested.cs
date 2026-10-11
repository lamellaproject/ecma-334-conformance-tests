/*
Rules: E12-19-1-lambda-associativity
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: first => second => first * 10 + second
Into: first => second => second * 10 + first
*/
using System;
delegate int Result(int value);
delegate Result Factory(int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Factory factory = first => second => first * 10 + second;
        Result result = factory(3);
        Check(result(7) == 37, "outer-function-returns-inner-function");
        Check(factory(5)(9) == 59, "right-associated-parameter-scopes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
