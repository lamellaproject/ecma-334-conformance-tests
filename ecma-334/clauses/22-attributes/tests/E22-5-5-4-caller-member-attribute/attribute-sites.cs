/*
Rules: E22-5-5-4-caller-member-attribute
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Name] public int Work
Into: [Name("explicit")] public int Work
*/
using System;
class NameAttribute : Attribute
{
    public string Value;
    public NameAttribute([System.Runtime.CompilerServices.CallerMemberName] string value = null) { Value = value; }
}
class Item
{
    [return: Name] [Name] public int Work([Name] int value) { return value; }
    public void Generic<[Name] T>() { }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var method = typeof(Item).GetMethod("Work");
        Check(((NameAttribute)Attribute.GetCustomAttribute(method, typeof(NameAttribute))).Value == "Work", "member-attribute-name");
        Check(((NameAttribute)Attribute.GetCustomAttribute(method.ReturnParameter, typeof(NameAttribute))).Value == "Work", "return-attribute-name");
        Check(((NameAttribute)Attribute.GetCustomAttribute(method.GetParameters()[0], typeof(NameAttribute))).Value == "Work", "parameter-attribute-name");
        Check(((NameAttribute)Attribute.GetCustomAttribute(typeof(Item).GetMethod("Generic").GetGenericArguments()[0], typeof(NameAttribute))).Value == "Generic", "type-parameter-attribute-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
