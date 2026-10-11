/*
Rules: E7-8-1-name-form-qualified; E7-8-1-qualified-prefix-resolution; E7-8-1-qualified-class-struct-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Chest<int>.Pocket<long> value = new Chest<int>.Pocket<long>();
Into: Chest<long>.Pocket<int> value = new Chest<long>.Pocket<int>();
*/
using System;
class Chest<T> { public class Pocket<U> { public T First; public U Second; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Chest<int>.Pocket<long> value = new Chest<int>.Pocket<long>();
        value.First = 31; value.Second = 37L;
        Check(value.First == 31 && value.Second == 37L, "constructed-prefix-and-nested-type-arguments");
        Check((object)value is Chest<int>.Pocket<long>, "nested-construction-retains-both-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
