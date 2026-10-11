/*
Rules: E12-6-4-6-exact-block-body
Authority: ECMA-334 7th ed 12.6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return x + 1;
Into: return x + 1L;
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static int Pick(Func<int, Task<int>> f) { return 1; }
    static int Pick(Func<int, Task<long>> f) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(async x => { if (x > 0) return x; return x + 1; }) == 1, "all-async-block-returns-exactly-match-task-inner-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
