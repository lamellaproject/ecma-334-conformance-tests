/*
Rules: E9-7-2-6-identity-input-argument-context
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: Pick(local)
Into: Pick(storage)
Csc: CS8347
*/
class Program
{
    static int storage = 55;
    static ref readonly int Pick(in int value) { return ref value; }
    static ref readonly int Select()
    {
        int local = 59;
        return ref Pick(local);
    }
    static void Main() { }
}
