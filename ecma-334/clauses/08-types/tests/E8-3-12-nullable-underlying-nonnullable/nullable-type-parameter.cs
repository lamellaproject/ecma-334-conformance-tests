/*
Rules: E8-3-12-nullable-underlying-nonnullable; E8-3-12-nonnullable-definition
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new T?(input)
Into: new T?()
*/
using System;
struct Token { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T? Wrap<T>(T input) where T : struct { return new T?(input); }
    static void Main()
    {
        Token token = new Token(); token.Value = 52;
        Check(Wrap(token).Value.Value == 52, "nullable-nonnullable-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
