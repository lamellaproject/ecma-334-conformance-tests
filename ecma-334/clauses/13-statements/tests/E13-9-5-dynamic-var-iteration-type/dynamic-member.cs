/*
Rules: E13-9-5-dynamic-var-iteration-type; E13-9-5-dynamic-collection-type; E13-9-5-dynamic-enumerator-type
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (var item in collection)
Into: foreach (var item in (IEnumerable)collection)
*/
using System;
using System.Collections;
public class Element { public int Read() { return 29; } }
public class Source : IEnumerable
{
    public IEnumerator GetEnumerator() { throw new Exception(); }
    IEnumerator IEnumerable.GetEnumerator() { return new object[] { new Element() }.GetEnumerator(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(Element value) { return 1; }
    static int Select(object value) { return 2; }
    static void Main()
    {
        dynamic collection = new Source();
        int total = 0, choice = 0;
        foreach (var item in collection) { total += item.Read(); choice = Select(item); }
        Check(total == 29, "dynamic-var-allows-dynamic-member-call");
        Check(choice == 1, "dynamic-overload-uses-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
