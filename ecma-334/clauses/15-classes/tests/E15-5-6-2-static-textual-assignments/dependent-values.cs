/*
Rules: E15-5-6-2-static-textual-assignments
Authority: ECMA-334 7th ed 15.5.6.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int Left = 11; public static int Right = Left + 5;
Into: public static int Right = Left + 5; public static int Left = 11;
*/
using System;
class Holder
{
    public static int Left = 11; public static int Right = Left + 5;
    public static int Total = Left + Right;
    static Holder() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Left == 11, "first-static-assignment");
        Check(Holder.Right == 16, "later-static-assignment-observes-earlier-value");
        Check(Holder.Total == 27, "last-static-assignment-observes-both-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
