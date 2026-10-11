/*
Rules: E13-9-5-readonly-ref-iteration-initialization; E13-9-5-readonly-ref-iteration; E13-9-5-ref-current-variable-reference
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (ref readonly int item in source)
Into: foreach (int item in source)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        public int[] Values = new int[] { 8 };
        public Cursor GetEnumerator() { return new Cursor(Values); }
    }
    struct Cursor
    {
        int[] values;
        int index;
        public Cursor(int[] data) { values = data; index = -1; }
        public ref readonly int Current { get { return ref values[index]; } }
        public bool MoveNext() { return ++index < values.Length; }
    }
    static void Main()
    {
        Source source = new Source();
        foreach (ref readonly int item in source)
        {
            Check(item == 8, "initial-readonly-reference");
            source.Values[0] = 51;
            Check(item == 51, "readonly-reference-still-aliases-element");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
