/*
Rules: E15-6-2-5-output-argument-variable
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: static int Value { get { return storage; } }
Into: static ref int Value { get { return ref storage; } }
Csc: CS0206
*/
class Program
{
    static int storage;
    static int Value { get { return storage; } }
    static void Write(out int value) { value = 29; }
    static void Main() { Write(out Value); }
}
