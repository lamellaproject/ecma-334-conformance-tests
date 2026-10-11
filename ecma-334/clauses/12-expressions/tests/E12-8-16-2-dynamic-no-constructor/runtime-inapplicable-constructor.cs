/*
Rules: E12-8-16-2-dynamic-no-constructor
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic argument = "bad";
Into: dynamic argument = 6;
*/
using System;
public class Item
{
    public static int Bodies;
    public Item(int number) { Bodies++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = "bad";
        bool error = false;
        try { var value = new Item(argument); }
        catch (Exception) { error = true; }
        Check(error, "runtime-constructor-no-applicable-member");
        Check(Item.Bodies == 0, "binding-error-before-constructor-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
