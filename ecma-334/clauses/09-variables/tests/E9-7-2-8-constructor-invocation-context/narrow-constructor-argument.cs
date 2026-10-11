/*
Rules: E9-7-2-8-constructor-invocation-context
Authority: ECMA-334 7th ed 9.7.2.8
Version: 7.3
Expected: reject
Mutate: new Wrapper(ref local)
Into: new Wrapper(ref storage)
Csc: CS8347
*/
ref struct Wrapper
{
    public int Value;
    public Wrapper(ref int cell) { Value = cell; }
}
class Program
{
    static int storage = 95;
    static Wrapper Select()
    {
        int local = 99;
        return new Wrapper(ref local);
    }
    static void Main() { }
}
