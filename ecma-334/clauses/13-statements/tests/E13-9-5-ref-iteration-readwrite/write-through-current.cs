/*
Rules: E13-9-5-ref-iteration-readwrite; E13-9-5-ref-iteration-initialization; E13-9-5-ref-current-permitted; E13-9-5-ref-current-variable-reference
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (ref int item in source) { item += 10; }
Into: foreach (int element in source) { int item = element; item += 10; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source
    {
        public int[] Values = new int[] { 4, 6 };
        public Cursor GetEnumerator() { return new Cursor(Values); }
    }
    struct Cursor
    {
        int[] values;
        int index;
        public Cursor(int[] data) { values = data; index = -1; }
        public ref int Current { get { return ref values[index]; } }
        public bool MoveNext() { return ++index < values.Length; }
    }
    static void Main()
    {
        Source source = new Source();
        foreach (ref int item in source) { item += 10; }
        Check(source.Values[0] == 14, "first-element-written-through-reference");
        Check(source.Values[1] == 16, "second-element-written-through-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
