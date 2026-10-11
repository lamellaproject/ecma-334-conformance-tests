/*
Rules: E7-8-1-enclosing-type-search-order; E7-8-1-nested-type-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Token { public int Value = 53; }
Into: public class Other { public int Value = 53; }
*/
using System;
class Shell
{
    public class Token { public int Value = 51; }
    public class Inner
    {
        public class Token { public int Value = 53; }
        public static int Read() { return new Token().Value; }
    }
    public class Sibling { public static int Read() { return new Token().Value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Shell.Inner.Read() == 53, "current-instance-type-precedes-enclosing-type");
        Check(Shell.Sibling.Read() == 51, "search-continues-to-enclosing-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
