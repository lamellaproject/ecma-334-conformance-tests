/*
Rules: E12-20-3-3-join-cast-rewrite
Authority: ECMA-334 7th ed 12.20.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: join short right in Inner()
Into: join int right in Inner()
*/
using System;
delegate R Unary<T, R>(T item);
delegate R Binary<T, U, R>(T first, U second);
class Raw
{
    object value;
    public Raw(object value) { this.value = value; }
    public Stream<T> Cast<T>() { Program.trace += "C"; return new Stream<T>((T)value); }
}
class Stream<T>
{
    public T Value;
    public Stream(T value) { Value = value; }
    public Stream<R> Join<U, K, R>(Stream<U> inner, Unary<T, K> outerKey, Unary<U, K> innerKey, Binary<T, U, R> result)
    {
        Program.trace += "J";
        if (!object.Equals(outerKey(Value), innerKey(inner.Value))) throw new Exception("key mismatch");
        return new Stream<R>(result(Value, inner.Value));
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Stream<int> Outer() { trace += "E"; return new Stream<int>(7); }
    static Raw Inner() { trace += "I"; return new Raw((short)17); }
    static int Left(int value) { trace += "L"; return value + 10; }
    static int Right(short value) { trace += "R"; return value; }
    static int Pair(int left, short right) { trace += "P"; return left * 100 + right; }
    static void Main()
    {
        var result = from left in Outer() join short right in Inner() on Left(left) equals Right(right) select Pair(left, right);
        Check(result.Value == 717, "typed-inner-key-and-result");
        Check(trace == "EICJLRP", "inner-cast-before-join");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
