/*
Rules: P13-ref-interface-declare
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 1
Mutate: RefValue value=new RefValue(367);
Into: RefValue value=default(RefValue);
*/
using System;


interface ICode {int Code {get;}}
ref struct RefValue:ICode{public int Code{get;}public RefValue(int code){Code=code;}}
static class Reader{public static int Read<T>(T x) where T:ICode,allows ref struct =>x.Code;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        RefValue value=new RefValue(367);Check(Reader.Read(value)==367, "P13-ref-interface-declare-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
