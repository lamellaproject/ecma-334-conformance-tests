/*
Rules: E15-6-1-method-accessibility
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: private protected int Intersection() { return 41; }
Into: private int Intersection() { return 41; }
*/
using System;
class Parent
{
    private protected int Intersection() { return 41; }
    protected internal int Union() { return 43; }
}
class Holder : Parent { public int Touch() { return Intersection(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Touch() == 41, "private-protected-method-in-same-assembly-derived-class");
        Check(new Parent().Union() == 43, "protected-internal-method-in-same-assembly-other-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
