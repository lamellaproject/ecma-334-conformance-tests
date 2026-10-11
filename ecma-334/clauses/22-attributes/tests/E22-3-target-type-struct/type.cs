/*
Rules: E22-3-target-type-struct; E22-3-attribute-on-type-declaration; E22-3-other-context-explicit-target
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [type: Mark(1), Mark(2),]
Into: [type: Mark(4), Mark(2),]
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
[type: Mark(1), Mark(2),]
struct Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Inspect.Has(typeof(Item), 1), "struct-explicit-type");
        Check(Inspect.Has(typeof(Item), 2), "struct-second-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
