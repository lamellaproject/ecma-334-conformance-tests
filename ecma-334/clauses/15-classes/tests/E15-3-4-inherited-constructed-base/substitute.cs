/*
Rules: E15-3-4-inherited-constructed-base; E15-3-4-inherited-member-substitution
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Leaf<A, B> : Holder<Box<B>>
Into: class Leaf<A, B> : Holder<Box<A>>
*/
using System;
class Box<X> { public X Value; public Box(X value) { Value = value; } }
class Holder<T>
{
    public T Value;
    public T Store(T value) { Value = value; return Value; }
}
class Leaf<A, B> : Holder<Box<B>> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf<string, int> value = new Leaf<string, int>();
        Box<int> input = new Box<int>(373);
        Box<int> result = value.Store(input);
        Check(result.Value == 373 && (object)result == (object)input, "base-argument-substituted-in-inherited-method");
        Box<int> field = value.Value;
        Check((object)field == (object)input, "base-argument-substituted-in-inherited-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
