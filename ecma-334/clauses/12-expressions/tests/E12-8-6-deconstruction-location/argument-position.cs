/*
Rules: E12-8-6-deconstruction-location
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: reject
Mutate: Consume(var (first, second));
Into: Consume((3, 8));
Csc: CS0103
*/
class Program
{
    static void Consume((int, int) value) { }
    static void Main() { Consume(var (first, second)); }
}
