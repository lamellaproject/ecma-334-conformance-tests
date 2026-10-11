/*
Rules: E11-2-2-compatible-boxing
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: source is object value
Into: source is string value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int source = 29;
        object answer = null;
        if (source is object value) answer = value;
        Check(answer != null && (int)answer == 29, "boxing-compatible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
