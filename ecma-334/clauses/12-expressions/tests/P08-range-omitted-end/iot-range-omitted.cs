/*
Rules: P08-range-omitted-end; P08-range-omitted-start
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 6
Mutate: Range suffix = ^3..;
Into: Range suffix = ^3..^1;
*/
using System;
class Test
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Range suffix = ^3..;
        Range prefix = ..5;
        Range all = ..;
        Check(suffix.Start.Value == 3 && suffix.Start.IsFromEnd, "suffix-explicit-start");
        Check(suffix.End.Value == 0 && suffix.End.IsFromEnd, "omitted-end-is-past-end");
        Check(prefix.Start.Value == 0 && !prefix.Start.IsFromEnd, "omitted-start-is-from-start-zero");
        Check(prefix.End.Value == 5 && !prefix.End.IsFromEnd, "prefix-explicit-end");
        Check(all.Start.Value == 0 && !all.Start.IsFromEnd, "all-start");
        Check(all.End.Value == 0 && all.End.IsFromEnd, "all-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
