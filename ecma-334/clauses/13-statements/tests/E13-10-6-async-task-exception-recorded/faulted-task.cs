/*
Rules: E13-10-6-async-task-exception-recorded; E13-10-6-async-task-exception-state
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw expected;
Into: return 0;
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Exception expected = new Exception();
    static async Task<int> Raise() { await Task.FromResult(0); throw expected; }
    static void Main()
    {
        Task<int> task = null;
        bool escapedCall = false;
        try { task = Raise(); }
        catch (Exception) { escapedCall = true; }
        Exception observed = null;
        if (task != null)
        {
            try { int value = task.GetAwaiter().GetResult(); }
            catch (Exception actual) { observed = actual; }
        }
        Check(!escapedCall && task != null && task.IsFaulted, "async-exception-faults-return-task");
        Check(observed == expected, "async-records-original-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
