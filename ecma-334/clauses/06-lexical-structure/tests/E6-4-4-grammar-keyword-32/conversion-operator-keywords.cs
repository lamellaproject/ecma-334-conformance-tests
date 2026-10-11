/*
Rules: E6-4-4-grammar-keyword-32; E6-4-4-grammar-keyword-22; E6-4-4-grammar-keyword-44
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: implicit operator Token
Into: explicit operator Token
*/
using System;
struct Token
{
    public int Number;
    public static implicit operator Token(int input) { return new Token { Number = input }; }
    public static explicit operator int(Token input) { return input.Number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token item = 61;
        Check((int)item == 61, "implicit-and-explicit-operators");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
