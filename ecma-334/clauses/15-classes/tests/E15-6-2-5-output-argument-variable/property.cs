/*
Rules: E15-6-2-5-output-argument-variable; E15-7-1-property-not-storage
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: Write(out Value)
Into: Write(out storage)
Csc: CS0206
*/
class Program
{
    static int storage;
    static int Value { get { return storage; } }
    static void Write(out int value) { value = 29; }
    static void Main() { Write(out Value); }
}
