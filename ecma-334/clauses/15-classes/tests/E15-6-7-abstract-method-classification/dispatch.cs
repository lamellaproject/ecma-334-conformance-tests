/*
Rules: E15-6-7-abstract-method-classification; E15-6-7-abstract-implicitly-virtual; E15-6-7-abstract-introduces-virtual; E15-6-7-abstract-no-implementation
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public abstract int Read();
Into: public int Read() { return 5; }
*/
using System;
abstract class Source { public abstract int Read(); }
abstract class Passage : Source { }
class Amber : Passage { public override int Read() { return 37; } }
class Violet : Passage { public override int Read() { return 83; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source first = new Amber();
        Source second = new Violet();
        Check(first.Read() == 37, "abstract-declaration-dispatches-to-first-concrete-override");
        Check(second.Read() == 83, "abstract-intermediate-class-need-not-supply-an-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
