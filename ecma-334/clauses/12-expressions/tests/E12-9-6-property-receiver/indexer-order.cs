/*
Rules: E12-9-6-property-receiver; E12-9-6-indexer-arguments; E12-9-6-property-get; E12-9-6-property-operand-conversion; E12-9-6-property-invocation; E12-9-6-property-result-conversion; E12-9-6-property-set; E12-9-6-property-result; E12-9-6-overload-resolution
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: ++Receiver()[Index()]
Into: Receiver()[Index()]++
*/
using System;
struct Counter
{
    public int Value;
    public static Counter operator ++(Counter c) { Program.Trace += "O"; c.Value += 3; return c; }
}
class Holder
{
    public Counter Stored;
    public int LastIndex;
    public Counter this[int index]
    {
        get { Program.Trace += "G"; LastIndex = index; return Stored; }
        set { Program.Trace += "S"; LastIndex = LastIndex * 10 + index; Stored = value; Stored.Value += 10; }
    }
}
class Program
{
    public static string Trace = "";
    static Holder holder = new Holder();
    static Holder Receiver() { Trace += "R"; return holder; }
    static int Index() { Trace += "I"; return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        holder.Stored.Value = 4; Counter result = ++Receiver()[Index()];
        Check(Trace == "RIGOS", "receiver-index-get-operator-set-once"); Check(holder.LastIndex == 22, "same-index-for-both-accessors");
        Check(holder.Stored.Value == 17, "setter-receives-new-value"); Check(result.Value == 7, "result-is-value-sent-to-setter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
