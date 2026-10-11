/*
Rules: E22-3-target-method-property-get-accessor; E22-3-attribute-on-accessor; E22-3-getter-default; E22-3-getter-method-target; E22-3-getter-return-target; E22-3-target-return-property-get-accessor; E22-3-target-property-property
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return: Mark(3)
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
class Item
{
    [property: Mark(4)] public int Value
    {
        [Mark(1)] [method: Mark(2)] [return: Mark(3)] get { return 0; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var p = typeof(Item).GetProperty("Value");
        var m = p.GetGetMethod();
        Check(Inspect.Has(m, 1), "property-getter-default");
        Check(Inspect.Has(m, 2), "property-getter-method");
        Check(Inspect.Has(m.ReturnParameter, 3), "property-getter-return");
        Check(Inspect.Has(p, 4), "property-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
