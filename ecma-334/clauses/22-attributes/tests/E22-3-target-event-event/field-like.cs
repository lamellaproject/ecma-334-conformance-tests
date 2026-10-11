/*
Rules: E22-3-target-event-event; E22-3-field-like-event-default; E22-3-field-like-event-event-target; E22-3-target-field-field-like-event-without-accessors; E22-3-field-like-event-field-target; E22-3-target-method-field-like-event-without-accessors; E22-3-field-like-event-method-target
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: field: Mark(3)
Into: event: Mark(3)
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
delegate void Signal();
class Item { [Mark(1)] [event: Mark(2)] [field: Mark(3)] [method: Mark(4)] public event Signal Changed; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var e = typeof(Item).GetEvent("Changed");
        Check(Inspect.Has(e, 1), "event-default");
        Check(Inspect.Has(e, 2), "event-explicit");
        Check(Inspect.Fields(typeof(Item), 3) == 1, "event-backing-field");
        Check(Inspect.Has(e.GetAddMethod(), 4), "event-add-method");
        Check(Inspect.Has(e.GetRemoveMethod(), 4), "event-remove-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
