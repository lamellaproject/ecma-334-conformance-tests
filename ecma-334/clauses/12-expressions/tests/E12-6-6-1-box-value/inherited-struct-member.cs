/*
Rules: E12-6-6-1-box-value; E12-6-6-1-box-other-type
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: original.GetType()
Into: new Other().GetType()
*/
using System;
struct Cell { public int value; }
struct Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell original = new Cell { value = 3 };
        Type result = original.GetType();
        Check(result == typeof(Cell), "inherited-member-observes-boxed-struct-runtime-type");
        Check(original.value == 3, "inherited-member-leaves-source-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
