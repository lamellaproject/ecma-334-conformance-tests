/*
Rules: E12-12-7-ed4-null-operand-equality
Authority: ECMA-334 4th ed 14.9.6
Version: ISO-2
Expected: run
Stdout: OK 8
Version-Witness: version-witnesses/E12-12-7-ed4-null-operand-equality/object-null-operands.cs.part
Mutate: Check(empty == null, "empty-right-equality");
Into: Check(empty != null, "empty-right-equality");
*/
// ECMA-334 4th ed 14.9.6, p. 209 (PDF p. 231).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object empty = null;
        object present = new object();
        Check(empty == null, "empty-right-equality");
        Check(null == empty, "empty-left-equality");
        Check(!(empty != null), "empty-right-inequality");
        Check(!(null != empty), "empty-left-inequality");
        Check(!(present == null), "present-right-equality");
        Check(!(null == present), "present-left-equality");
        Check(present != null, "present-right-inequality");
        Check(null != present, "present-left-inequality");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
