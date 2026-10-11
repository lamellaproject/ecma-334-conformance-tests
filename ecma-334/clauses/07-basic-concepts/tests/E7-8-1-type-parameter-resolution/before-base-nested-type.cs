/*
Rules: E7-8-1-type-parameter-resolution; E7-8-1-enclosing-type-search-order
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Box<Token> : Root
Into: class Box<Other> : Root
*/
using System;
class Root { public class Token { } }
class Box<Token> : Root { public Token Echo(Token value) { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Box<int>().Echo(59) == 59, "current-type-parameter-precedes-inherited-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
