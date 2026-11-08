/*
Rules: E18-6-5-all-members
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E18-6-5-all-members/struct-missing-member.cs.part
Mutate: struct Value : IRequired { }
Into: struct Value : IRequired { public int Read() { return 59; } }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    interface IRequired { int Read(); }
    struct Value : IRequired { }
    static int Main()
    {
        IRequired value = new Value();
        Check(value.Read() == 59, "struct-must-supply-interface-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
