/*
Rules: E12-8-16-4-ed5-instance-add-required
Authority: ECMA-334 5th ed 12.7.11.4
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-8-16-4-ed5-instance-add-required/extension-only.cs.part
Mutate: public void Add(string value) { }
Into: public void Add(int value) { }
*/
using System.Collections;
class Batch : IEnumerable
{
    public void Add(string value) { }
    public IEnumerator GetEnumerator() { return null; }
}
static class BatchOperations
{
    public static void Add(this Batch batch, int value) { }
}
class Program
{
    static void Main()
    {
        Batch batch = new Batch { 26 };
    }
}
