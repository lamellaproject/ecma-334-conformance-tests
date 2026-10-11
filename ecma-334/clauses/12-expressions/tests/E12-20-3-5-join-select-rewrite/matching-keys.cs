/*
Rules: E12-20-3-5-join-select-rewrite; E12-20-1-body-join; E12-20-1-join-form; E12-20-1-join-pairs; E12-20-4-join-shape
Authority: ECMA-334 7th ed 12.20.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: on Left(left) equals Right(right)
Into: on Left(left) equals Right(right + 1)
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Stream<T>
{
    public T[] Items;
    public int Count;
    public Stream(T[] items, int count) { Items = items; Count = count; }
    public Stream<R> Join<U, K, R>(Stream<U> inner, Unary<T, K> outerKey, Unary<U, K> innerKey, Binary<T, U, R> result)
    {
        Program.trace += "J";
        var items = new R[Count * inner.Count];
        int count = 0;
        for (int i = 0; i < Count; i++)
        {
            K key = outerKey(Items[i]);
            for (int j = 0; j < inner.Count; j++)
                if (object.Equals(key, innerKey(inner.Items[j]))) items[count++] = result(Items[i], inner.Items[j]);
        }
        return new Stream<R>(items, count);
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Left(int value) { trace += "L"; return value + 10; }
    static int Right(int value) { trace += "R"; return value; }
    static int Pair(int left, int right) { trace += "P"; return left * 100 + right; }
    static void Main()
    {
        var outer = new Stream<int>(new int[] { 2, 5 }, 2);
        var inner = new Stream<int>(new int[] { 15, 12 }, 2);
        var result = from left in outer join right in inner on Left(left) equals Right(right) select Pair(left, right);
        Check(result.Count == 2, "join-matching-count");
        Check(result.Items[0] == 212 && result.Items[1] == 515, "join-key-and-result-parameters");
        Check(trace == "JLRRPLRPR", "join-supplies-correct-callbacks");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
