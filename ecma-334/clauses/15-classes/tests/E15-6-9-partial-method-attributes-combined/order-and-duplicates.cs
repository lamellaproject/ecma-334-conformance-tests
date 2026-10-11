/*
Rules: E15-6-9-partial-method-attributes-combined; E15-6-9-partial-method-attribute-order; E15-6-9-partial-method-attribute-duplicates
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [Mark(29)]
Into: [Mark(47)]
*/
using System;
using System.Reflection;
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class MarkAttribute : Attribute
{
    public int Code;
    public MarkAttribute(int code) { Code = code; }
}
partial class Gauge
{
    [Mark(11), Mark(11)]
    partial void Record();
}
partial class Gauge
{
    [Mark(29)]
    partial void Record() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        MethodInfo method = typeof(Gauge).GetMethod("Record", BindingFlags.Instance | BindingFlags.NonPublic);
        object[] attributes = method == null ? new object[0] : method.GetCustomAttributes(typeof(MarkAttribute), false);
        int first = 0, second = 0, other = 0;
        foreach (object attribute in attributes)
        {
            int code = ((MarkAttribute)attribute).Code;
            if (code == 11) first++;
            else if (code == 29) second++;
            else other++;
        }
        Check(attributes.Length == 3, "partial-method-combines-both-declarations-attributes");
        Check(first == 2, "partial-method-retains-duplicate-attributes");
        Check(second == 1 && other == 0, "partial-method-attribute-oracle-accepts-every-permutation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
