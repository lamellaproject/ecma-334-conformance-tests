/*
Rules: E15-5-3-1-readonly-other-assignment
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: public readonly int Code;
Into: public int Code;
Csc: CS0191
*/
class Holder
{
    public readonly int Code;
    static Holder()
    {
        Holder value = new Holder();
        value.Code = 127;
    }
}
class Program { static void Main() { new Holder(); } }
