/*
Rules: E13-10-5-ref-return-variable-required
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return ref Value();
Into: return ref storage;
*/

class Program
{
    static int storage;
    static int Value() { return 19; }
    static ref int Alias() { return ref Value(); }
    static void Main() { }
}
