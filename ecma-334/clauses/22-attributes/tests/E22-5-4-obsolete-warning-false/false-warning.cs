/*
Rules: E22-5-4-obsolete-warning-false
Authority: ECMA-334 7th ed 22.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: [Obsolete("deprecated", false)]
Into: 
*/
using System;
class Token
{
    [Obsolete("deprecated", false)]
    public static int Read() { return 17; }
}
class Program
{
    static int checks, failures;
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int value = Token.Read();
        Check(value == 17, "obsolete-call-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
