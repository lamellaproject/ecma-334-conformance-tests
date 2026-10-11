/*
Rules: E15-2-5-erase-array; E15-2-5-erase-generic
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: {return x;}
Into: {return null;}
*/
using System;


class Holder<T> {public T Value;}
abstract class Origin<S> {public abstract Holder<object[]> Cast<T>(T x) where T:S;}
class Erased:Origin<Holder<dynamic[]>> {public override Holder<object[]> Cast<T>(T x) {return x;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var source=new Holder<object[]> {Value=new object[]{"seed"}};
        Check(new Erased().Cast(source).Value[0].Equals("seed"), "E15-2-5-erase-array-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
