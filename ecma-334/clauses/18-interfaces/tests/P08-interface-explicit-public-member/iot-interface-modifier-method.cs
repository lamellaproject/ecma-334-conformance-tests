/*
Rules: P08-interface-explicit-public-member
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: public int Read();
Into: internal int Read();
*/
using System;
using System.Reflection;

interface IReading
{
    public int Read();
}
class Reading : IReading
{
    public int Calls;
    int IReading.Read() { Calls++; return 67; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        MethodInfo method = typeof(IReading).GetMethod("Read", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        Reading implementation = new Reading();
        IReading view = implementation;
        Check(method.IsPublic, "explicit-public-method-access-flag");
        Check(view.Read() == 67, "explicit-public-method-dispatch");
        Check(implementation.Calls == 1, "explicit-public-method-effect-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
