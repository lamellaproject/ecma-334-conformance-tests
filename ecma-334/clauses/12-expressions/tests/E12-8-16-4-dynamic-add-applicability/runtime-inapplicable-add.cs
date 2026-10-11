/*
Rules: E12-8-16-4-dynamic-add-applicability
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic element = "bad";
Into: dynamic element = 7;
*/
using System;
using System.Collections;
public class Bag : IEnumerable
{
    public static int Constructors, Bodies;
    public Bag() { Constructors++; }
    public void Add(int value) { Bodies++; }
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic element = "bad";
        bool error = false;
        try { var value = new Bag { element }; }
        catch (Exception) { error = true; }
        Check(error, "runtime-collection-add-no-applicable-member");
        Check(Bag.Constructors == 1, "runtime-add-binding-after-constructor");
        Check(Bag.Bodies == 0, "invalid-add-body-not-entered");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
