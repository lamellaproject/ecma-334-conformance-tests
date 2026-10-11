/*
Rules: P15-closed15-interface
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 2
Mutate: ICode code=(ICode)root;
Into: ICode code=default(ICode);
*/
using System;

interface ICode{int Code{get;}}closed class Root{}sealed class Leaf:Root,ICode{public int Code=>823;}sealed class Other:Root{}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root root=new Leaf();ICode code=(ICode)root;Check(code.Code==823, "P15-closed15-interface-pilot-200001-check-01");root=new Other();try{code=(ICode)root;Check(false, "P15-closed15-interface-pilot-200001-check-02");}catch (InvalidCastException) { Check(true, "P15-closed15-interface-pilot-200001-check-02"); } catch (Exception error) { Check(false, "P15-closed15-interface-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
