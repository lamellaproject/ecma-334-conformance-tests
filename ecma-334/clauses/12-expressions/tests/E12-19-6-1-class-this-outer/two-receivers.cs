/*
Rules: E12-19-6-1-class-this-outer; E12-19-6-1-class-this-value-parameter; E12-19-3-outer-variable-access; E12-19-3-outer-active-instance
Authority: ECMA-334 7th ed 12.19.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return () => ++this.value;
Into: int copy = this.value; return () => ++copy;
*/
using System;
delegate int Result();
class Counter
{
    int value;
    public Counter(int initial) { value = initial; }
    public Result Make() { return () => ++this.value; }
    public void Set(int next) { value = next; }
    public int Read() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter first = new Counter(13), second = new Counter(23);
        Result a = first.Make(), b = second.Make();
        first.Set(41);
        Check(a() == 42, "class-this-references-receiver-after-capture");
        Check(b() == 24, "other-function-captures-other-receiver");
        Check(a() == 43, "receiver-state-persists-in-closure");
        Check(first.Read() == 43 && second.Read() == 24, "this-capture-updates-real-receiver-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
