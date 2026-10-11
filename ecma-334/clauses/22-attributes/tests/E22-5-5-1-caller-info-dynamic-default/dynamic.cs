/*
Rules: E22-5-5-1-caller-info-dynamic-default
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic receiver = new Receiver();
Into: Receiver receiver = new Receiver();
*/
using System;
public class Receiver { public string Get([System.Runtime.CompilerServices.CallerMemberName] string name = "default") { return name; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Receiver();
        string value = receiver.Get();
        Check(value == "default", "dynamic-default-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
