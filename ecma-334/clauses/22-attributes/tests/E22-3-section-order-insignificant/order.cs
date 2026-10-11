/*
Rules: E22-3-section-order-insignificant; E22-3-attribute-order-insignificant
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Mark(2), Mark(1)]
Into: [Mark(3), Mark(1)]
*/
using System;
class Inspect
{
    public static bool Has(System.Reflection.ICustomAttributeProvider owner, int id)
    {
        object[] values = owner.GetCustomAttributes(typeof(MarkAttribute), false);
        foreach (object value in values) if (((MarkAttribute)value).Id == id) return true;
        return false;
    }
    public static int Fields(Type type, int id)
    {
        int count = 0;
        foreach (System.Reflection.FieldInfo field in type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static))
            if (Has(field, id)) count++;
        return count;
    }
}
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
class MarkAttribute : Attribute { public int Id; public MarkAttribute(int id) { Id = id; } }
[Mark(1)] [Mark(2)] class First { }
[Mark(2)] [Mark(1)] class Second { }
[Mark(1), Mark(2)] class Third { }
[Mark(2), Mark(1)] class Fourth { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Inspect.Has(typeof(First), 1) && Inspect.Has(typeof(First), 2), "sections-forward");
        Check(Inspect.Has(typeof(Second), 1) && Inspect.Has(typeof(Second), 2), "sections-reverse");
        Check(Inspect.Has(typeof(Third), 1) && Inspect.Has(typeof(Third), 2), "list-forward");
        Check(Inspect.Has(typeof(Fourth), 1) && Inspect.Has(typeof(Fourth), 2), "list-reverse");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
