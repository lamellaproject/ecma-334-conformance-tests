/*
Rules: E15-2-4-2-object-ultimate-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Token { }
Into: struct Token { }
*/
using System;
class Token { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token token = new Token();
        object value = token;
        Check(object.ReferenceEquals(value, token), "class-object-base-conversion-keeps-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
