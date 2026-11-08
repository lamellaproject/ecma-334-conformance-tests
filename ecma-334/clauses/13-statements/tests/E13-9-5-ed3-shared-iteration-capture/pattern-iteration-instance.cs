/*
Rules: E13-9-5-ed3-shared-iteration-capture
Authority: ECMA-334 3rd ed 15.8.4
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E13-9-5-ed3-shared-iteration-capture/pattern-iteration-instance.cs.part
Mutate: saved[index++] = delegate { return marker; };
Into: int frozen = marker; saved[index++] = delegate { return frozen; };
*/
// ECMA-334 3rd ed 15.8.4, p. 234 (PDF p. 254).
using System;
delegate int Readback();
class Range
{
    public Cursor GetEnumerator() { return new Cursor(); }
}
struct Cursor
{
    int position;
    public bool MoveNext() { position++; return position <= 3; }
    public int Current { get { return position * 17; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Readback[] saved = new Readback[3];
        int index = 0;
        foreach (int marker in new Range())
        {
            saved[index++] = delegate { return marker; };
        }
        for (int i = 0; i < saved.Length; i++)
        {
            Check(saved[i]() == 51, "shared-pattern-iteration");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
