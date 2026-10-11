/*
Rules: E15-4-constant-char
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const char Code = '\u03A9';
Into: public const char Code = '\u03AA';
*/
using System;
class Limits { public const char Code = '\u03A9'; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(char value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "char-constant-type");
        Check(Limits.Code == '\u03A9', "char-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
