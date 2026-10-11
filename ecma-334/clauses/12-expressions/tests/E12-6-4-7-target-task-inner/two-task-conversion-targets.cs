/*
Rules: E12-6-4-7-target-task-inner
Authority: ECMA-334 7th ed 12.6.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(new Source())
Into: Pick((Task<Root>)new Source())
*/
using System;
using System.Threading.Tasks;
class Root { }
class Leaf : Root { }
struct Source
{
    public static implicit operator Task<Root>(Source x) { return null; }
    public static implicit operator Task<Leaf>(Source x) { return null; }
}
class Program
{
    static int checks, failures;
    static int Pick(Task<Root> x) { return 1; }
    static int Pick(Task<Leaf> x) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(new Source()) == 2, "task-target-compares-inner-reference-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
