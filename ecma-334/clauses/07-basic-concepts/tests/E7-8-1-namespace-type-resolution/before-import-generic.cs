/*
Rules: E7-8-1-namespace-type-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Fruit<T> { public T Value; public int Tag = 83; }
Into: class Local<T> { public T Value; public int Tag = 83; }
*/
using System;
namespace Imported { public class Fruit<T> { public T Value; public int Tag = 81; } }
namespace Orchard
{
    using Imported;
    using Fruit = Imported.Fruit<long>;
    class Fruit<T> { public T Value; public int Tag = 83; }
    class Reader
    {
        public static int Read() { Fruit<int> item = new Fruit<int>(); item.Value = 89; return item.Value + item.Tag; }
        public static int ReadAlias() { return new Fruit().Tag; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Orchard.Reader.Read() == 172, "namespace-generic-type-before-import");
        Check(Orchard.Reader.ReadAlias() == 81, "alias-applies-only-at-arity-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
