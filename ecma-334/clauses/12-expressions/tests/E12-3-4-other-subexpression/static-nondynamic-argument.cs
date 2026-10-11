/*
Rules: E12-3-4-other-subexpression
Authority: ECMA-334 7th ed 12.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object argument = 12;
Into: dynamic argument = 12;
*/
using System;
public class Box
{
    public int Choose(object trigger, int argument) { return 1; }
    public int Choose(object trigger, object argument) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic trigger = new object(); object argument = 12;
        int result = new Box().Choose(trigger, argument);
        Check(result == 2, "nondynamic-keeps-compile-time-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
