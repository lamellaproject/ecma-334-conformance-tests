/*
Rules: P09-top-level-await
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: await Pipeline.Fetch()
Into: await Task.FromResult(0)
*/
using System;
using System.Threading.Tasks;
using static Audit;

// top-level-statements.md L95; alpha-v13 basic concepts 7.1.3/7.1.6.
Audit.Trace = 1;
int result = await Pipeline.Fetch();
Audit.Check(result == 29, "awaited-result-reaches-entry-body");
Audit.Check(Audit.Trace == 12, "entry-body-waits-for-continuation");
if (failures == 0) Console.WriteLine("OK " + checks);
return failures == 0 ? 0 : 1;

static class Pipeline
{
    public static async Task<int> Fetch()
    {
        await Task.Yield();
        Audit.Trace = Audit.Trace * 10 + 2;
        return 29;
    }
}
static class Audit
{
    public static int checks, failures, Trace;
    public static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
}
