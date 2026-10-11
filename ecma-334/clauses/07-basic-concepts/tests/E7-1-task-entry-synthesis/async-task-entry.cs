/*
Rules: E7-1-task-entry-synthesis; E7-1-entry-async-task; E7-1-synthesized-parameters; E7-1-synthesized-task-void; E7-1-synthesized-main-call; E7-1-synthesized-main-argument; E7-1-synthesized-task-wait; E7-1-effective-entry-definition; E7-1-effective-entry-return
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"arguments":["willow"]}
Mutate: static async Task Main(string[] args)
Into: static async void Main(string[] args)
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static async Task Main(string[] args)
    {
        await Task.Delay(50);
        var entry = typeof(Program).Assembly.EntryPoint;
        Check(entry.Name != "Main" && entry.ReturnType == typeof(void), "effective-entry-is-synchronous-void");
        var parameters = entry.GetParameters();
        Check(parameters.Length == 1 && parameters[0].ParameterType == typeof(string[]), "synthesized-string-array-parameter");
        Check(args != null && args.Length == 1 && args[0] == "willow", "awaited-main-received-host-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
