/*
Rules: E16-3-member-constant; E16-3-class-member-rules
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Limit = 89;
Into: public static readonly int Limit = 89;
*/
using System;
struct Entry { public const int Limit = 89; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int saved = Entry.Limit;
        Check(saved == 89, "struct-constant-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
