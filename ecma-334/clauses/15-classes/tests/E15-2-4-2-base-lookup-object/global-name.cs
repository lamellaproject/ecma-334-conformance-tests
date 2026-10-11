/*
Rules: E15-2-4-2-base-lookup-object
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Leaf : Root<Token>
Into: class Leaf : Root<Root<int>.Token>
*/
using System;
class Token { }
class Root<T> { public class Token { } public T Value; }
class Leaf : Root<Token> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Root<global::Token> root = leaf;
        global::Token token = new global::Token();
        root.Value = token;
        Check(root.Value == token, "base-lookup-excludes-would-be-inherited-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
