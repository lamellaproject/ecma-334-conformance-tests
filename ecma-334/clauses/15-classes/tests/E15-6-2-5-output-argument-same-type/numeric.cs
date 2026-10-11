/*
Rules: E15-6-2-5-output-argument-same-type
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: byte value;
Into: long value;
Csc: CS1503
*/
class Program
{
    static void Write(out long value) { value = 41; }
    static void Main() { byte value; Write(out value); }
}
