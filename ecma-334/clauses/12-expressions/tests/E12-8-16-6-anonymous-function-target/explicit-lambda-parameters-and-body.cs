/*
Rules: E12-8-16-6-anonymous-function-target; E12-8-16-6-anonymous-function-body; E12-8-16-6-anonymous-function-binding; E12-8-16-6-anonymous-function-evaluation
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Mapper((int value) => value + step)
Into: new Mapper((int value) => value - step)
*/
using System;
delegate int Mapper(int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int step = 7;
        Mapper operation = new Mapper((int value) => value + step);
        Check(operation(3) == 10, "anonymous-parameter-and-body");
        step = 11;
        Check(operation(6) == 17, "anonymous-body-captures-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
