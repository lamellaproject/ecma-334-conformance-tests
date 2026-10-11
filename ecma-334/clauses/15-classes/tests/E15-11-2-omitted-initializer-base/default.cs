/*
Rules: E15-11-2-omitted-initializer-base; E15-11-2-constructor-chaining-required
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Gauge() {
Into: public Gauge() : base(13) {
*/
using System;
class Basis { public Basis() { Program.Trace += "B"; } public Basis(int n) { Program.Trace += "I"; } }
class Gauge : Basis { public Gauge() { Program.Trace += "D"; } }
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(Trace == "BD", "omitted-initializer-calls-parameterless-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
