/*
Rules: E15-3-9-1-nested-definition
Authority: ECMA-334 7th ed 15.3.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Leaf { public static int Read() { return 233; } }
Into: public class Other { public static int Read() { return 233; } }
*/
using System;
class Box { public class Leaf { public static int Read() { return 233; } } }
struct Holder { public class Leaf { public static int Read() { return 239; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Box.Leaf.Read() == 233, "type-nested-in-class");
        Check(Holder.Leaf.Read() == 239, "type-nested-in-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
