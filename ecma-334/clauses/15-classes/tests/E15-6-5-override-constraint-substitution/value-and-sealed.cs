/*
Rules: E15-6-5-override-constraint-substitution
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class IntLeaf : Root<int>
Into: class IntLeaf : Root<long>
*/
using System;
sealed class Token { public int Value = 223; }
class Root<U> { public virtual T Echo<T>(T value) where T : U { return value; } }
class IntLeaf : Root<int> { public override T Echo<T>(T value) { return value; } }
class TokenLeaf : Root<Token> { public override T Echo<T>(T value) { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new IntLeaf().Echo<int>(227) == 227, "inherited-constraint-substitution-permits-value-type-bound");
        Token value = new Token();
        Check(new TokenLeaf().Echo<Token>(value) == value && value.Value == 223, "inherited-constraint-substitution-permits-sealed-type-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
