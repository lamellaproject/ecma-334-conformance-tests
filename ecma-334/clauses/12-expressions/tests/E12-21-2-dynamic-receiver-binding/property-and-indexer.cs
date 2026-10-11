/*
Rules: E12-21-2-dynamic-receiver-binding; E12-21-2-dynamic-result-type; E12-21-2-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Receiver().Value = Right()
Into: Receiver().Value = Right() + 1
*/
using System;
using Microsoft.CSharp.RuntimeBinder;
public class Device
{
    public int Stored, Key;
    public int Value { set { Program.trace += "S"; Stored = value; } }
    public int this[int key] { set { Program.trace += "X"; Key = key; Stored = value; } }
}
public class Program
{
    public static string trace = "";
    static Device target = new Device();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static dynamic Receiver() { trace += "E"; return target; }
    static int Index() { trace += "I"; return 2; }
    static int Right() { trace += "R"; return 17; }
    static void Main()
    {
        var result = (Receiver().Value = Right());
        Check((int)result == 17 && target.Stored == 17 && trace == "ERS", "runtime-property-assignment");
        bool dynamicResult = false;
        try { result.Missing(); } catch (RuntimeBinderException) { dynamicResult = true; }
        Check(dynamicResult, "assignment-has-dynamic-compile-time-type");
        trace = "";
        result = (Receiver()[Index()] = Right());
        Check((int)result == 17 && target.Key == 2 && target.Stored == 17, "runtime-indexer-assignment");
        Check(trace == "EIRX", "dynamic-indexer-evaluation-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
