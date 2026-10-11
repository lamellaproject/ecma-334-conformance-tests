/*
Rules: E15-6-11-effective-return-async-task
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: async Task Work()
Into: Task Work()
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int state;
    static async Task Work() { state = 27; return; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Work().GetAwaiter().GetResult();
        Check(state == 27, "task-effective-void");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
