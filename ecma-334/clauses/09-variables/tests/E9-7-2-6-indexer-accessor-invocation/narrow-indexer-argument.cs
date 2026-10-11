/*
Rules: E9-7-2-6-indexer-accessor-invocation
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: holder[in local]
Into: holder[in storage]
Csc: CS8347
*/
class Holder
{
    public ref readonly int this[in int cell] { get { return ref cell; } }
}
class Program
{
    static int storage = 79;
    static ref readonly int Select()
    {
        Holder holder = new Holder();
        int local = 83;
        return ref holder[in local];
    }
    static void Main() { }
}
