/*
Rules: E7-9-object-constructor-execution; E7-9-automatic-memory-management; E7-9-object-memory-allocation; E7-9-object-live-state
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Value = initial;
Into: Value = 0;
*/
using System;
class Token
{
    public static int Constructors;
    public int Value;
    public Token(int initial) { Constructors++; Value = initial; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token first = new Token(149), second = new Token(151);
        Check(Token.Constructors == 2, "each-new-object-runs-constructor");
        Check(first != second, "each-creation-has-distinct-object-storage");
        first.Value++;
        Check(first.Value == 150 && second.Value == 151, "allocated-instance-fields-have-independent-storage");
        GC.Collect();
        Check(first.Value == 150 && second.Value == 151, "new-live-objects-remain-accessible-after-collection-request");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
