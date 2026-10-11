/*
Rules: E10-3-5-delegate; E10-3-5-variant-interface; E10-3-5-variant-delegate
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Action<object> restored=(Action<object>)strings;
Into: Action<object> restored=default(Action<object>);
*/
using System;

static class Trace {public static object Value; public static void Save(object x){Value=x;}} interface IOut<out T>{T Read();} class Words:IOut<string>{public string Read(){return "fruit";}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<string> original=()=>"seed"; Delegate root=original; ICloneable cloneable=original;
        Func<string> a=(Func<string>)root, b=(Func<string>)cloneable;
        Func<object> wide=original; Func<string> narrow=(Func<string>)wide;
        Action<object> all=Trace.Save; Action<string> strings=all; Action<object> restored=(Action<object>)strings;
        restored("leaf");
        Check(a()=="seed" && b()=="seed" && narrow()=="seed" && ReferenceEquals(original,narrow) && Trace.Value.Equals("leaf"), "E10-3-5-delegate-pilot-001-check-01");
        IOut<object> result=new Words(); IOut<string> down=(IOut<string>)result;
        Check(down.Read()=="fruit", "E10-3-5-delegate-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
