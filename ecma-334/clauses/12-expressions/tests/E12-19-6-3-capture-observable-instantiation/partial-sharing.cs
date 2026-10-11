/*
Rules: E12-19-6-3-capture-observable-instantiation; E12-19-6-3-instantiation-entry; E12-19-6-3-partial-sharing; E12-19-3-outer-active-instance
Authority: ECMA-334 7th ed 12.19.6.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: perEntry += 2; return shared * 100 + perEntry;
Into: return shared * 100 + index;
*/
using System;
delegate int Result();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result[] functions = new Result[3];
        int shared = 10;
        for (int index = 0; index < functions.Length; index++)
        {
            int perEntry = index + 1;
            functions[index] = () => { shared++; perEntry += 2; return shared * 100 + perEntry; };
        }
        Check(functions[0]() == 1103, "first-entry-has-own-local-instance");
        Check(functions[1]() == 1204, "second-entry-has-distinct-local-instance");
        Check(functions[0]() == 1305, "first-instance-retains-its-update");
        Check(functions[2]() == 1405, "third-entry-shares-only-outer-variable");
        Check(shared == 14, "outer-variable-instance-is-active-after-loop");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
