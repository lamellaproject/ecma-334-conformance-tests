/*
Rules: E15-6-9-partial-parameter-attributes-combined; E15-6-9-partial-parameter-attribute-order; E15-6-9-partial-parameter-attribute-duplicates
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [Mark(31)]
Into: [Mark(37)]
*/
using System;
using System.Reflection;
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
class MarkAttribute : Attribute
{
    public int Code;
    public MarkAttribute(int code) { Code = code; }
}
partial class Gauge
{
    partial void Record([Mark(13), Mark(13)] int declared);
}
partial class Gauge
{
    partial void Record([Mark(31)] int used) { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        MethodInfo method = typeof(Gauge).GetMethod("Record", BindingFlags.Instance | BindingFlags.NonPublic);
        object[] attributes = method == null ? new object[0] : method.GetParameters()[0].GetCustomAttributes(typeof(MarkAttribute), false);
        int first = 0, second = 0, other = 0;
        foreach (object attribute in attributes)
        {
            int code = ((MarkAttribute)attribute).Code;
            if (code == 13) first++;
            else if (code == 31) second++;
            else other++;
        }
        Check(attributes.Length == 3, "partial-parameter-combines-corresponding-declarations-attributes");
        Check(first == 2, "partial-parameter-retains-duplicate-attributes");
        Check(second == 1 && other == 0, "partial-parameter-attribute-oracle-accepts-every-permutation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
