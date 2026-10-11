/*
Rules: E9-7-2-9-reassignment-context-width
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: alias = ref local;
Into: alias = ref storage;
Csc: CS8374
*/
class Program
{
    static int storage = 6;
    static void Probe(ref int parameter)
    {
        ref int alias = ref parameter;
        int local = 10;
        alias = ref local;
    }
    static void Main() { }
}
