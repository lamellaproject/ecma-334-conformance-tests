/*
Rules: E7-3-type-name-arities
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Shape<T, U>
Into: class Shape<T>
*/
using System;
class Shape { public const int Value = 1; }
class Shape<T> { public const int Value = 2; }
class Shape<T, U> { public const int Value = 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Shape.Value == 1, "nongeneric-name");
        Check(Shape<int>.Value == 2, "one-parameter-name");
        Check(Shape<int, string>.Value == 3, "two-parameter-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
