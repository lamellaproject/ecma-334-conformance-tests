/*
Rules: P08-switch-invalid
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: public static explicit operator Port(Strand value)
Into: public static implicit operator Port(Strand value)
*/
using System;

// patterns.md L297: an explicit conversion cannot satisfy an arm's implicit one.
class Port { }
class Rock
{
    public static implicit operator Port(Rock value) { return new Port(); }
}
class Strand
{
    public static explicit operator Port(Strand value) { return new Port(); }
}
class Program
{
    static void Main(string[] args)
    {
        Port result = args.Length switch { 0 => new Rock(), _ => new Strand() };
        Console.WriteLine(Object.ReferenceEquals(result, null));
    }
}
