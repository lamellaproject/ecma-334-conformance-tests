/*
Rules: E12-21-2-dynamic-index-binding
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic key = 2;
Into: dynamic key = "z";
*/
using System;
public class Device
{
    public int IntKey, IntValue, StringValue;
    public int this[int key] { set { Program.trace += "N"; IntKey = key; IntValue = value; } }
    public int this[string key] { set { Program.trace += "T"; StringValue = value; } }
}
public class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var target = new Device();
        dynamic key = 2;
        var result = (target[key] = 17);
        Check((int)result == 17 && target.IntKey == 2 && target.IntValue == 17, "dynamic-int-index-overload");
        key = "z";
        result = (target[key] = 23);
        Check((int)result == 23 && target.StringValue == 23, "dynamic-string-index-overload");
        Check(trace == "NT", "nonarray-receiver-runtime-index-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
