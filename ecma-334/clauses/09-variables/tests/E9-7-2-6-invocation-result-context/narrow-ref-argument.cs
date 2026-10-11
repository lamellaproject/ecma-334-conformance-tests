/*
Rules: E9-7-2-6-invocation-result-context
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: Pick(ref first, ref local)
Into: Pick(ref first, ref second)
Csc: CS8347
*/
class Program
{
    static int first = 43, second = 47;
    static ref int Pick(ref int a, ref int b) { return ref a; }
    static ref int Select()
    {
        int local = 51;
        return ref Pick(ref first, ref local);
    }
    static void Main() { }
}
