/*
Rules: E7-1-startup-nonnull-array; E7-1-startup-nonnull-elements; E7-1-startup-argument-values
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"arguments":["spruce","birch"]}
Mutate: static void Main(string[] args)
Into: static void Start(string[] args)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main(string[] args)
    {
        Check(args != null, "startup-array-nonnull");
        Check(args.Length == 2 && args[0] == "spruce" && args[1] == "birch", "host-arguments-and-nonnull-elements");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
