/*
Rules: E22-5-5-4-caller-member-indexer-renamed
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
class Caller
{
    public static string Name([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return name; }
}
class Holder { [System.Runtime.CompilerServices.IndexerName("Entry")] public string this[int key] { get { return Caller.Name(); } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder()[3] == "Entry", "indexer-member-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
