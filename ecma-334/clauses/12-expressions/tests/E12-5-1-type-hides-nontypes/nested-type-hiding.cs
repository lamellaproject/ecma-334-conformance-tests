/*
Rules: E12-5-1-type-hides-nontypes; E12-5-1-type-hides-same-arity
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Derived.Name<int>.Code
Into: Base.Name<int>.Code
*/
using System;
class Base
{
    public class Name<T> { public static int Code = 11; }
    public class Name<T, U> { public static int Code = 17; }
    public static int Mark = 3;
}
class Derived : Base
{
    public new class Name<T> { public static int Code = 23; }
    public new class Mark { public static int Code = 31; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Derived.Name<int>.Code;
        Check(result == 23, "type-hides-same-arity-type");
        Check(Derived.Name<int, string>.Code == 17, "type-retains-different-arity-type");
        Check(Derived.Mark.Code == 31, "type-hides-base-nontype");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
