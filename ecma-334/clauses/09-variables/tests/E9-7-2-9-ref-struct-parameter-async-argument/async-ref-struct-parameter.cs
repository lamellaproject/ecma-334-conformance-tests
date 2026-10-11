/*
Rules: E9-7-2-9-ref-struct-parameter-async-argument
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: static async void Probe(Cell cell)
Into: static void Probe(Cell cell)
Csc: CS4012
*/
ref struct Cell { public int Value; }
class Program
{
    static async void Probe(Cell cell) { }
    static void Main() { }
}
