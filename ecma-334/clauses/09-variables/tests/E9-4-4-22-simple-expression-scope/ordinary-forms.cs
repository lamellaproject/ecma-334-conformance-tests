/*
Rules: E9-4-4-22-simple-expression-scope; E9-4-4-22-simple-expression-transfer
Authority: ECMA-334 7th ed 9.4.4.22
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: int marker = Seed();
Into: int marker;
*/
using System;
class BaseToken { protected int Token = 38; }
class Program : BaseToken
{
    static int checks, failures, sequence;
    static int Seed() { return ++sequence + 66; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    void Observe()
    {
        int marker = Seed();
        int literal = 14;
        Check(literal == 14 && marker == 67, "literal-state");
        int named = marker;
        Check(named == 67 && marker == 67, "name-state");
        int member = this.Token;
        Check(member == 38 && marker == 67, "member-state");
        int inherited = base.Token;
        Check(inherited == 38 && marker == 67, "base-state");
        Type kind = typeof(BaseToken);
        Check(kind == typeof(BaseToken) && marker == 67, "typeof-state");
        long zero = default(long);
        Check(zero == 0L && marker == 67, "default-state");
    }
    static void Main()
    {
        new Program().Observe();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
