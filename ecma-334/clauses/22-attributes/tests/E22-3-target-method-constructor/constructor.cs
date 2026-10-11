/*
Rules: E22-3-target-method-constructor; E22-3-target-param-constructor-parameter
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: method: Mark(1)
Into: method: Mark(2)
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
class Item { [method: Mark(1)] public Item([param: Mark(3)] int value) { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var c = typeof(Item).GetConstructors()[0];
        Check(Inspect.Has(c, 1), "constructor-method");
        Check(Inspect.Has(c.GetParameters()[0], 3), "constructor-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
