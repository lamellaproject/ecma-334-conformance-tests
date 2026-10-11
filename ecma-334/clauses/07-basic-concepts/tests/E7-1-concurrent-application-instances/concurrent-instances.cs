/*
Rules: E7-1-concurrent-application-instances; E7-1-domain-per-instance
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"target_requires":["framework-runtime"]}
Mutate: Process.Start(start)
Into: null
*/
using System;
using System.Diagnostics;
using System.Reflection;
class Program
{
    static int state;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Process StartChild()
    {
        var start = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location, "child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        start.RedirectStandardInput = true;
        start.RedirectStandardOutput = true;
        return Process.Start(start);
    }
    static void Main(string[] args)
    {
        if (args.Length != 0)
        {
            Console.WriteLine("READY " + state);
            state = 17;
            Console.ReadLine();
            Console.WriteLine("DONE " + state);
            return;
        }
        state = 91;
        using (Process first = StartChild())
        using (Process second = StartChild())
        {
            Check(first.StandardOutput.ReadLine() == "READY 0" && second.StandardOutput.ReadLine() == "READY 0", "separate-startup-state");
            Check(!first.HasExited && !second.HasExited && first.Id != second.Id, "two-live-instantiations");
            first.StandardInput.WriteLine("go");
            second.StandardInput.WriteLine("go");
            string left = first.StandardOutput.ReadLine(), right = second.StandardOutput.ReadLine();
            first.WaitForExit();
            second.WaitForExit();
            Check(left == "DONE 17" && right == "DONE 17" && state == 91, "isolated-application-domains");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
