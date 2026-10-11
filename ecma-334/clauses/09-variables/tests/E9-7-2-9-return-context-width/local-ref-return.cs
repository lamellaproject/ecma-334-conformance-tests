/*
Rules: E9-7-2-9-return-context-width
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: return ref local;
Into: return ref storage;
Csc: CS8168
*/
class Program
{
    static int storage = 14;
    static ref int Select()
    {
        int local = 18;
        return ref local;
    }
    static void Main() { }
}
