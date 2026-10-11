/*
Rules: E7-7-1-expanded-construct-variable-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out object value
Into: out object renamed
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static object Create(out object result) { result = new object(); return result; }
    static void Main()
    {
        lock (Create(out object value)) { Check(value != null, "expression-variable-visible-in-expanded-lock-body"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
