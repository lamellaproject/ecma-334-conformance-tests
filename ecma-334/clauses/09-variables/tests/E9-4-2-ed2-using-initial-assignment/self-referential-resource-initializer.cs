/*
Rules: E9-4-2-ed2-using-initial-assignment
Authority: ECMA-334 2nd ed 12.1.7
Version: ISO-1
Expected: reject
Mutate: using (Resource item = item)
Into: using (Resource item = new Resource())
Csc: CS0165
*/
using System;
sealed class Resource : IDisposable
{
    public void Dispose() { }
}
class SelfAcquisition
{
    static void Main()
    {
        using (Resource item = item)
        {
            Console.WriteLine(item != null ? "OK" : "FAIL");
        }
    }
}
