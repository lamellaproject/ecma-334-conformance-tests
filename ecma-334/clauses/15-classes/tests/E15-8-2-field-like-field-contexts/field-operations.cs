/*
Rules: E15-8-2-field-like-field-contexts; E15-8-2-field-like-delegate-handler-list; E15-8-2-field-like-empty-null; E15-8-2-field-like-delegate-storage; E15-8-2-field-like-add-accessor; E15-8-2-field-like-remove-accessor
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: public event Action Signal;
Into: public event Action Signal { add { } remove { } }
*/
using System;
class Source
{
    public event Action Signal;
    public bool Empty() { return Signal == null; }
    public Action Read() { return Signal; }
    public void Assign(Action handler) { Signal = handler; }
    public void Notify() { Signal(); }
    static void Replace(ref Action field, Action handler) { field = handler; }
    static void Clear(out Action field) { field = null; }
    public void ReplaceThroughRef(Action handler) { Replace(ref Signal, handler); }
    public void ClearThroughOut() { Clear(out Signal); }
    public class Nested { public static Action Read(Source source) { return source.Signal; } }
}
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Source source = new Source();
        Action first = () => trace = trace * 10 + 2;
        Action second = () => trace = trace * 10 + 7;
        Check(source.Empty(), "empty-field-null");
        source.Signal += first;
        source.Signal += second;
        source.Read()();
        Check(trace == 27, "field-delegate-handler-list");
        source.Signal -= first;
        Check(source.Read() == second, "generated-remove-storage");
        source.Assign(first);
        Check(Source.Nested.Read(source) == first, "assignment-and-nested-read");
        source.ReplaceThroughRef(second);
        Check(source.Read() == second, "ref-field-context");
        trace = 0;
        source.Notify();
        Check(trace == 7, "field-invocation");
        source.ClearThroughOut();
        Check(source.Empty(), "out-field-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
