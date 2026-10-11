/*
Rules: E13-8-3-governing-expression-type
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: switch (selector)
Into: switch ((int)selector)
*/
using System;
class Token
{
    public static implicit operator int(Token value) { Program.conversions++; return 7; }
    public static implicit operator string(Token value) { Program.conversions++; return "token"; }
}
class Program
{
    public static int conversions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token selector = new Token();
        Token observed = null;
        switch (selector) { case Token value: observed = value; break; }
        Check(observed == selector, "multiple-conversions-leave-expression-type");
        Check(conversions == 0, "neither-ambiguous-conversion-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
