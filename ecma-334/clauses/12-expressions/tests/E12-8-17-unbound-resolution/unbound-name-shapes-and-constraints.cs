/*
Rules: E12-8-17-unbound-resolution; E12-8-17-unbound-form; E12-8-17-unbound-simple-form; E12-8-17-unbound-alias-form; E12-8-17-unbound-nested-form; E12-8-17-generic-dimension-form; E12-8-17-comma-form; E12-8-17-unbound-name-rewrite; E12-8-17-unbound-ignore-constraints; E12-8-17-unbound-type-object
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Type nested = typeof(Crate::Envelope<>.Leaf<,>);
Into: Type nested = typeof(Crate::Envelope<>);
*/
using System;
using Crate = Storage;
class Solo<T> where T : struct { }
class Trio<T, U, V> { }
namespace Storage
{
    class Envelope<X> where X : struct
    {
        public class Leaf<Y, Z> where Z : struct { }
        public class Node { }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type single = typeof(Solo<>);
        Type triple = typeof(Trio<,,>);
        Type nested = typeof(Crate::Envelope<>.Leaf<,>);
        Type node = typeof(Crate::Envelope<>.Node);
        Check(single == typeof(Solo<int>).GetGenericTypeDefinition(), "unbound-ignores-value-type-constraint");
        Check(triple == typeof(Trio<short, byte, int>).GetGenericTypeDefinition(), "unbound-generic-comma-count");
        Check(nested == typeof(Storage.Envelope<int>.Leaf<object, long>).GetGenericTypeDefinition(), "aliased-nested-unbound-resolution");
        Check(node == typeof(Storage.Envelope<int>.Node).GetGenericTypeDefinition(), "nested-name-without-own-generic-dimension");
        Type[] parameters = nested.GetGenericArguments();
        Check(parameters.Length == 3 && parameters[0].IsGenericParameter && parameters[1].IsGenericParameter && parameters[2].IsGenericParameter, "all-unbound-dimensions-preserve-arity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
