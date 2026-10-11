/*
Rules: E15-6-5-override-inherits-constraints
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public virtual T Make<T>() where T : new()
Into: public virtual T Make<T>()
*/
using System;
class Token { public int Value; public Token() { Value = 211; } }
class Root { public virtual T Make<T>() where T : new() { return default(T); } }
class Leaf : Root { public override U Make<U>() { return new U(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Leaf();
        Token first = value.Make<Token>(), second = value.Make<Token>();
        Check(first != null && second != null && first.Value == 211 && second.Value == 211, "renamed-override-type-parameter-inherits-constructor-constraint");
        Check(first != second, "inherited-constraint-permits-construction-in-override-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
