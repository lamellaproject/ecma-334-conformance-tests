/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public T Value;
Into: public T Other;
*/
using System;
class Holder<T> { public T Value; public static T Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder<int>().Value == 0, "generic-value-type-instance-default");
        Check(new Holder<object>().Value == null, "generic-reference-type-instance-default");
        Check(Holder<int>.Global == 0, "generic-value-type-static-default");
        Check(Holder<object>.Global == null, "generic-reference-type-static-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
