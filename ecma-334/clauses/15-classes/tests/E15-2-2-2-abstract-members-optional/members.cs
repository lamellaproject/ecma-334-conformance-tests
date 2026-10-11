/*
Rules: E15-2-2-2-abstract-members-optional
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: abstract class Empty
Into: sealed class Empty
*/
using System;
abstract class Empty { public int Read() { return 109; } }
abstract class Hook { public abstract int Read(); }
class First : Empty { }
class Second : Hook { public override int Read() { return 113; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new First().Read() == 109, "abstract-without-abstract-members");
        Check(new Second().Read() == 113, "abstract-with-abstract-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
