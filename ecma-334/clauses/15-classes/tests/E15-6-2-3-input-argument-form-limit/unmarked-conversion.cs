/*
Rules: E15-6-2-3-input-argument-form-limit
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(1.5m)
Into: Read(3)
Csc: CS1503
*/
class Program
{
    static int Read(in int value) { return value; }
    static void Main() { Read(1.5m); }
}
