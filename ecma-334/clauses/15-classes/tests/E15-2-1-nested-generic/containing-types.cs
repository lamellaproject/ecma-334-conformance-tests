/*
Rules: E15-2-1-nested-generic
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Crate<T>
Into: class Crate
*/
using System;
class Crate<T> { public class Item { public T Value; } }
struct Tray<T> { public class Item { public T Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate<int>.Item first = new Crate<int>.Item();
        Tray<int>.Item second = new Tray<int>.Item();
        first.Value = 59;
        second.Value = 61;
        Check(first.Value == 59, "nested-in-generic-class");
        Check(second.Value == 61, "nested-in-generic-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
