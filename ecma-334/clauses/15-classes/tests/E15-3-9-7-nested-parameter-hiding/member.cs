/*
Rules: E15-3-9-7-nested-parameter-hiding
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Cell<T>
Into: class Cell<U>
*/
using System;
class Box
{
    public class T { }
    public class Cell<T> { public T Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box.Cell<int> cell = new Box.Cell<int>();
        cell.Value = 397;
        int value = cell.Value;
        Check(value == 397, "nested-type-parameter-hides-outer-type-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
