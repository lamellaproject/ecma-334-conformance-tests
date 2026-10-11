/*
Rules: E7-2-alternative-exit-api
Authority: ECMA-334 7th ed 7.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["process-launch"]}
Mutate: Environment.ExitCode = 61;
Into: Environment.ExitCode = 0;
*/
using System;
using System.Diagnostics;
using System.Reflection;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main(string[] args)
    {
        if (args.Length != 0) { Environment.ExitCode = 61; return; }
        string assembly = Assembly.GetExecutingAssembly().Location;
        var start = new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName, "\"" + assembly + "\" child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        using (Process child = Process.Start(start))
        {
            child.WaitForExit();
            Check(child.ExitCode == 61, "implementation-provides-exit-code-api");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
