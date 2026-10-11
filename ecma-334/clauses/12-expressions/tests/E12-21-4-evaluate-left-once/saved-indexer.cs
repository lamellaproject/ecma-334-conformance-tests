/*
Rules: E12-21-4-evaluate-left-once; E12-21-4-reuse-left-components; E12-21-4-implicit-result-assignment
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Receiver()[Index()] += Right()
Into: Receiver()[Index()] = Receiver()[Index()] + Right()
*/
using System;
class Storage
{
    public int Number, Key;
    public int this[int key]
    {
        get { Program.trace += "G"; return Number; }
        set { Program.trace += "S"; Number = value; Key = key; }
    }
}
class Program
{
    public static string trace = "";
    static Storage target = new Storage { Number = 8 }, decoy = new Storage(), current = target;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Storage Receiver() { trace += "E"; return current; }
    static int Index() { trace += "I"; return 2; }
    static int Right() { trace += "R"; current = decoy; return 7; }
    static void Main()
    {
        int result = (Receiver()[Index()] += Right());
        Check(target.Number == 15 && target.Key == 2 && decoy.Number == 0, "reuse-receiver-and-index");
        Check(result == 15, "compound-assignment-result");
        Check(trace == "EIGRS", "get-before-right-and-one-left-evaluation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
