/*
Rules: E9-7-2-5-conditional-reference-context
Authority: ECMA-334 7th ed 9.7.2.5
Version: 7.3
Expected: reject
Mutate: true ? ref first : ref local
Into: true ? ref first : ref second
Csc: CS8168
*/
class Program
{
    static int first = 19, second = 23;
    static ref int Select()
    {
        int local = 27;
        return ref (true ? ref first : ref local);
    }
    static void Main() { }
}
