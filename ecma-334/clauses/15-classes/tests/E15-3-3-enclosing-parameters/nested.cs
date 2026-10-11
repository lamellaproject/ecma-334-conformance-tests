/*
Rules: E15-3-3-enclosing-parameters
Authority: ECMA-334 7th ed 15.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public Box<U> Second;
Into: public Box<T> Second;
*/
using System;
class Box<X> { public X Value; public Box(X value) { Value = value; } }
class Stamp { }
class Outer<T>
{
    public class Middle<U>
    {
        public class Inner<V>
        {
            public T First;
            public Box<U> Second;
            public V Third;
            public Inner(T first, Box<U> second, V third)
            {
                First = first; Second = second; Third = third;
            }
        }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp stamp = new Stamp();
        Outer<string>.Middle<int>.Inner<Stamp> value =
            new Outer<string>.Middle<int>.Inner<Stamp>("outer", new Box<int>(271), stamp);
        Check(value.First == "outer", "outermost-parameter-used-directly");
        Check(value.Second.Value == 271, "enclosing-parameter-used-in-constructed-member-type");
        Check((object)value.Third == (object)stamp, "own-parameter-remains-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
