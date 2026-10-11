/*
Rules: E13-10-5-return-readonly-ref-result
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: static ref readonly int Alias()
Into: static ref int Alias()
*/

class Program
{
    static int storage;
    static ref readonly int Alias() { return ref storage; }
    static void Write() { Alias() = 29; }
    static void Main() { }
}
