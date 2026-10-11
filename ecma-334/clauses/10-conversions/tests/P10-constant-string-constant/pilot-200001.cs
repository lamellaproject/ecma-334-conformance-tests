/*
Rules: P10-constant-string-constant
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: object boxed=joined;
Into: object boxed=default(object);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const string part="basalt";const string joined=$"<{part}>";object boxed=joined;Check(joined=="<basalt>" && ReferenceEquals(boxed,joined), "P10-constant-string-constant-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
