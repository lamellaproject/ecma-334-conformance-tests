/*
Rules: E9-7-2-6-local-function-invocation
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: Identity(ref local)
Into: Identity(ref storage)
Csc: CS8347
*/
class Program
{
    static int storage = 87;
    static ref int Select()
    {
        ref int Identity(ref int cell) { return ref cell; }
        int local = 91;
        return ref Identity(ref local);
    }
    static void Main() { }
}
