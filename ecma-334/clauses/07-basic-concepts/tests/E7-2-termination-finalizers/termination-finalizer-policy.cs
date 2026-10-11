/*
Rules: E7-2-termination-finalizers
Authority: ECMA-334 7th ed 7.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["framework-runtime"]}
Mutate: ~Token()
Into: ~Missing()
*/
using System;
using System.Diagnostics;
using System.Reflection;
class Token
{
    ~Token() { Console.WriteLine("FINAL"); }
}
class Program
{
    static Token root;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main(string[] args)
    {
        if (args.Length != 0) { root = new Token(); GC.KeepAlive(root); return; }
        var start = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location, "child");
        start.UseShellExecute = false;
        start.CreateNoWindow = true;
        start.RedirectStandardOutput = true;
        using (Process child = Process.Start(start))
        {
            child.WaitForExit();
            string output = child.StandardOutput.ReadToEnd().TrimEnd('\r', '\n');
            Check(output == "" || output == "FINAL", "finalizer-may-run-or-be-skipped-at-termination");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
