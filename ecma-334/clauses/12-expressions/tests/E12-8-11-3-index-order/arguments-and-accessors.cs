/*
Rules: E12-8-11-3-index-order; E12-8-11-3-assignment-set; E12-8-11-3-other-get; E12-8-11-3-associated-instance; E12-8-11-3-associated-arguments
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int result = Fetch()[First(), Second()];
Into: int result = Fetch()[Second(), First()];
*/
using System;
class Cell
{
    public int stored;
    public int this[int first, int second]
    {
        get { Program.trace += "G"; return first * 10 + second; }
        set { Program.trace += "S"; stored = value + first * 10 + second; }
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static Cell receiver = new Cell();
    static Cell Fetch() { trace += "P"; return receiver; }
    static int First() { trace += "A"; return 1; }
    static int Second() { trace += "B"; return 2; }
    static int Value() { trace += "V"; return 31; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Fetch()[First(), Second()];
        Check(result == 12 && trace == "PABG", "getter-after-receiver-and-left-to-right-indices");
        trace = "";
        Fetch()[First(), Second()] = Value();
        Check(trace == "PABVS", "setter-after-indices-and-right-hand-value-without-getter");
        Check(receiver.stored == 43, "setter-gets-associated-index-arguments-and-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
