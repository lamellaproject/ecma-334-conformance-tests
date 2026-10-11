/*
Rules: E15-5-3-1-readonly-other-out
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
    public Holder() { Store(out Code); }
    static void Store(out int value) { value = 191; }
}
class Program { static void Main() { new Holder(); } }
