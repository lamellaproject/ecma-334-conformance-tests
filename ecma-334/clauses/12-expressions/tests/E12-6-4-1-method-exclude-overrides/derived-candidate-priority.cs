/*
Rules: E12-6-4-1-method-exclude-overrides; E12-6-4-1-method-derived-applicable
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: leaf.Pick(7)
Into: ((Root)leaf).Pick(7)
*/
using System;
class Root { public virtual int Pick(int x) { return 1; } }
class Leaf : Root
{
    public override int Pick(int x) { return 2; }
    public int Pick(long x) { return 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.Pick(7) == 3, "applicable-derived-nonoverride-excludes-more-exact-base-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
