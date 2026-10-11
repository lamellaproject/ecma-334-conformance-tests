/*
Rules: E22-1-retrieve-attributes; E22-2-1-attribute-class; E22-4-1-runtime-representation; E22-4-1-instance-class; E22-4-1-instance-initialization; E22-4-2-metadata-class; E22-4-2-metadata-positional; E22-4-2-metadata-named; E22-4-2-metadata-entity; E22-4-3-runtime-result
Authority: ECMA-334 7th ed 22.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: [Memo(17, Note = "ink")]
Into: [Memo(18, Note = "ink")]
*/
using System;
class BaseMemo : Attribute { }
class MemoAttribute : BaseMemo
{
    public int Number;
    public string Note;
    public MemoAttribute(int number) { Number = number; }
}
[Memo(17, Note = "ink")] class Marked { }
class Bare { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Attribute found = Attribute.GetCustomAttribute(typeof(Marked), typeof(MemoAttribute));
        Check(found is MemoAttribute, "derived-attribute-instance");
        MemoAttribute value = (MemoAttribute)found;
        Check(value.Number == 17, "positional-value");
        Check(value.Note == "ink", "named-value");
        Check(Attribute.GetCustomAttribute(typeof(Bare), typeof(MemoAttribute)) == null, "entity-association");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
