/*
Rules: E15-6-11-effective-return-async-generic-task
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: async Task<long> Read()
Into: Task<long> Read()
*/
using System;
using System.Threading.Tasks;
class Program
{
    static async Task<long> Read() { return 43; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long result = Read().GetAwaiter().GetResult();
        Check(result == 43, "task-effective-element-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
