/*
Rules: E12-21-1-right-associative
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Second().Value = Third().Value = Produce()
Into: Second().Value = Produce()
*/
using System;
class Storage
{
    public string Name;
    public int Stored;
    public Storage(string name) { Name = name; }
    public int Value { set { Program.trace += Name; Stored = value; } }
}
class Program
{
    public static string trace = "";
    static Storage first = new Storage("a"), second = new Storage("b"), third = new Storage("c");
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Storage First() { trace += "A"; return first; }
    static Storage Second() { trace += "B"; return second; }
    static Storage Third() { trace += "C"; return third; }
    static int Produce() { trace += "R"; return 23; }
    static void Main()
    {
        int result = (First().Value = Second().Value = Third().Value = Produce());
        Check(first.Stored == 23 && second.Stored == 23 && third.Stored == 23, "all-assignment-targets");
        Check(result == 23, "outer-assignment-result");
        Check(trace == "ABCRcba", "right-grouping-and-inner-first-stores");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
