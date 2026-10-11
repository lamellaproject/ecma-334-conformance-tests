/*
Rules: E12-3-4-type-parameter-subexpression
Authority: ECMA-334 7th ed 12.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Choose(trigger, argument)
Into: Choose(trigger, (object)argument)
*/
using System;
public class Box
{
    public int Choose(object trigger, int argument) { return 1; }
    public int Choose(object trigger, string argument) { return 2; }
    public int Choose(object trigger, object argument) { return 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Invoke<T>(T argument) { dynamic trigger = new object(); return new Box().Choose(trigger, argument); }
    static void Main()
    {
        Check(Invoke<int>(12) == 1, "runtime-type-parameter-int");
        Check(Invoke<string>("pink") == 2, "runtime-type-parameter-string");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
