/*
Rules: E20-2-containing-arguments
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: Shelf.Read reader
Into: Shelf<int>.Read reader
Csc: CS0305
*/
class Shelf<T> { public delegate T Read(); }
class Program
{
    static int ReadValue() { return 59; }
    static void Main() { Shelf.Read reader = ReadValue; }
}
