/*
Rules: E12-20-4-nongeneric-pattern; E12-20-4-alternative-delegate-types
Authority: ECMA-334 7th ed 12.20.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where item == 14
Into: where item == 15
*/
using System;
delegate bool Accept(int item);
delegate string Project(int item);
class Readout
{
    public string Text;
    public Readout(string text) { Text = text; }
}
class Gauge
{
    int value;
    bool active;
    public Gauge(int value, bool active) { this.value = value; this.active = active; }
    public Gauge Where(Accept predicate) { Program.trace += "W"; return new Gauge(value, active && predicate(value)); }
    public Readout Select(Project selector) { Program.trace += "S"; return new Readout(active ? selector(value) : "absent"); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Readout result = from item in new Gauge(14, true) where item == 14 select item > 10 ? "high" : "low";
        Check(result.Text == "high", "nongeneric-value");
        Check(trace == "WS", "nongeneric-methods");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
