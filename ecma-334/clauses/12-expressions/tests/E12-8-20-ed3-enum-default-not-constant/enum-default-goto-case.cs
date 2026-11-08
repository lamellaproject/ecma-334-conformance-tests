/*
Rules: E12-8-20-ed3-enum-default-not-constant
Authority: ECMA-334 3rd ed 14.5.14
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-8-20-ed3-enum-default-not-constant/enum-default-goto-case.cs.part
Mutate: goto case default(Gate);
Into: goto case (Gate)0;
*/
// ECMA-334 3rd ed 14.5.14, p. 185 (PDF p. 205).
using System;
enum Gate { Vacant, Marked = 29 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Read(Gate slot)
    {
        switch (slot)
        {
            case Gate.Marked: goto case default(Gate);
            case Gate.Vacant: return 37;
            default: return -9;
        }
    }
    static int Main()
    {
        Check(Read(Gate.Marked) == 37, "enum-zero-label");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
