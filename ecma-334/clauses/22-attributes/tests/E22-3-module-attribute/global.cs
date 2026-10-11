/*
Rules: E22-3-module-attribute; E22-3-module-target; E22-3-form-global-section; E22-3-form-global-section-comma; E22-3-form-global-target-specifier; E22-3-form-global-target
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [module: Mark(31),]
Into: [assembly: Mark(31),]
*/
using System;
[module: Mark(31),]
[module: Mark(32)]
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
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Inspect.Has(typeof(Program).Module, 31), "module-target-first");
        Check(Inspect.Has(typeof(Program).Module, 32), "module-target-second");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
