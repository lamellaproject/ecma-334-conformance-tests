/*
Rules: E7-10-side-effect-external-write; E7-10-critical-volatile-reference; E7-10-volatile-side-effect-order
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["framework-runtime"]}
Mutate: Console.Write("A"); marker = 1; Console.Write("B");
Into: Console.Write("B"); marker = 1; Console.Write("A");
*/
using System;
using System.Diagnostics;
using System.Reflection;
class Program
{
    static int checks, failures;
    static volatile int marker;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main(string[] args)
    {
        if (args.Length != 0)
        {
            Console.Write("A"); marker = 1; Console.Write("B");
            int observed = marker;
            Console.Write(observed == 1 ? "C" : "D");
            return;
        }
        var start = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location, "child");
        start.UseShellExecute = false; start.CreateNoWindow = true; start.RedirectStandardOutput = true;
        using (Process child = Process.Start(start))
        {
            string observed = child.StandardOutput.ReadToEnd(); child.WaitForExit();
            Check(child.ExitCode == 0 && observed == "ABC", "external-output-preserves-order-across-volatile-critical-points");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
