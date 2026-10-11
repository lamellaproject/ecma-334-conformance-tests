/*
Rules: E15-5-3-1-readonly-other-out
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: public readonly int Code;
Into: public int Code;
Csc: CS0192
*/
class Holder
{
    public readonly int Code;
    public void Reset() { Store(out Code); }
    static void Store(out int value) { value = 173; }
}
class Program { static void Main() { new Holder().Reset(); } }
