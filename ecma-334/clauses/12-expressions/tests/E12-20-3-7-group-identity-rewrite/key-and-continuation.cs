/*
Rules: E12-20-3-7-group-identity-rewrite; E12-20-1-group-ending; E12-20-1-group-form; E12-20-4-group-by-shape; E12-20-4-group-sequence-shape; E12-20-4-group-key-shape
Authority: ECMA-334 7th ed 12.20.3.7
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: group item by item % 3
Into: group item + 1 by item % 3
*/
using System;
delegate R Selector<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<Cluster<K, T>> GroupBy<K>(Selector<T, K> key)
    {
        Program.trace += "G";
        return new Stream<Cluster<K, T>>(new Cluster<K, T>(key(Value), Value));
    }
    public Stream<Cluster<K, E>> GroupBy<K, E>(Selector<T, K> key, Selector<T, E> element)
    {
        Program.trace += "B";
        return new Stream<Cluster<K, E>>(new Cluster<K, E>(key(Value), element(Value)));
    }
    public Stream<R> Select<R>(Selector<T, R> selector) { Program.trace += "S"; return new Stream<R>(selector(Value)); }
}
class Cluster<K, T> : Stream<T>
{
    public K Key { get; private set; }
    public Cluster(K key, T value) : base(value) { Key = key; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stream<Cluster<int, int>> grouped = from item in new Stream<int>(4) group item by item % 3;
        Check(grouped.Value.Key == 1 && grouped.Value.Value == 4, "group-key-and-identity-element");
        Check(trace == "G", "one-selector-group-overload");
        Stream<int> elements = grouped.Value;
        Check(elements.Value == 4, "group-is-element-sequence");
        var continued = from item in new Stream<int>(4) group item by item + 7 into pack select pack.Key + pack.Value;
        Check(continued.Value == 15, "group-result-feeds-continuation");
        Check(trace == "GGS", "group-continuation-projection");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
