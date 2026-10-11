/*
Rules: E13-10-5-anonymous-function-return-permitted; E13-10-5-anonymous-return-affects-conversions
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return 29;
Into: return 30;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    delegate long Wide();
    delegate void Action();
    static int visits;
    static void Main()
    {
        Wide lambda = () => { return 29; };
        Wide anonymous = delegate { return 31; };
        Action action = () => { visits++; return; };
        action();
        Check(lambda() == 29L, "lambda-return-implicit-widening");
        Check(anonymous() == 31L, "anonymous-method-return-conversion");
        Check(visits == 1, "anonymous-bare-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
