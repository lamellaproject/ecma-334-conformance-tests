/*
Rules: E12-23-value-types-only
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: struct Marker { }
Into: enum Marker { None }
Csc: CS0283
*/
struct Marker { }
class Program
{
    const Marker Value = default(Marker);
    static void Main() { }
}
