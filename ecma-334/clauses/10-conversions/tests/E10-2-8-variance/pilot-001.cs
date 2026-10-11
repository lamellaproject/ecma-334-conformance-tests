/*
Rules: E10-2-8-variance; E18-2-3-3-covariance; E18-2-3-3-contravariance
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: IOut<object> wide=narrow;
Into: IOut<object> wide=default(IOut<object>);
*/
using System;

interface IOut<out T> { T Read(); } class Words:IOut<string> { public string Read(){return "leaf";} } static class Trace {public static object Value; public static void Save(object x){Value=x;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IOut<string> narrow=new Words(); IOut<object> wide=narrow;
        Action<object> all=Trace.Save; Action<string> strings=all; strings("seed");
        Func<string> produce=()=>"leaf"; Func<object> covariant=produce;
        Check(ReferenceEquals(wide,narrow) && wide.Read().Equals("leaf") && Trace.Value.Equals("seed") && covariant().Equals("leaf"), "E10-2-8-variance-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
