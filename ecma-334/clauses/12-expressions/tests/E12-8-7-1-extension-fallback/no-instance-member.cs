/*
Rules: E12-8-7-1-extension-fallback
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: source.Read()
Into: source.Other()
*/
using System;
class Worker { public int value = 3; }
static class Extensions
{
    public static int Read(this Worker source) { return source.value; }
    public static int Other(this Worker source) { return 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker source = new Worker();
        int result = source.Read();
        Check(result == 3, "member-access-falls-back-to-extension-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
