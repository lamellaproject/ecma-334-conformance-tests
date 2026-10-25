/*
Rules: P09-conditional-preference
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: Pick(flag ? 22 : 67)
Into: Pick(flag ? (short)22 : (short)67)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(long value) { return 1; }
    static int Pick(short value) { return 2; }
    static int Select(bool flag) { return Pick(flag ? 22 : 67); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Select(true) == 1, "ordinary-int-to-long-before-short-target");
        Check(Select(false) == 1, "priority-independent-of-branch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
