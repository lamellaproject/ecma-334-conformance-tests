/*
Rules: E8-4-1-unbound-generic-definition; E8-4-4-unbound-type-definition; E8-4-4-unbound-declared-entity; E8-4-4-bound-type-definition
Authority: ECMA-334 7th ed 8.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: typeof(Template<>)
Into: typeof(Template<int>)
*/
using System;
class Template<T> { }
class Plain { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type declaration = typeof(Template<>); Type closed = typeof(Template<int>); Type plain = typeof(Plain);
        Check(declaration.IsGenericTypeDefinition && !closed.ContainsGenericParameters && !plain.IsGenericType, "unbound-declaration-and-bound-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
