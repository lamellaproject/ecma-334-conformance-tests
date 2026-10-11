/*
Rules: E15-3-9-2-nested-qualified-name
Authority: ECMA-334 7th ed 15.3.9.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: typeof(global::Orbit.Shell<>.Leaf<,>)
Into: typeof(global::Orbit.Shell<>.Leaf<>)
*/
using System;
namespace Orbit { public class Shell<A> { public class Leaf<B, C> { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Type type = typeof(global::Orbit.Shell<>.Leaf<,>);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
