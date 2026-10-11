/*
Rules: E7-4-5-object-no-base-class; E7-4-5-object-alias-members
Authority: ECMA-334 7th ed 7.4.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Type root = typeof(object);
Into: Type root = typeof(string);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type root = typeof(object);
        object value = new object();
        Check(root.BaseType == null, "object-has-no-base-class");
        Check(object.ReferenceEquals(value, value) && value.GetType() == typeof(System.Object), "object-alias-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
