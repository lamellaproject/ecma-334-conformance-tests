/*
Rules: E15-2-7-partial-nested-type
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public partial class Part { public int Read() { return Number + 2; } }
Into: public class Part { public int Read() { return Number + 2; } }
*/
using System;
class Container
{
    public partial class Part { public int Number = 79; }
    public partial class Part { public int Read() { return Number + 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Container.Part().Read() == 81, "nested-parts-within-single-container");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
