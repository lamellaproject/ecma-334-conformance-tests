/*
Rules: E15-6-2-5-output-argument-out
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: Write(value)
Into: Write(out value)
Csc: CS1620
*/
class Program
{
    static void Write(out int value) { value = 23; }
    static void Main() { int value = 7; Write(value); }
}
