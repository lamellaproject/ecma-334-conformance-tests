/*
Rules: E15-6-2-3-input-argument-form-limit
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(in value)
Into: Read(value)
Csc: CS1503
*/
class Program
{
    static long Read(in long value) { return value; }
    static void Main() { byte value = 29; Read(in value); }
}
