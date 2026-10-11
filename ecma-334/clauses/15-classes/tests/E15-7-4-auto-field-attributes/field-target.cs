/*
Rules: E15-7-4-auto-field-attributes
Authority: ECMA-334 7th ed 15.7.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [field: Tag(21)]
Into: [property: Tag(21)]
*/
using System;
using System.Reflection;
class TagAttribute : Attribute { public int Code; public TagAttribute(int code) { Code = code; } }
class Box { [field: Tag(21)] public int Item { get; set; } = 34; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        FieldInfo tagged = null; int found = 0;
        foreach (FieldInfo field in typeof(Box).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            object[] tags = field.GetCustomAttributes(typeof(TagAttribute), false);
            if (tags.Length == 1 && ((TagAttribute)tags[0]).Code == 21) { tagged = field; found++; }
        }
        Box box = new Box();
        Check(found == 1 && tagged != null && (int)tagged.GetValue(box) == 34, "field-target-attribute-on-backing-storage");
        box.Item = 47;
        Check(tagged != null && (int)tagged.GetValue(box) == 47, "tagged-field-is-property-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
