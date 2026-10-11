/*
Rules: E15-2-5-erase-nested
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Reader : Basis<Outer<dynamic>.Inner<dynamic>>
Into: class Reader : Basis<object>
*/
using System;
class Outer<A> { public class Inner<B> { public A First; public B Second; } }
abstract class Basis<A> { public abstract void Read<T>(T value, out int first, out int second) where T : A; }
class Reader : Basis<Outer<dynamic>.Inner<dynamic>>
{
    static int Pick(object value) { return 1; }
    static int Pick(int value) { return 2; }
    public override void Read<T>(T value, out int first, out int second)
    { first = Pick(value.First); second = Pick(value.Second); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first, second;
        new Reader().Read(new Outer<dynamic>.Inner<dynamic> { First = 191, Second = 193 }, out first, out second);
        Check(first == 1, "erasure-of-enclosing-type-argument");
        Check(second == 1, "erasure-of-nested-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
