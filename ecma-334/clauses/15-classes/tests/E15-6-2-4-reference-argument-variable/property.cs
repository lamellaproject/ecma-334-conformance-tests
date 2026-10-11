/*
Rules: E15-6-2-4-reference-argument-variable
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: static int Value { get { return storage; } }
Into: static ref int Value { get { return ref storage; } }
Csc: CS0206
*/
class Program
{
    static int storage = 31;
    static int Value { get { return storage; } }
    static int Read(ref int value) { return value; }
    static void Main() { Read(ref Value); }
}
