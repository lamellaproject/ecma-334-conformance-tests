/*
Rules: E12-8-9-1-no-result
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Action lambda = () => Touch();
Into: Action lambda = () => Other();
*/
using System;
class Program
{
    static int checks, failures;
    static int touches;
    static void Touch() { touches++; }
    static void Other() { touches += 10; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Touch();
        Action call = Touch;
        call();
        Check(touches == 2, "void-method-and-delegate-statement-expressions");
        Action lambda = () => Touch();
        Action delegatedLambda = () => call();
        lambda();
        delegatedLambda();
        Check(touches == 4, "void-invocations-as-lambda-bodies");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
