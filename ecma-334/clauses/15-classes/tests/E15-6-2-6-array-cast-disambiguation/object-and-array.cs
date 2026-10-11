/*
Rules: E15-6-2-6-array-cast-disambiguation; E15-6-2-6-object-array-object-conversion; E15-6-2-6-array-null-argument; E15-6-2-6-array-expanded-only-without-normal
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Echo((object)source)
Into: Echo((object[])source)
*/
using System;
class Token { }
class Program
{
    static object[] Echo(params object[] values) { return values; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] source = new object[] { new Token(), new Token() };
        Check(Echo(source) == source, "applicable-normal-form-preserves-array-argument");
        object[] wrapped = Echo((object)source);
        Check(wrapped.Length == 1 && wrapped[0] == source, "object-cast-selects-single-expanded-element");
        object converted = source;
        object[] implicitWrapped = Echo(converted);
        Check(implicitWrapped.Length == 1 && implicitWrapped[0] == source, "implicit-array-to-object-conversion-retains-reference");
        Check(Echo(null) == null, "untyped-null-uses-applicable-normal-form");
        Check(Echo((object[])null) == null, "array-cast-null-is-normal-argument");
        object[] nullElement = Echo((object)null);
        Check(nullElement.Length == 1 && nullElement[0] == null, "object-cast-null-is-expanded-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
