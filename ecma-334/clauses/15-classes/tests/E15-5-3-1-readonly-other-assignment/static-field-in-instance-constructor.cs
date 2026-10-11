/*
Rules: E15-5-3-1-readonly-other-assignment
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: public static readonly int Code;
Into: public static int Code;
Csc: CS0198
*/
class Holder
{
    public static readonly int Code;
    public Holder() { Code = 109; }
}
class Program { static void Main() { new Holder(); } }
