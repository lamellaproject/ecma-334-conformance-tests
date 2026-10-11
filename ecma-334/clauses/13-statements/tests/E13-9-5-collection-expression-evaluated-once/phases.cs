/*
Rules: E13-9-5-collection-expression-evaluated-once; E13-9-5-enumerator-acquisition; E13-9-5-movenext-controls-iteration; E13-9-5-value-iteration-current-read; E13-9-5-value-iteration-value-conversion; E13-9-5-value-iteration-initialization; E13-9-5-getenumerator-member-lookup; E13-9-5-current-member-lookup; E13-9-5-movenext-member-lookup; E13-9-5-pattern-collection-type; E13-9-5-pattern-enumerator-type; E13-9-5-pattern-iteration-type
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in Make())
Into: foreach (int item in (Make() == null ? Make() : Make()))
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    struct Element
    {
        public int Number;
        public static explicit operator int(Element element) { trace += "V"; return element.Number; }
    }
    class Source
    {
        public Cursor GetEnumerator() { trace += "G"; return new Cursor(); }
    }
    class Cursor : IDisposable
    {
        int position;
        public Element Current { get { trace += "C"; return new Element { Number = position + 7 }; } }
        public bool MoveNext() { trace += "M"; return ++position <= 2; }
        public void Dispose() { trace += "D"; }
    }
    static Source Make() { trace += "E"; return new Source(); }
    static void Main()
    {
        int total = 0;
        foreach (int item in Make()) { trace += "B"; total += item; }
        Check(total == 17, "converted-current-values");
        Check(trace == "EGMCVBMCVBMD", "expression-get-move-current-convert-body-dispose");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
