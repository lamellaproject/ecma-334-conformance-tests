/*
Rules: P13-collection13-element
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 1
Mutate: byte[] spread=new byte[]{31,37};
Into: byte[] spread=default(byte[]);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
static class Pick{public static int Read(List<byte> x)=>1;public static int Read(List<int> x)=>2;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte[] spread=new byte[]{31,37}; Check(Pick.Read([..spread])==1, "P13-collection13-element-pilot-200002-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
