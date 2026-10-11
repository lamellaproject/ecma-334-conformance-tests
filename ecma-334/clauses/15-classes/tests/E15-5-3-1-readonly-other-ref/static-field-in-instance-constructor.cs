/*
Rules: E15-5-3-1-readonly-other-ref
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: public static readonly int Code;
Into: public static int Code;
Csc: CS0199
*/
class Holder
{
    public static readonly int Code;
    public Holder() { Store(ref Code); }
    static void Store(ref int value) { value = 167; }
}
class Program { static void Main() { new Holder(); } }
