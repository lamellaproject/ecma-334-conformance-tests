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
    public static void Reset() { Store(ref Code); }
    static void Store(ref int value) { value = 157; }
}
class Program { static void Main() { Holder.Reset(); } }
