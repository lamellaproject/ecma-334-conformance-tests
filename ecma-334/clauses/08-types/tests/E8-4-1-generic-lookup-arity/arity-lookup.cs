/*
Rules: E8-4-1-generic-lookup-arity; E8-4-1-same-type-name-different-arity
Authority: ECMA-334 7th ed 8.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Node<int, string>.Marker
Into: Node<int>.Marker
*/
using System;
class Node { public const int Marker = 11; }
class Node<T> { public const int Marker = 22; }
class Node<T, U> { public const int Marker = 33; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Node.Marker == 11 && Node<int>.Marker == 22 && Node<int, string>.Marker == 33, "same-identifier-distinct-arities");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
