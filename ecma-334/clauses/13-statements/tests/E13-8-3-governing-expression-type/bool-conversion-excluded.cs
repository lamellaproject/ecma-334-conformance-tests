/*
Rules: E13-8-3-governing-expression-type
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: switch (selector)
Into: switch ((bool)selector)
*/
using System;
class Token
{
    public static implicit operator bool(Token value) { Program.conversions++; return true; }
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
        // bool is a listed expression type, but is absent from the user-conversion target list.
        switch (selector) { case Token value: observed = value; break; }
        Check(observed == selector, "bool-only-conversion-leaves-expression-type");
        Check(conversions == 0, "bool-conversion-not-invoked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
