/*
Rules: E7-2-int-exit-code; E7-1-entry-int-termination; E7-2-termination-control
Authority: ECMA-334 7th ed 7.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["process-launch"]}
Mutate: if (args.Length != 0) return 53;
Into: if (args.Length != 0) return 0;
*/
using System;
using System.Diagnostics;
using System.Reflection;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Main(string[] args)
    {
        if (args.Length != 0) return 53;
        string assembly = Assembly.GetExecutingAssembly().Location;
        var start = new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName, "\"" + assembly + "\" child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        using (Process child = Process.Start(start))
        {
            child.WaitForExit();
            Check(child.ExitCode == 53, "normal-integer-main-exit-status");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures;
    }
}
