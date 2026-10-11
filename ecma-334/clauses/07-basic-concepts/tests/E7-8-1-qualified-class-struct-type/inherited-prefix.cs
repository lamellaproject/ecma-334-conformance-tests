/*
Rules: E7-8-1-qualified-class-struct-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Branch : Root<int> { }
Into: class Branch : Root<long> { }
*/
using System;
class Root<T> { public class Token<U> { } }
class Branch : Root<int> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch.Token<long> item = new Branch.Token<long>();
        Check((object)item is Root<int>.Token<long>, "qualified-inherited-nested-type-retains-base-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
