/*
Rules: E15-6-1-method-mode-only-overload
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int Read(in int value)
Into: public int Read(int value)
Csc: CS0663
*/
class Holder
{
    public int Read(out int value) { value = 7; return value; }
    public int Read(in int value) { return value; }
}
class Program { static void Main() { } }
