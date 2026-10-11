/*
Rules: E12-21-4-dynamic-index-binding
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic key = 3;
Into: dynamic key = "z";
*/
using System;
public class Device
{
    public int IntValue = 8, StringValue = 20;
    public int this[int key]
    {
        get { Program.trace += "N"; return IntValue; }
        set { Program.trace += "n"; IntValue = value; }
    }
    public int this[string key]
    {
        get { Program.trace += "T"; return StringValue; }
        set { Program.trace += "t"; StringValue = value; }
    }
}
public class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var target = new Device();
        dynamic key = 3;
        var result = (target[key] += 7);
        Check((int)result == 15 && target.IntValue == 15, "compound-int-index-overload");
        key = "z";
        result = (target[key] += 7);
        Check((int)result == 27 && target.StringValue == 27, "compound-string-index-overload");
        Check(trace == "NnTt", "dynamic-index-get-and-set-overloads");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
