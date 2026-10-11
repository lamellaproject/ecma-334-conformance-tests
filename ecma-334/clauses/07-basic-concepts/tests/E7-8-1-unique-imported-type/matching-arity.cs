/*
Rules: E7-8-1-unique-imported-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Fruit<T> { public T Value; public int Tag = 103; }
Into: public class Fruit<T, U> { public T Value; public int Tag = 103; }
*/
using System;
using East;
using West;
namespace East { public class Fruit<T> { public T Value; public int Tag = 103; } }
namespace West { public class Fruit { public int Value = 107; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fruit<int> item = new Fruit<int>(); item.Value = 109;
        Check(item.Value == 109 && item.Tag == 103, "exactly-one-imported-type-matches-name-and-arity");
        Check(new Fruit().Value == 107, "other-arity-is-not-ambiguous");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
