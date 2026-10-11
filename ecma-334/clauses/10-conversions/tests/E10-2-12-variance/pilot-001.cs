/*
Rules: E10-2-12-variance
Authority: ECMA-334 7th ed 10.2.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: IOut<object> box=Bridge.Cast(source);
Into: IOut<object> box=default(IOut<object>);
*/
using System;


interface IOut<out T> { T Read(); }
struct Payload:IOut<string> {public string Read(){return "seed";} }
static class Bridge {public static IOut<object> Cast<T>(T x) where T:IOut<string> {return x;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Payload source=new Payload(); IOut<object> box=Bridge.Cast(source);
        Check(box.Read().Equals("seed"), "E10-2-12-variance-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
