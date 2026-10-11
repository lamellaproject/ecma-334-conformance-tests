/*
Rules: P09-conditional-preference
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: Choice.Pick(flag ? 31 : 37)
Into: Choice.Pick((short)(flag ? 31 : 37))
*/
using System;

static class Choice {public static int Pick(short x)=>1;public static int Pick(long x)=>2;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool flag=true; Check(Choice.Pick(flag ? 31 : 37)==2, "P09-conditional-preference-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
