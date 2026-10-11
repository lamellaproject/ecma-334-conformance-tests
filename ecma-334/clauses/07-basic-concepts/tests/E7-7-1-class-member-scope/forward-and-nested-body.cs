/*
Rules: E7-7-1-class-member-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int value = 73;
Into: static int renamed = 73;
*/
using System;
class Item
{
    public static int Early() { return value; }
    public class Nested { public static int Read() { return value; } }
    static int value = 73;
    public static int Late() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Item.Early() == 73 && Item.Late() == 73, "member-before-and-after-declaration");
        Check(Item.Nested.Read() == 73, "member-in-nested-class-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
