/*
Rules: E10-7-1-void-expression; E10-7-1-void-block; E10-7-1-value-expression; E10-7-1-value-block
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Action expression=()=>Trace.Bump();
Into: Action expression=default(Action);
*/
using System;
using System.Threading.Tasks;

static class Trace {public static int Count;public static void Bump(){Count++;} public static Task Work(){Count++;return Task.CompletedTask;}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action expression=()=>Trace.Bump(); Action block=()=>{Trace.Bump();return;};
        Func<int> valueExpression=()=>61; Func<int> valueBlock=()=>{if(Trace.Count>=0)return 62;else return 63;};
        Func<Task> asyncExpression=async()=>await Trace.Work();
        Func<Task> asyncBlock=async()=>{await Trace.Work();return;};
        Func<Task<long>> asyncValueExpression=async()=>await Task.FromResult(64);
        Func<Task<long>> asyncValueBlock=async()=>{int n=await Task.FromResult(65);return n;};
        expression(); block(); asyncExpression().GetAwaiter().GetResult(); asyncBlock().GetAwaiter().GetResult();
        Check(Trace.Count==4 && valueExpression()==61 && valueBlock()==62 && asyncValueExpression().GetAwaiter().GetResult()==64 && asyncValueBlock().GetAwaiter().GetResult()==65, "E10-7-1-void-expression-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
