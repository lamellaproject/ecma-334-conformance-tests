/*
Rules: P11-intptr-alias
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: long y=x;
Into: long y=default(long);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.IntPtr x=227; long y=x; nint z=x; System.UIntPtr u=229U; ulong v=u; Check(y==227 && (long)z==227 && v==229, "P11-intptr-alias-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
