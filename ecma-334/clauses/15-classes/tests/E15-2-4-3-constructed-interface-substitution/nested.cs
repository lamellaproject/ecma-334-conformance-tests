/*
Rules: E15-2-4-3-constructed-interface-substitution; E15-2-4-3-interface-in-scope-parameters
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Item : IView<T>
Into: public class Item
*/
using System;
interface IView<T> { T Read(); }
class Crate<T>
{
    public class Item : IView<T> { public T Value; public T Read() { return Value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate<int>.Item item = new Crate<int>.Item();
        item.Value = 251;
        IView<int> view = item;
        Check(view.Read() == 251, "nested-interface-uses-containing-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
