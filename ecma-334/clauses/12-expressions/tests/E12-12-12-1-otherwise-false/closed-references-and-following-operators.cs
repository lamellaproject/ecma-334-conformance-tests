/*
Rules: E12-12-12-1-otherwise-false; E12-12-12-1-nullable-target; E12-12-12-1-runtime-check
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: boxed is int?
Into: boxed is long?
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
    class Branch { }
    class Lease : IDisposable { public void Dispose() { } }
    static int visits;
    static bool Visit() { visits++; return true; }
    static int Main()
    {
        string text = "elm";
        int[] array = new int[0];
        IDisposable resource = new Lease();
        Branch instance = new Branch();
        Check(!(text is int?), "closed-string-nullable-target");
        Check(!(array is int?), "closed-array-nullable-target");
        Check(!(resource is int?), "closed-interface-nullable-target");
        Check(!(instance is int?), "closed-class-nullable-target");
        Check((text is int? ? 13 : 17) == 17, "nullable-target-before-conditional");
        object boxed = 23;
        Check((array is int? | boxed is int?) == true, "nullable-target-before-bitwise-or");
        Check(!(resource is int? && Visit()) && visits == 0, "nullable-target-before-conditional-and");
        Check(instance is int? == false, "nullable-target-before-equality");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
