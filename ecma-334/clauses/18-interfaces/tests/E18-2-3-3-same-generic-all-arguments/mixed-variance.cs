/*
Rules: E18-2-3-3-same-generic-all-arguments; E18-2-3-1-add-parameter
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: interface IMap<in X, [Mark] out Y, Z>
Into: interface IMap<X, [Mark] out Y, Z>
*/
using System;
class MarkAttribute : Attribute { }
interface IMap<in X, [Mark] out Y, Z> { Y Map(X value, Z stamp); }
class Mapper : IMap<object, string, int>
{
    public string MapValue;
    public string Map(object value, int stamp) { MapValue = (string)value + stamp; return MapValue; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IMap<object, string, int> source = new Mapper();
        IMap<string, object, int> destination = source;
        Check((string)destination.Map("fir", 5) == "fir5", "all-argument-conditions");
        Check((object)source == (object)destination, "mixed-conversion-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
