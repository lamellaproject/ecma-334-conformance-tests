/*
Rules: E15-3-9-7-additional-nested-parameters; E15-3-9-7-nested-enclosing-parameters
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Cell<U>
Into: class Cell<V>
*/
using System;
class Box<T> { public class Cell<U> { public T Left; public U Right; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<int>.Cell<string> cell = new Box<int>.Cell<string>();
        cell.Left = 383;
        cell.Right = "nested";
        int left = cell.Left;
        string right = cell.Right;
        Check(left == 383, "outer-type-parameter-remains-available");
        Check(right == "nested", "additional-nested-type-parameter-applied");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
