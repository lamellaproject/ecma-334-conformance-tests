/*
Rules: E12-8-5-evaluation; E12-8-5-syntax; E12-8-5-result
Authority: ECMA-334 7th ed 12.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return value * 3;
Into: return value * 4;
*/
using System;
delegate int Scaler(int value);
class Program
{
    static int checks, failures;
    static int Scale(int value) { return value * 3; }
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        Scaler action = new Scaler((Scale));
        Check(action(14) == 42, "parenthesized-method-group-in-delegate-construction");
        Check(((Scale))(9) == 27, "nested-parentheses-preserve-invocable-method-group");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
