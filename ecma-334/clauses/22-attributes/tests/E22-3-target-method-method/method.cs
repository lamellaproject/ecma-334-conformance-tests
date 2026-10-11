/*
Rules: E22-3-target-method-method; E22-3-attribute-on-class-member; E22-3-method-default; E22-3-method-method-target; E22-3-target-return-method; E22-3-method-return-target; E22-3-target-param-method-parameter; E22-3-attribute-on-formal-parameter; E22-3-form-attributes
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
    [Mark(1)] [method: Mark(2)] [return: Mark(3)]
    public int Work([param: Mark(4)] int value) { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var m = typeof(Item).GetMethod("Work");
        Check(Inspect.Has(m, 1), "method-default");
        Check(Inspect.Has(m, 2), "method-explicit");
        Check(Inspect.Has(m.ReturnParameter, 3), "method-return");
        Check(Inspect.Has(m.GetParameters()[0], 4), "method-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
