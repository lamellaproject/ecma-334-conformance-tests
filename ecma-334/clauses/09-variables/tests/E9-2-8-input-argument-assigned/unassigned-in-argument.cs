/*
Rules: E9-2-8-input-argument-assigned; E9-4-1-input-argument-assigned
Authority: ECMA-334 7th ed 9.2.8
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 3;
Csc: CS0165
*/
class Program
{
    static int Read(in int value) { return value; }
    static void Main() { int cell; Read(in cell); }
}
