/*
Rules: E9-7-2-6-invocation-result-context
Authority: ECMA-334 7th ed 9.7.2.6
Version: 7.3
Expected: reject
Mutate: new Wrapper(ref local)
Into: new Wrapper(ref storage)
Csc: CS8352
*/
ref struct Wrapper
{
    static int target;
    int snapshot;
    public Wrapper(ref int cell) { snapshot = cell; }
    public ref int Select() { return ref target; }
}
class Program
{
    static int storage = 78;
    static ref int Select()
    {
        int local = 82;
        Wrapper receiver = new Wrapper(ref local);
        return ref receiver.Select();
    }
    static void Main() { }
}
