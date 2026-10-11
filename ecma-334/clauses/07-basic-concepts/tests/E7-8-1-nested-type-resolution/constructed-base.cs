/*
Rules: E7-8-1-nested-type-resolution; E7-8-1-enclosing-type-search-order
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Branch : Root<int>
Into: class Branch : Root<long>
*/
using System;
class Root<T> { public class Token<U> { public T Value; } }
class Branch : Root<int>
{
    public static object Make() { Token<long> value = new Token<long>(); value.Value = 61; return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch.Make() is Root<int>.Token<long>, "inherited-nested-type-uses-current-constructed-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
