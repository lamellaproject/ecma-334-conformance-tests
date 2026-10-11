/*
Rules: E15-6-1-async-return-form
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public async ref int Cell()
Into: public ref int Cell()
Csc: CS1073
*/
class Holder
{
    int value;
    public async ref int Cell() { return ref value; }
}
class Program { static void Main() { } }
