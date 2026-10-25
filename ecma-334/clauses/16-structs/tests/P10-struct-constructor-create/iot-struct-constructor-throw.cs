/*
Rules: P10-struct-constructor-create
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: throw new Burst();
Into: return;
*/
using System;
class Burst : Exception { }
readonly record struct Hazard
{
    public static int Calls;
    public Hazard() { Calls++; throw new Burst(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        bool caught = false, continued = false;
        try { new Hazard(); continued = true; }
        catch (Burst) { caught = true; }
        catch (Exception) { }
        Check(caught, "constructor-exception-type");
        Check(!continued, "throw-prevents-continuation");
        Check(Hazard.Calls == 1, "throwing-body-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
