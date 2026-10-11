/*
Rules: E23-2-unsafe-operator; E23-2-operator-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static unsafe Item operator
Into: static Item operator
*/
using System;
class Item { public int Value; public static unsafe Item operator +(Item a, Item b) { int value = a.Value + b.Value; int* p = &value; return new Item { Value = *p }; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item a = new Item { Value = 3 };
        Item b = new Item { Value = 5 };
        Check((a + b).Value == 8, "unsafe-operator-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
