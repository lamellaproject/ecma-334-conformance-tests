/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public int Number;
Into: public int Number = 7;
*/
using System;
class Holder
{
    public int Number;
    public bool Ready;
    public char Mark;
    public static int GlobalNumber;
    public static bool GlobalReady;
    public static char GlobalMark;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Number == 0, "instance-int-default");
        Check(!value.Ready, "instance-bool-default");
        Check(value.Mark == '\0', "instance-char-default");
        Check(Holder.GlobalNumber == 0, "static-int-default");
        Check(!Holder.GlobalReady, "static-bool-default");
        Check(Holder.GlobalMark == '\0', "static-char-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
