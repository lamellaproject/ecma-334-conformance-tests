/*
Rules: E9-7-2-7-value-context
Authority: ECMA-334 7th ed 9.7.2.7
Version: 7.3
Expected: reject
Mutate: Pick(storage + 0)
Into: Pick(storage)
Csc: CS8156
*/
class Program
{
    static int storage = 71;
    static ref readonly int Pick(in int value) { return ref value; }
    static ref readonly int Select() { return ref Pick(storage + 0); }
    static void Main() { }
}
