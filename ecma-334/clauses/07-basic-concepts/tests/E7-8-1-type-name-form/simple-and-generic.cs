/*
Rules: E7-8-1-type-name-form; E7-8-1-type-name-definition; E7-8-1-name-form-identifier; E7-8-1-omitted-type-argument-count; E7-8-2-unqualified-name-existence; E7-8-2-nongeneric-unqualified-name; E7-8-2-generic-unqualified-name
Authority: ECMA-334 7th ed 7.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Token plain = new Token();
Into: Token<int> plain = new Token<int>();
*/
using System;
class Token { public int Value = 19; }
class Token<T> { public int Value = 23; }
class Token<T, U> { public int Value = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token plain = new Token();
        Check(plain.Value == 19, "omitted-arguments-select-zero-arity-type");
        Check(new Token<int>().Value == 23, "one-argument-selects-one-arity-type");
        Check(new Token<int, int>().Value == 29, "two-arguments-select-two-arity-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
