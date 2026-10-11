/*
Rules: E15-2-3-parameter-placeholder; E15-2-3-argument-substitution; E15-2-3-parameter-declaration-space
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public T Value;
Into: public object Value;
*/
using System;
class T { }
class Token { }
class Packet<T> { public T Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet<int> numbers = new Packet<int>();
        numbers.Value = 167;
        int number = numbers.Value;
        Token token = new Token();
        Packet<Token> references = new Packet<Token>();
        references.Value = token;
        Token copied = references.Value;
        Check(number == 167, "type-argument-substitutes-parameter-not-global-name");
        Check(copied == token, "reference-type-argument-substitution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
