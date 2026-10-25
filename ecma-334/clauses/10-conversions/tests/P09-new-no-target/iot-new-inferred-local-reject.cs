/*
Rules: P09-new-no-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: var specimen = new(21);
Into: Specimen specimen = new(21);
*/
using System;

// Target-typed new specification L52: an inferred local supplies no target type.
class Specimen
{
    public int Value;
    public Specimen(int value) { Value = value; }
}
class Program
{
    static void Main()
    {
        var specimen = new(21);
        Console.WriteLine(specimen.Value);
    }
}
