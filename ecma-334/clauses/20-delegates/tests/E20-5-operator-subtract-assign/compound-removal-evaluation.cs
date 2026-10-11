/*
Rules: E20-5-operator-subtract-assign
Authority: ECMA-334 7th ed 20.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: GetHolder().Value -= GetDelegate();
Into: GetHolder().Value += GetDelegate();
*/
using System;
delegate void Notice();
class Holder
{
    Notice stored;
    public Holder(Notice value) { stored = value; }
    public Notice Value { get { Program.Trace += "G"; return stored; } set { Program.Trace += "S"; stored = value; } }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static int holders, arguments;
    static Holder holder = new Holder((Notice)A + B);
    static void A() { Trace += "A"; }
    static void B() { Trace += "B"; }
    static Holder GetHolder() { holders++; Trace += "L"; return holder; }
    static Notice GetDelegate() { arguments++; Trace += "R"; return B; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        GetHolder().Value -= GetDelegate();
        Check(Trace == "LGRS", "compound-remove-evaluation-order");
        Check(holders == 1 && arguments == 1, "compound-remove-operands-once");
        Trace = "";
        holder.Value();
        Check(Trace == "GA", "compound-remove-stores-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
