/*
Rules: E12-3-1-binds-object-creation; E12-6-1-category-instance-constructors; E12-6-1-invocation-overload-resolution
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic argument = 6;
Into: object argument = 6;
*/
using System;
public class Box
{
    public int selected;
    public Box(int value) { selected = 1; }
    public Box(object value) { selected = 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = 6;
        Box value = new Box(argument);
        Check(value.selected == 1, "dynamic-constructor-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
