/*
Rules: E15-6-11-void-block-normal-completion; E15-6-11-effective-return-void
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: void Add() { trace += "m"; }
Into: void Add() { trace += "x"; }
*/
using System;
class Program
{
    static string trace = "";
    static void Add() { trace += "m"; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { trace += "a"; Add(); trace += "z"; Check(trace == "amz", "normal-void-return"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
