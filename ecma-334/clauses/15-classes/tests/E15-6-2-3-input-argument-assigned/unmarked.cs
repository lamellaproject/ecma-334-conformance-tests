/*
Rules: E15-6-2-3-input-argument-assigned
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: int value;
Into: int value = 43;
Csc: CS0165
*/
class Program
{
    static int Read(in int value) { return value; }
    static void Main() { int value; Read(value); }
}
