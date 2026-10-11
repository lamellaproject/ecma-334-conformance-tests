/*
Rules: E22-2-2-default-targets
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: class MarkAttribute : Attribute
Into: [AttributeUsage(AttributeTargets.Class)] class MarkAttribute : Attribute
*/
using System;
class MarkAttribute : Attribute { }
[Mark] class Item { [Mark] public int Field; }
[Mark] struct Value { }
[Mark] interface Contract { }
[Mark] enum Mode { [Mark] First }
[Mark] delegate void Action([Mark] int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
