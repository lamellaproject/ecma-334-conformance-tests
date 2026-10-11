/*
Rules: E15-5-3-1-readonly-other-ref
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: protected readonly int Code;
Into: protected int Code;
Csc: CS0192
*/
class Basis { protected readonly int Code; }
class Holder : Basis
{
    public Holder() { Store(ref Code); }
    static void Store(ref int value) { value = 163; }
}
class Program { static void Main() { new Holder(); } }
