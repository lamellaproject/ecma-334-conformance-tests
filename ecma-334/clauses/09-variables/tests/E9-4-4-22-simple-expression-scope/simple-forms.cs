/*
Rules: E9-4-4-22-simple-expression-scope; E9-4-4-22-simple-expression-transfer
Authority: ECMA-334 7th ed 9.4.4.22
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: int cell = 91;
Into: int cell;
*/
using System;
class Parent { protected int Token = 17; }
class Program : Parent
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Fill(out int value) { value = 43; }
    void Probe()
    {
        int cell = 91;
        int literal = 12;
        Check(literal == 12 && cell == 91, "literal-preserves-state");
        int simple = cell;
        Check(simple == 91 && cell == 91, "simple-name-preserves-state");
        int member = this.Token;
        Check(member == 17 && cell == 91, "member-access-preserves-state");
        int inherited = base.Token;
        Check(inherited == 17 && cell == 91, "nonindexed-base-access-preserves-state");
        Type type = typeof(int);
        Check(type == typeof(int) && cell == 91, "typeof-preserves-state");
        int zero = default(int);
        Check(zero == 0 && cell == 91, "default-preserves-state");
        string name = nameof(cell);
        Check(name == "cell" && cell == 91, "nameof-preserves-state");
        Fill(out int declared);
        Check(declared == 43 && cell == 91, "declaration-expression-preserves-other-variable-state");
    }
    static void Main()
    {
        new Program().Probe();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
