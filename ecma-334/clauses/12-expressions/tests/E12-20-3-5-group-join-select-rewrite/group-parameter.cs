/*
Rules: E12-20-3-5-group-join-select-rewrite; E12-20-1-body-join-into; E12-20-1-join-into-form; E12-20-4-group-join-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: on left + 10 equals right into matches
Into: on left + 11 equals right into matches
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T[] Items;
    public int Count;
    public Stream(T[] items, int count) { Items = items; Count = count; }
    public Stream<R> GroupJoin<U, K, R>(Stream<U> inner, Unary<T, K> outerKey, Unary<U, K> innerKey, Binary<T, Stream<U>, R> result)
    {
        Program.trace += "G";
        var groups = new R[Count];
        for (int i = 0; i < Count; i++)
        {
            var matches = new U[inner.Count];
            int count = 0;
            K key = outerKey(Items[i]);
            for (int j = 0; j < inner.Count; j++)
                if (object.Equals(key, innerKey(inner.Items[j]))) matches[count++] = inner.Items[j];
            groups[i] = result(Items[i], new Stream<U>(matches, count));
        }
        return new Stream<R>(groups, Count);
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var outer = new Stream<int>(new int[] { 3, 6 }, 2);
        var inner = new Stream<int>(new int[] { 13, 9, 13 }, 3);
        var result = from left in outer join right in inner on left + 10 equals right into matches select left * 100 + matches.Count;
        Check(result.Count == 2, "outer-and-empty-group-retained");
        Check(result.Items[0] == 302 && result.Items[1] == 600, "group-result-selector-parameters");
        Check(trace == "G", "group-join-without-extra-select");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
