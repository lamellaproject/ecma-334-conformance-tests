/*
Rules: E9-7-2-3-input-writable-ref-return
Authority: ECMA-334 7th ed 9.7.2.3
Version: 7.3
Expected: reject
Mutate: static ref int Select(in int input)
Into: static ref readonly int Select(in int input)
Csc: CS8333
*/
class Program
{
    static ref int Select(in int input) { return ref input; }
    static void Main() { }
}
