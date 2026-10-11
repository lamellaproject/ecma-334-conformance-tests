/*
Rules: E22-3-explicit-event-default; E22-3-explicit-event-method-target; E22-3-explicit-event-param-target; E22-3-target-method-event-add-accessor; E22-3-target-method-event-remove-accessor; E22-3-target-param-event-add-accessor; E22-3-target-param-event-remove-accessor; E22-3-attribute-on-event-accessor
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: param: Mark(3)
Into: method: Mark(3)
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
// 22.3, p. 533: the associated method and lone parameter named by these targets
// exist only for an add or remove accessor, so the targets apply to the accessors.
delegate void Signal();
class Item
{
    public event Signal Changed
    {
        [Mark(1)] [method: Mark(2)] [param: Mark(3)] add { }
        [Mark(4)] [method: Mark(5)] [param: Mark(6)] remove { }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var e = typeof(Item).GetEvent("Changed");
        var add = e.GetAddMethod();
        var remove = e.GetRemoveMethod();
        Check(Inspect.Has(add, 1), "add-default");
        Check(Inspect.Has(add, 2), "add-method");
        Check(Inspect.Has(add.GetParameters()[0], 3), "add-value");
        Check(Inspect.Has(remove, 4), "remove-default");
        Check(Inspect.Has(remove, 5), "remove-method");
        Check(Inspect.Has(remove.GetParameters()[0], 6), "remove-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
