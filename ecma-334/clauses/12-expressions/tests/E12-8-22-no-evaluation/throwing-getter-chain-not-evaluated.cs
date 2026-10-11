/*
Rules: E12-8-22-no-evaluation
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: nameof(root.Next.Number)
Into: root.Next.Number + ""
*/
using System;
class Marker : Exception { }
class Root
{
    public static int Reads;
    public Root Next { get { Reads++; throw new Marker(); } }
    public int Number;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root root = new Root();
        string name = "";
        bool caught = false;
        try { name = nameof(root.Next.Number); }
        catch (Exception) { caught = true; }
        Check(!caught && Root.Reads == 0, "nameof-chain-has-no-runtime-evaluation");
        Check(name == "Number", "nameof-chain-final-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
