/*
Rules: E9-4-4-7-unguarded-pattern-transfer
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case int pattern: return pattern;
Into: case int pattern: return 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(object source)
    {
        switch (source) { case int pattern: return pattern; default: return -1; }
    }
    static void Main()
    {
        Check(Read(67) == 67, "pattern-variable-assigned-on-unguarded-entry");
        Check(Read("other") == -1, "nonmatching-pattern");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
