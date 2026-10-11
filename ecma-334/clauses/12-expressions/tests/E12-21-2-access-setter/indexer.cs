/*
Rules: E12-21-2-access-setter; E12-21-2-access-result; E12-21-2-access-evaluate-right; E12-21-2-access-assignment-type
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Receiver()[Index()] = Right()
Into: Receiver()[Index() + 1] = Right()
*/
using System;
class Storage
{
    public int Key, Stored;
    public int this[int key] { set { Program.trace += "S"; Key = key; Stored = value + 50; } }
}
class Program
{
    public static string trace = "";
    static Storage target = new Storage(), decoy = new Storage(), current = target;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Storage Receiver() { trace += "E"; return current; }
    static int Index() { trace += "I"; return 3; }
    static int Right() { trace += "R"; current = decoy; return 18; }
    static void Main()
    {
        var result = (Receiver()[Index()] = Right());
        Check(target.Key == 3 && target.Stored == 68 && decoy.Stored == 0, "saved-indexer-components");
        Check(result == 18, "indexer-assignment-result");
        Check(trace == "EIRS", "indexer-evaluation-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
