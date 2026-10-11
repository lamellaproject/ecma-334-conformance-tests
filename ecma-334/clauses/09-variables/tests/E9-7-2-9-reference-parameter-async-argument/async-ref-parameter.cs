/*
Rules: E9-7-2-9-reference-parameter-async-argument
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: static async void Probe(ref int cell)
Into: static void Probe(ref int cell)
Csc: CS1988
*/
class Program
{
    static async void Probe(ref int cell) { cell = 54; }
    static void Main() { }
}
