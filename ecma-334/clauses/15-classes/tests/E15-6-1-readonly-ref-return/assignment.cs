/*
Rules: E15-6-1-readonly-ref-return
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public ref readonly int Cell()
Into: public ref int Cell()
Csc: CS8331
*/
class Holder
{
    int value;
    public ref readonly int Cell() { return ref value; }
}
class Program { static void Main() { new Holder().Cell() = 19; } }
