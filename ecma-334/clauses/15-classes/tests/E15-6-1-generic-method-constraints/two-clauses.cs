/*
Rules: E15-6-1-generic-method-constraints; E15-6-1-generic-method-classification; E15-6-1-grammar-method-header-form-2; E15-6-1-method-parameter-scope; E15-6-1-type-parameter-type-uses
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : U, new()
Into: where T : U
*/
using System;
class Root { public int Value = 61; }
class Leaf : Root { }
class Factory
{
    public static T Create<T, U>() where T : U, new() where U : Root
    {
        T result = new T();
        U parent = result;
        return result;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = Factory.Create<Leaf, Root>();
        Check(value.Value == 61, "method-type-parameters-in-return-body-and-constraints");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
