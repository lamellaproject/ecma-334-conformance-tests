/*
Rules: E8-4-3-open-type-definition; E8-4-3-type-parameter-open; E8-4-3-array-openness; E8-4-3-constructed-openness; E8-4-3-nested-constructed-openness; E8-4-3-closed-type-definition
Authority: ECMA-334 7th ed 8.4.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: typeof(Generic<>).GetGenericArguments()[0]
Into: typeof(int)
*/
using System;
class Generic<T> { }
class Pair<T, U> { }
class Outer<T> { public class Inner { } }
class Plain { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // These Type values describe source types; they are metadata, not instances of open runtime types.
        Type parameter = typeof(Generic<>).GetGenericArguments()[0];
        Type array = parameter.MakeArrayType(); Type pair = typeof(Pair<,>).MakeGenericType(parameter, typeof(int));
        Check(parameter.ContainsGenericParameters, "type-parameter-is-open");
        Check(array.ContainsGenericParameters && !typeof(int[]).ContainsGenericParameters, "array-openness-follows-element");
        Check(pair.ContainsGenericParameters && !typeof(Pair<int, string>).ContainsGenericParameters, "constructed-openness-follows-arguments");
        Check(typeof(Outer<>.Inner).ContainsGenericParameters && !typeof(Outer<int>.Inner).ContainsGenericParameters, "nested-openness-follows-container");
        Check(!typeof(Plain).ContainsGenericParameters, "nongeneric-type-is-closed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
