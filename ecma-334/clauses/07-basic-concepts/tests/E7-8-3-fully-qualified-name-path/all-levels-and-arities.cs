/*
Rules: E7-8-3-fully-qualified-name-path; E7-8-3-fully-qualified-name-existence; E7-8-3-global-fully-qualified-name; E7-8-3-nested-fully-qualified-name; E7-8-2-generic-unqualified-name
Authority: ECMA-334 7th ed 7.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Grove.Outer<int>.Inner<long, byte> item = new Grove.Outer<int>.Inner<long, byte>();
Into: Grove.Outer<long>.Inner<int, byte> item = new Grove.Outer<long>.Inner<int, byte>();
*/
using System;
class Plain { }
class Generic<T> { }
namespace Grove
{
    class Outer<T>
    {
        public class Inner<U, V> { }
        public static Type OpenInner() { return typeof(Outer<>.Inner<,>); }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Grove.Outer<int>.Inner<long, byte> item = new Grove.Outer<int>.Inner<long, byte>();
        Check((object)item is global::Grove.Outer<int>.Inner<long, byte>, "entire-qualified-path-retains-arity-and-arguments");
        Check(typeof(Plain) == typeof(global::Plain), "global-nongeneric-name");
        Check(typeof(Generic<>) == typeof(global::Generic<>), "global-generic-dimension-name");
        Check(Grove.Outer<int>.OpenInner() == typeof(global::Grove.Outer<>.Inner<,>), "nested-generic-dimension-path");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
