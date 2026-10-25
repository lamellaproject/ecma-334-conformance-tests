/*
Rules: P08-nullable-new-type
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: new Capsule?()
Into: new Capsule()
*/
#nullable enable
using System;

// Updated nullable specification L67: a nullable reference annotation cannot
// be the type in an object creation expression. The assignment target is valid.
class Capsule { }
class Program
{
    static void Main()
    {
        Capsule? value = new Capsule?();
        Console.WriteLine(Object.ReferenceEquals(value, null));
    }
}
