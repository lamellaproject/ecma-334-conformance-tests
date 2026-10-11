/*
Rules: E15-2-5-erase-nested; E15-2-5-erase-generic
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: {return x;}
Into: {return null;}
*/
using System;


class Outer<T> {public class Inner<U> {public int Number;} }
abstract class Origin<S> {public abstract Outer<object>.Inner<object> Cast<T>(T x) where T:S;}
class Erased:Origin<Outer<dynamic>.Inner<dynamic>> {public override Outer<object>.Inner<object> Cast<T>(T x) {return x;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var source=new Outer<object>.Inner<object> {Number=61};
        Check(new Erased().Cast(source).Number==61, "E15-2-5-erase-nested-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
