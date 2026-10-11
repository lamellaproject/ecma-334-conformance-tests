/*
Rules: E13-6-4-async-unsafe-modifiers; E13-6-4-form-async-modifier; E13-6-4-form-ref-modifier; E13-6-4-form-unsafe-modifier
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return 6;
Into: return 7;
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        async unsafe Task<int> Local() { return 6; }
        Check(Local().GetAwaiter().GetResult() == 6, "async-unsafe-local-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
