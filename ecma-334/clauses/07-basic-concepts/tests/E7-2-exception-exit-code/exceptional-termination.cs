/*
Rules: E7-2-exception-exit-code
Authority: ECMA-334 7th ed 7.2
Version: 7.3
Expected: run
Stdout: OK 0
Fixture: {"target_requires":["process-launch"]}
Mutate: throw new EntryFailure();
Into: throw 1;
*/
using System;
using System.Diagnostics;
using System.Reflection;
class EntryFailure : Exception { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main(string[] args)
    {
        if (args.Length != 0) throw new EntryFailure();
        string assembly = Assembly.GetExecutingAssembly().Location;
        var start = new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName, "\"" + assembly + "\" child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        using (Process child = Process.Start(start))
        {
            child.WaitForExit();
            // Completion is the oracle; every implementation-selected integer status is allowed.
            int status = child.ExitCode;
            child.StandardOutput.ReadToEnd();
            child.StandardError.ReadToEnd();
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
