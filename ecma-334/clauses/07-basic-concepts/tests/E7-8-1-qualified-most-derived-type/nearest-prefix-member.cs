/*
Rules: E7-8-1-qualified-most-derived-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new class Token<T> { public int Value = 137; }
Into: public class Other<T> { public int Value = 137; }
*/
using System;
class Root { public class Token<T> { public int Value = 133; } }
class Middle : Root { public new class Token<T> { public int Value = 137; } }
class Leaf : Middle { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Leaf.Token<int>().Value == 137, "qualified-most-derived-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
