/*
Rules: E12-19-1-lambda-precedence
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: value => value = 53
Into: value => value
*/
using System;
delegate int Assign(int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Assign first, second;
        first = second = value => value = 53;
        Check(object.ReferenceEquals(first, second), "assignment-contains-lambda");
        Check(first(7) == 53, "lambda-body-contains-assignment");
        Check(second(11) == 53, "assigned-delegate-references-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
