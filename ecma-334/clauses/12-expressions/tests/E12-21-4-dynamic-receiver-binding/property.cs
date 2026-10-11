/*
Rules: E12-21-4-dynamic-receiver-binding; E12-21-4-dynamic-result-type; E12-21-4-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Receiver().Value += Right()
Into: Receiver().Value -= Right()
*/
using System;
using Microsoft.CSharp.RuntimeBinder;
public class Device
{
    public int Stored = 8;
    public int Value
    {
        get { Program.trace += "G"; return Stored; }
        set { Program.trace += "S"; Stored = value; }
    }
}
public class Program
{
    public static string trace = "";
    static Device target = new Device();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static dynamic Receiver() { trace += "E"; return target; }
    static int Right() { trace += "R"; return 7; }
    static void Main()
    {
        var result = (Receiver().Value += Right());
        Check((int)result == 15 && target.Stored == 15, "runtime-compound-property");
        Check(trace == "EGRS", "dynamic-compound-reuses-receiver");
        bool dynamicResult = false;
        try { result.Missing(); } catch (RuntimeBinderException) { dynamicResult = true; }
        Check(dynamicResult, "compound-assignment-dynamic-result-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
