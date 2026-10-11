/*
Rules: E15-3-9-7-nested-unqualified-in-container
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Cell()
Into: new Box<string>.Cell()
*/
using System;
class Box<T>
{
    public class Cell { public T Value; }
    public Cell Create(T value)
    {
        Cell cell = new Cell();
        cell.Value = value;
        return cell;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<int>.Cell first = new Box<int>().Create(389);
        Box<string>.Cell second = new Box<string>().Create("outer");
        Check(first.Value == 389, "unqualified-nested-construction-uses-int-outer");
        Check(second.Value == "outer", "unqualified-nested-construction-uses-string-outer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
