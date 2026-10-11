/*
Rules: E11-2-4-var-type-binding-error
Authority: ECMA-334 7th ed 11.2.4
Version: 7.3
Expected: reject
Mutate: using var = Marker;
Into: using Alias = Marker;
Csc: CS8508
*/
using var = Marker;
class Marker { }
class Program
{
    static void Main()
    {
        object input = new Marker();
        if (input is var value) { }
    }
}
