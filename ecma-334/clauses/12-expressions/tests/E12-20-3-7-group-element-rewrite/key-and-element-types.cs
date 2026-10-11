/*
Rules: E12-20-3-7-group-element-rewrite; E12-20-4-group-by-element-shape
Authority: ECMA-334 7th ed 12.20.3.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: group Element(item) by Key(item)
Into: group Element(item + 4) by Key(item)
*/
using System;
delegate R Selector<T, R>(T item);
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<Cluster<K, E>> GroupBy<K, E>(Selector<T, K> key, Selector<T, E> element)
    {
        Program.trace += "G";
        K k = key(Value);
        E e = element(Value);
        return new Stream<Cluster<K, E>>(new Cluster<K, E>(k, e));
    }
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
    static short Key(int value) { trace += "K"; return (short)(value % 3); }
    static string Element(int value) { trace += "E"; return value == 5 ? "hit" : "miss"; }
    static void Main()
    {
        Stream<Cluster<short, string>> result = from item in new Stream<int>(5) group Element(item) by Key(item);
        Check(result.Value.Key == 2, "key-selector-is-first-argument");
        Check(result.Value.Value == "hit", "projected-element-type");
        Check(trace == "GKE", "method-owns-selector-execution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
