/*
Rules: E12-5-1-constructed-substitution
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Choose(box.Value)
Into: Choose((object)box.Value)
*/
using System;
class Box<T> { public T Value; public Box(T value) { Value = value; } }
class Program
{
    static int checks, failures;
    static int Choose(int value) { return 1; }
    static int Choose(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<int> box = new Box<int>(7); int result = Choose(box.Value);
        Check(result == 1, "member-type-argument-substitution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
