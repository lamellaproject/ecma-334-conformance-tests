/*
Rules: P09-pattern-relational-unbox
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
Mutate: return value is > 5;
Into: return value is > 5L;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Boxed(object value) { return value is > 5; }
    static bool Nullable(int? value) { return value is > 7; }
    static int Main()
    {
        Check(Boxed(9), "boxed-int");
        Check(!Boxed(9L), "unboxing-type-not-numeric-conversion");
        Check(!Boxed("9"), "wrong-reference-type");
        Check(!Boxed(null), "null-object");
        Check(Nullable(8), "present-nullable");
        Check(!Nullable(null), "absent-nullable");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
