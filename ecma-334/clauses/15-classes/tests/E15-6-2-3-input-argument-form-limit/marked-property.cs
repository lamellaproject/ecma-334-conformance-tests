/*
Rules: E15-6-2-3-input-argument-form-limit
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(in Value)
Into: Read(Value)
Csc: CS8156
*/
class Program
{
    static int Value { get { return 37; } }
    static int Read(in int value) { return value; }
    static void Main() { Read(in Value); }
}
