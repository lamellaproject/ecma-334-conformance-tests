/*
Rules: P09-conditional-cast
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: decimal result=(decimal)(flag ? 0.1f : 0.2f);
Into: decimal result=default(decimal);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool flag=true; decimal result=(decimal)(flag ? 0.1f : 0.2f); Check(result==(decimal)0.1f, "P09-conditional-cast-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
