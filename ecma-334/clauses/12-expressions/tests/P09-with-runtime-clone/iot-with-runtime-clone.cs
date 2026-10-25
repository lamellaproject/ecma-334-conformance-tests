/*
Rules: P09-with-runtime-clone; P09-with-copy
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: Root changed = original with { Code = 8 };
Into: Root changed = new Root { Code = 8 };
*/
using System;
record Root { public int Code { get; init; } }
record Leaf : Root { public int Extra; public object Shared; }
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Root original = new Leaf { Code = 3, Extra = 7, Shared = new object() };
        Root changed = original with { Code = 8 };
        Check(changed.GetType() == typeof(Leaf), "runtime-derived-type");
        Leaf leaf = changed as Leaf;
        Check(leaf != null && leaf.Extra == 7, "derived-field-preserved");
        Check(leaf != null && ReferenceEquals(leaf.Shared, ((Leaf)original).Shared), "derived-reference-preserved");
        Check(changed.Code == 8 && original.Code == 3, "base-member-on-copy");
        Check(!ReferenceEquals(changed, original), "runtime-clone-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
