/*
Rules: E9-7-2-6-other-input-argument-context
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: Pick((short)63)
Into: Pick(storage)
Csc: CS8156
*/
class Program
{
    static int storage = 67;
    static ref readonly int Pick(in int value) { return ref value; }
    static ref readonly int Select() { return ref Pick((short)63); }
    static void Main() { }
}
