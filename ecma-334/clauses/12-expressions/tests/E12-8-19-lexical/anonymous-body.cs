/*
Rules: E12-8-19-lexical
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/anonymous-body-9b2f8cc3c9.cs.part
Mutate: () => (byte)n
Into: () => (byte)1
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int n = 256;
        Func<byte> getter;
        checked { getter = () => (byte)n; }
        try
        {
            Check(getter() == 0, "anonymous-body/wrapped-value");
        }
        catch (Exception error)
        {
            Check(false, "anonymous-body/unexpected-exception");
            Console.WriteLine("EXCEPTION " + error.GetType().FullName);
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
