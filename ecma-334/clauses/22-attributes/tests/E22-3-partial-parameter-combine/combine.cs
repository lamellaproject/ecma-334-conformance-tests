/*
Rules: E22-3-partial-parameter-combine; E22-3-partial-parameter-order
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [Mark(2)]
Into: [Mark(3)]
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
partial class Item<[Mark(1)] T> { }
partial class Item<[Mark(2)] T> { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var owner = typeof(Item<>).GetGenericArguments()[0];
        Check(Inspect.Has(owner, 1), "first-part");
        Check(Inspect.Has(owner, 2), "second-part");
        Check(owner.GetCustomAttributes(typeof(MarkAttribute), false).Length == 2, "combined-count");
        // Attribute enumeration order is unspecified; both permutations are accepted.
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
