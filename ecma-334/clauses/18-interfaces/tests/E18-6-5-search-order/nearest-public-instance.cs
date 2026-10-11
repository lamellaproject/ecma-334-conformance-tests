/*
Rules: E18-6-5-search-order; E18-6-5-public-instance-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: class Middle : Root { public new int Read() { return 271; } }
Into: class Middle : Root { private new int Read() { return 271; } }
*/
using System;
interface IRead { int Read(); }
class Root { public int Read() { return 269; } }
class Middle : Root { public new int Read() { return 271; } }
class Inherited : Middle, IRead { }
class Local : Middle, IRead { public new int Read() { return 277; } }
class Private : Root, IRead { private new int Read() { return 281; } }
class Static : Root, IRead { public new static int Read() { return 283; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(((IRead)new Inherited()).Read() == 271, "nearest-base-public-instance");
        Check(((IRead)new Local()).Read() == 277, "implementing-class-searched-first");
        Check(((IRead)new Private()).Read() == 269, "private-member-skipped");
        Check(((IRead)new Static()).Read() == 269, "static-member-skipped");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
