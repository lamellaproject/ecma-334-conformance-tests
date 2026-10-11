/*
Rules: E15-2-4-2-no-dependency-nested
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Crate
Into: class Crate : Crate.Item
*/
using System;
class Crate
{
    public int Read() { return 239; }
    public class Item : Crate { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Crate.Item().Read() == 239, "nested-class-may-derive-from-enclosing-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
