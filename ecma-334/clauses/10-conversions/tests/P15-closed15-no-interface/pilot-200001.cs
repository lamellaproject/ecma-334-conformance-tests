/*
Rules: P15-closed15-no-interface
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 1
Mutate: IDisposable value=(IDisposable)root;
Into: IDisposable value=default(IDisposable);
*/
using System;

interface ICode{int Code{get;}}closed class Root{}sealed class Leaf:Root,ICode{public int Code=>823;}sealed class Other:Root{}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root root=new Leaf();try{IDisposable value=(IDisposable)root;Check(false, "P15-closed15-no-interface-pilot-200001-check-01");}catch (InvalidCastException) { Check(true, "P15-closed15-no-interface-pilot-200001-check-01"); } catch (Exception error) { Check(false, "P15-closed15-no-interface-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
