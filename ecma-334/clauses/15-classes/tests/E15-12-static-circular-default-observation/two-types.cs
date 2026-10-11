/*
Rules: E15-12-static-circular-default-observation
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int Seen = Right.Value; public static int Value = 13;
Into: public static int Value = 13; public static int Seen = Right.Value;
*/
using System;
class Left { public static int Seen = Right.Value; public static int Value = 13; static Left() { Program.Trace += "L"; } }
class Right { public static int During = Left.Value; public static int Value = 19; static Right() { Program.Trace += "R"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = Left.Seen;
        Check(first == 19 && Left.Value == 13, "outer-circular-initialization-completes");
        Check(Right.During == 0 && Right.Value == 19, "cycle-observes-outer-field-default");
        Check(Trace == "RL", "nested-static-constructor-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
