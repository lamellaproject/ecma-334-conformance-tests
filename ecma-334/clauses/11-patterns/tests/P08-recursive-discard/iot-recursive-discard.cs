/*
Rules: P08-recursive-discard
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: (23, _)
Into: (23, 41)
*/
using System;
class Program
{
    static int checks, failures;
    static bool Matches((int, object) pair) { return pair is (23, _); }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int _ = 101;
        Check(Matches((23, null)), "discard-null");
        Check(Matches((23, new object())), "discard-object");
        Check(_ == 101, "discard-no-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
