/*
Rules: P08-interface-explicit-public-member
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"ReadApi","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"ReadApi"}]}}
Mutate: public int Read();
Into: internal int Read();
*/
using System;
using System.Reflection;

#if LIBRARY
public interface IReadApi
{
    public int Read();
}
public struct ReadApi : IReadApi
{
    int IReadApi.Read() { return 73; }
    public static int Invoke(IReadApi reader) { return reader.Read(); }
}
#else
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
        MethodInfo method = typeof(IReadApi).GetMethod("Read", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        Check(method.IsPublic, "imported-explicit-public-access-flag");
        Check(ReadApi.Invoke(new ReadApi()) == 73, "imported-explicit-public-struct-dispatch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
