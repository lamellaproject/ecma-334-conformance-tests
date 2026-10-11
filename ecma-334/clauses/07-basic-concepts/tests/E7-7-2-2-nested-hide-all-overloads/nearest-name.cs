/*
Rules: E7-7-2-2-nested-hide-all-overloads
Authority: ECMA-334 7th ed 7.7.2.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static int Read(long value)
Into: static int Renamed(long value)
*/
using System;
class Container
{
    public static int Read(int value) { return 43; }
    public static int Read(string value) { return 47; }
    public class Inner
    {
        static int Read(long value) { return 53; }
        public static int Probe() { return Read(5); }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Container.Inner.Probe() == 53, "inner-name-hides-better-outer-overload");
        Check(Container.Read(5) == 43, "outer-integer-overload-visible-outside-inner-scope");
        Check(Container.Read("ash") == 47, "outer-string-overload-visible-outside-inner-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
