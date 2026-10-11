/*
Rules: E9-7-2-2-ordinary-local-context
Authority: ECMA-334 7th ed 9.7.2.2
Version: 7.3
Expected: reject
Mutate: int local = cell;
Into: ref int local = ref cell;
Csc: CS8168
*/
class Program
{
    static int cell = 64;
    static ref int Select()
    {
        int local = cell;
        return ref local;
    }
    static void Main() { }
}
