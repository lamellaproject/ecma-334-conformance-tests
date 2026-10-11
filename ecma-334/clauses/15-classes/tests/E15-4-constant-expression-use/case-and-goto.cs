/*
Rules: E15-4-constant-expression-use
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const int Stop = 211;
Into: public static readonly int Stop = 211;
*/
using System;
class Limits { public const int Stop = 211; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Route(int key)
    {
        switch (key)
        {
            case 0: goto case Limits.Stop;
            case Limits.Stop: return 223;
            default: return -1;
        }
    }
    static void Main()
    {
        Check(Route(211) == 223, "constant-case-label");
        Check(Route(0) == 223, "constant-goto-case");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
