/*
Rules: P09-top-level-body
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: int seed = 5;
Into: int seed = 6;
*/
using System;
using static Audit;

// top-level-statements.md L70; alpha-v13 basic concepts 7.1.3.
// draft-v8 7.1 still specifies named entry points, before this later feature.
int seed = 5;
int Grow(int amount) { Audit.Trace = Audit.Trace * 10 + 2; return seed + amount; }
Audit.Trace = 1;
Audit.Check(Program.Secret == 23, "generated-body-has-program-member-access");
Audit.Check(Grow(7) == 12, "top-level-local-function-captures-local");
Audit.Check(Audit.Trace == 12, "statements-and-local-function-in-order");
if (failures == 0) Console.WriteLine("OK " + checks);
return failures == 0 ? 0 : 1;

partial class Program { private static int Secret = 23; }
static class Audit
{
    public static int checks, failures, Trace;
    public static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
}
