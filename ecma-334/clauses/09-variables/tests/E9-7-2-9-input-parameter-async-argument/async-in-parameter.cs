/*
Rules: E9-7-2-9-input-parameter-async-argument
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: static async void Probe(in int cell)
Into: static void Probe(in int cell)
Csc: CS1988
*/
class Program
{
    static async void Probe(in int cell) { }
    static void Main() { }
}
