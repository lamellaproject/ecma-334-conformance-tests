/*
Rules: E22-3-target-method-indexer-set-accessor; E22-3-setter-default; E22-3-setter-method-target; E22-3-setter-param-target; E22-3-target-param-indexer-set-accessor
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 3
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
class Item
{
    public int this[int index]
    {
        [Mark(1)] [method: Mark(2)] [param: Mark(3)] set { }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var m = typeof(Item).GetProperty("Item").GetSetMethod();
        var p = m.GetParameters();
        Check(Inspect.Has(m, 1), "indexer-setter-default");
        Check(Inspect.Has(m, 2), "indexer-setter-method");
        Check(Inspect.Has(p[p.Length - 1], 3), "indexer-value-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
