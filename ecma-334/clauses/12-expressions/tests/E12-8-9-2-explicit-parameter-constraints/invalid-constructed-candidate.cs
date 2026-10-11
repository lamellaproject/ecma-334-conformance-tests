/*
Rules: E12-8-9-2-explicit-parameter-constraints
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Choose<int>(null)
Into: Choose<string>(null)
*/
using System;
class Box<T> where T : class { }
class Program
{
    static int checks, failures;
    static int Choose<T>(Box<T> box) where T : class { return 1; }
    static int Choose<T>(object box) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Choose<int>(null) == 2, "explicit-box-int-constraint-excludes-inapplicable-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
