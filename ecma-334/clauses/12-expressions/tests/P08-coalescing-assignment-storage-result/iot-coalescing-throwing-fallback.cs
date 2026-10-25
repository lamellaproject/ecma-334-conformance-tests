/*
Rules: P08-coalescing-assignment-storage-result
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: cell.Value ??= Throw()
Into: (cell.Value = null) ?? Throw()
*/
using System;

class Fault : Exception { }
class Cell
{
    public object Stored;
    public int Gets, Sets;
    public object Value
    {
        get { Gets++; return Stored; }
        set { Sets++; Stored = value; }
    }
}
class Program
{
    static int checks, failures, throws;
    static object Throw() { throws++; throw new Fault(); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Cell cell = new Cell();
        int exceptions = 0;
        try { object ignored = (cell.Value ??= Throw()); }
        catch (Fault) { exceptions++; }
        Check(exceptions == 1 && throws == 1, "throwing-fallback-propagates-once");
        Check(cell.Gets == 1, "target-read-before-throwing-fallback");
        Check(cell.Sets == 0, "throwing-fallback-does-not-invoke-setter");
        Check(cell.Stored == null, "throwing-fallback-preserves-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
