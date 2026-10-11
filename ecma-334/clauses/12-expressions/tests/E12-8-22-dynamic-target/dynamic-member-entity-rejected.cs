/*
Rules: E12-8-22-dynamic-target
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/dynamic-member-entity-rejected-567ad602b3.cs.part
Mutate: dynamic receiver = new Program();
Into: Program receiver = new Program();
*/
class Program
{
    private int Number;
    static void Main()
    {
        dynamic receiver = new Program();
        string name = nameof(receiver.Number);
    }
}
