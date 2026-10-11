/*
Rules: E13-7-form-object-creation
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Token();
Into: ;
*/
using System;
class Token { public Token() { Program.created++; } }
class Program
{
    public static int created;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        new Token();
        Check(created == 1, "discarded-object-still-constructed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
