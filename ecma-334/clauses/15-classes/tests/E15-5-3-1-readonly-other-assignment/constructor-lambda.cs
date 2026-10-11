/*
Rules: E15-5-3-1-readonly-other-assignment
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: public readonly int Code;
Into: public int Code;
Csc: CS0191
*/
delegate void Work();
class Holder
{
    public readonly int Code;
    public Holder()
    {
        // This assignment belongs to the lambda body even when invoked by the constructor.
        Work operation = () => Code = 149;
        operation();
    }
}
class Program { static void Main() { new Holder(); } }
