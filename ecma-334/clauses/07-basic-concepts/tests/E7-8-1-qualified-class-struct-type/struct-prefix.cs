/*
Rules: E7-8-1-qualified-class-struct-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Crate<int>.Token<long> item = new Crate<int>.Token<long>();
Into: Crate<long>.Token<int> item = new Crate<long>.Token<int>();
*/
using System;
struct Crate<T> { public class Token<U> { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate<int>.Token<long> item = new Crate<int>.Token<long>();
        Check((object)item is Crate<int>.Token<long>, "nested-type-in-constructed-struct-prefix");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
