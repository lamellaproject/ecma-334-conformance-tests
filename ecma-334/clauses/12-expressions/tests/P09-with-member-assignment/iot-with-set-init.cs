/*
Rules: P09-with-member-assignment; P09-with-copy
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: Options changed = original with { Field = 7, Mutable = 8, Initial = 9 };
Into: Options changed = original with { Field = 7, Mutable = 8, Initial = 6 };
*/
using System;
record Options
{
    public int Field;
    public int Mutable { get; set; }
    public int Initial { get; init; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Options original = new Options { Field = 1, Mutable = 2, Initial = 3 };
        Options changed = original with { Field = 7, Mutable = 8, Initial = 9 };
        Check(changed.Field == 7, "instance-field-assigned");
        Check(changed.Mutable == 8, "set-property-assigned");
        Check(changed.Initial == 9, "init-property-assigned");
        Check(original.Field == 1 && original.Mutable == 2 && original.Initial == 3, "original-unmodified");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
