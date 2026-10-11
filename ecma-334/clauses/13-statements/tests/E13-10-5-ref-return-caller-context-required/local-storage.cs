/*
Rules: E13-10-5-ref-return-caller-context-required
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return ref local;
Into: return ref storage;
*/

class Program
{
    static int storage;
    static ref int Alias() { int local = 19; return ref local; }
    static void Main() { }
}
