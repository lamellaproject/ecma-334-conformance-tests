/*
Rules: P09-top-level-args
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Fixture: {"arguments":["axle","rim"]}
Mutate: args[1] == "rim"
Into: args[0] == "rim"
*/
using System;
using static Audit;

// top-level-statements.md L93; alpha-v13 basic concepts 7.1.3/7.1.6.
Audit.Check(args != null && args.Length == 2, "non-null-argument-array-length");
Audit.Check(args != null && args.Length == 2 && args[0] == "axle" && args[1] == "rim", "application-arguments-in-order");
if (failures == 0) Console.WriteLine("OK " + checks);
return failures == 0 ? 0 : 1;

static class Audit
{
    public static int checks, failures;
    public static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
}
