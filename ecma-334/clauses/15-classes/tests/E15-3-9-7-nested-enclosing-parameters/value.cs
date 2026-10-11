/*
Rules: E15-3-9-7-nested-enclosing-parameters; E15-3-9-7-generic-nested-declarations
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public T Value;
Into: public object Value;
*/
using System;
class Box<T> { public class Cell { public T Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<int>.Cell cell = new Box<int>.Cell();
        cell.Value = 379;
        int value = cell.Value;
        Check(value == 379, "nested-field-uses-enclosing-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
