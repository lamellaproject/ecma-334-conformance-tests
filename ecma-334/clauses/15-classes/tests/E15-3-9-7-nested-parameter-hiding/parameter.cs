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
class Box<T> { public class Cell<T> { public T Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<int>.Cell<string> cell = new Box<int>.Cell<string>();
        cell.Value = "inner";
        string value = cell.Value;
        Check(value == "inner", "nested-type-parameter-hides-outer-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
