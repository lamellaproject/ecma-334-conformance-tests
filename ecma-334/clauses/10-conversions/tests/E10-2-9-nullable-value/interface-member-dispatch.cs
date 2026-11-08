/*
Rules: E10-2-9-nullable-value; E10-2-9-nullable
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: IComparable boxed = present;
Into: IComparable boxed = (int?)32;
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
    static int Main()
    {
        int? present = 31;
        IComparable boxed = present;
        Check(boxed.CompareTo(present) == 0, "nullable-box-interface-equal-call");
        Check(boxed.CompareTo((int?)37) < 0, "nullable-box-interface-ordered-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
