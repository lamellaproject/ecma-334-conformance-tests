/*
Rules: P08-interface-explicit-abstract-member; P08-interface-explicit-public-member
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: public abstract int Read();
Into: public int Read() { return 0; }
*/
using System;
using System.Reflection;

interface IRead
{
    public abstract int Read();
}
struct Reading : IRead
{
    int IRead.Read() { return 79; }
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
        MethodInfo method = typeof(IRead).GetMethod("Read");
        IRead reader = new Reading();
        Check(method.IsAbstract, "explicit-abstract-method-metadata");
        Check(method.IsPublic, "explicit-public-abstract-access");
        Check(reader.Read() == 79, "explicit-abstract-struct-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
