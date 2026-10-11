/*
Rules: E7-1-synthesized-task-result; E7-1-entry-int-termination; E7-2-int-exit-code; E7-2-termination-control
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["process-launch"]}
Mutate: Task.FromResult(37)
Into: Task.FromResult(0)
*/
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Task<int> Main(string[] args)
    {
        if (args.Length != 0) return Task.FromResult(37);
        string assembly = Assembly.GetExecutingAssembly().Location;
        var start = new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName, "\"" + assembly + "\" child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        using (Process child = Process.Start(start))
        {
            child.WaitForExit();
            Check(child.ExitCode == 37 && child.StandardOutput.ReadToEnd() == "", "task-result-is-process-exit-code");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return Task.FromResult(failures);
    }
}
