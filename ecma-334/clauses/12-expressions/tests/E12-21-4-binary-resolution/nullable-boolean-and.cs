/*
Rules: E12-21-4-binary-resolution; E12-21-4-implicit-result-assignment; E12-21-4-evaluate-left-once; E12-13-5-predefined-and
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: local &= true;
Into: local &= false;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool? stored;
    static int gets, sets;
    static bool? Choice
    {
        get { gets++; return stored; }
        set { sets++; stored = value; }
    }
    static int Main()
    {
        bool? local = true;
        local &= true;
        Check(local == true, "nullable-local-compound-and");
        stored = null;
        Choice &= false;
        Check(stored == false && gets == 1 && sets == 1, "nullable-property-compound-and");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
