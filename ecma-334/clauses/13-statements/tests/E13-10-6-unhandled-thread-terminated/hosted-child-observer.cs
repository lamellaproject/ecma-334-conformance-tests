/*
Rules: E13-10-6-unhandled-thread-terminated
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw new Exception();
Into: return;
*/
using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Raise() { Console.WriteLine("THREAD-ENTERED"); throw new Exception(); }
    static void Worker()
    {
        Raise();
        Console.WriteLine("FAIL unhandled-worker-continued");
    }
    static void Main(string[] args)
    {
        // This hosted observer needs a child process because permitted host termination can prevent in-process observation.
        if (args.Length != 0)
        {
            Thread worker = new Thread(Worker);
            worker.Start();
            worker.Join();
            return;
        }
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = Environment.ProcessPath;
        start.ArgumentList.Add(Environment.GetCommandLineArgs()[0]);
        start.ArgumentList.Add("child");
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        string output;
        using (Process child = Process.Start(start))
        {
            output = child.StandardOutput.ReadToEnd();
            string error = child.StandardError.ReadToEnd();
            child.WaitForExit();
        }
        Check(output.Contains("THREAD-ENTERED"), "child-reached-unhandled-throw");
        // Both whole-host termination and termination of only the worker are allowed impacts.
        Check(!output.Contains("FAIL"), "unhandled-thread-does-not-continue");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
