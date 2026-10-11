/*
Rules: E18-4-1-partial-member-union; E18-4-1-partial-member-scope
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: nameof(Value)
Into: nameof(Missing)
*/
using System;
class NameAttribute : Attribute { public NameAttribute(string name) { } }
partial interface ICell { int Value { get; } }
partial interface ICell { [Name(nameof(Value))] int Read(); }
class Cell : ICell { public int Value { get { return 53; } } public int Read() { return 59; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICell cell = new Cell();
        Check(cell.Value == 53, "member-from-first-part");
        Check(cell.Read() == 59, "member-from-second-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
