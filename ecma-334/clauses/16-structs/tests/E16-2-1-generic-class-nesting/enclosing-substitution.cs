/*
Rules: E16-2-1-generic-class-nesting; E16-2-1-generic-struct-nesting
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ClassBox<int>.Entry first = new ClassBox<int>.Entry();
Into: ClassBox<string>.Entry first = new ClassBox<string>.Entry();
*/
using System;
class ClassBox<T> { public struct Entry { public T Value; } }
struct StructBox<T> { public struct Entry { public T Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ClassBox<int>.Entry first = new ClassBox<int>.Entry(); first.Value = 23;
        StructBox<string>.Entry second = new StructBox<string>.Entry(); second.Value = "record";
        Check(first.Value == 23, "generic-class-outer");
        Check(second.Value == "record", "generic-struct-outer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
