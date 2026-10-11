/*
Rules: E15-2-5-constraint-containing-type
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Node<T>
Into: 
*/
using System;
class Node<T> where T : Node<T>
{ public int Number = 157; public static int Read(T value) { return value.Number; } }
class Leaf : Node<Leaf> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Node<Leaf>.Read(new Leaf()) == 157, "constraint-involves-declaring-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
