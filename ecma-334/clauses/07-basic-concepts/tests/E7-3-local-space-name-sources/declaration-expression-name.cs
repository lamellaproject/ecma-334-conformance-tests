/*
Rules: E7-3-local-space-name-sources
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out int assigned
Into: out int renamed
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Provide(out int result) { result = 23; }
    static void Main()
    {
        Provide(out int assigned);
        Check(assigned == 23, "declaration-expression-name-introduced");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
