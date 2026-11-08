/*
Rules: E12-6-3-10-lower-array-interface
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return source[0];
Into: return default(T);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static T Enumerated<T>(System.Collections.Generic.IEnumerable<T> source)
    {
        foreach (T item in source) return item;
        return default(T);
    }
    static T Collected<T>(System.Collections.Generic.ICollection<T> source)
    {
        foreach (T item in source) return item;
        return default(T);
    }
    static T Listed<T>(System.Collections.Generic.IList<T> source) { return source[0]; }
    static int Main()
    {
        string[] source = new string[] { "cedar" };
        string a = Enumerated(source);
        string b = Collected(source);
        string c = Listed(source);
        Check(a == "cedar", "enumerable-element-inference");
        Check(b == "cedar", "collection-element-inference");
        Check(c == "cedar", "list-element-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
