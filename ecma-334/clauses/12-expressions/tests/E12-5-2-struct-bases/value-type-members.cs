/*
Rules: E12-5-2-struct-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Box value = new Box(11);
Into: Box value = new Box(17);
*/
using System;
struct Box { public int value; public Box(int n) { value = n; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box value = new Box(11); ValueType storage = value; object boxed = storage;
        Check(value.Equals(new Box(11)) && boxed.Equals(new Box(11)), "struct-base-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
