/*
Rules: E12-6-2-1-grammar-argument-list; E12-6-2-1-grammar-argument; E12-6-2-1-grammar-argument-name; E12-6-2-1-grammar-value; E12-6-2-1-named-definition; E12-6-2-1-positional-definition; E12-6-2-1-invocation-list; E12-6-2-1-explicit-argument-list; E12-6-2-2-position-definition; E12-6-2-2-positional-correspondence; E12-6-2-2-named-correspondence; E12-6-2-2-other-parameter-list
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Pack(first: 3, 5, last: 7)
Into: Pack(first: 5, 3, last: 7)
*/
using System;
class Box
{
    public int value;
    public Box(int first, int middle, int last) { value = first * 100 + middle * 10 + last; }
}
class Program
{
    delegate int Combine(int first, int middle, int last);
    static int checks, failures;
    static int Pack(int first, int middle, int last) { return first * 100 + middle * 10 + last; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int method = Pack(first: 3, 5, last: 7);
        Combine callable = Pack;
        int function = callable(last: 8, first: 2, middle: 6);
        Box box = new Box(4, middle: 1, last: 9);
        Check(method == 357, "mixed-in-position-named-and-positional");
        Check(function == 268, "delegate-named-correspondence");
        Check(box.value == 419, "constructor-argument-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
