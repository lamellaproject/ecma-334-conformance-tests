/*
Rules: E12-12-12-ed5-method-group-false
Authority: ECMA-334 5th ed 12.11.11
Version: 5
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E12-12-12-ed5-method-group-false/unconverted-method.cs.part
Mutate: Step is object
Into: new D(Step) is object
*/
// ECMA-334 5th ed 12.11.11, p. 186 (PDF p. 208).
using System;
delegate int D();
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Step() { calls++; return 29; }
    static int Main()
    {
        bool matched = Step is object;
        Check(!matched && calls == 0, "unconverted-method-group");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
