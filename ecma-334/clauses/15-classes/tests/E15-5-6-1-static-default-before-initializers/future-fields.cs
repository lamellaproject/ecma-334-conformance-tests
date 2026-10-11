/*
Rules: E15-5-6-1-static-default-before-initializers; E15-5-6-1-observe-default-static-field
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public static int EarlyNumber = ReadNumber();
Into: public static int EarlyNumber = LaterNumber = 29;
*/
using System;
class Holder
{
    public static int EarlyNumber = ReadNumber();
    public static object EarlyOwner = ReadOwner();
    public static bool EarlyReady = ReadReady();
    public static int LaterNumber = 29;
    public static object LaterOwner = new object();
    public static bool LaterReady = true;
    static int ReadNumber() { return LaterNumber; }
    static object ReadOwner() { return LaterOwner; }
    static bool ReadReady() { return LaterReady; }
    static Holder() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.EarlyNumber == 0, "later-initialized-number-starts-default");
        Check(Holder.EarlyOwner == null, "later-initialized-reference-starts-default");
        Check(!Holder.EarlyReady, "later-initialized-bool-starts-default");
        Check(Holder.LaterNumber == 29, "number-initializer-follows-default-initialization");
        Check(Holder.LaterOwner != null, "reference-initializer-follows-default-initialization");
        Check(Holder.LaterReady, "bool-initializer-follows-default-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
