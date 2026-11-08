/*
Rules: E15-10-3-left-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Wheel item
Into: object item
*/
using System;
using Wheel = Dial;
class Dial { public static int operator <<(Wheel item, int count) { return count + 3; } }
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
        Dial item = new Dial();
        Check((item << 6) == 9, "aliased-containing-first-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
