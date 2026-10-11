/*
Rules: E9-4-4-18-acquisition-entry
Authority: ECMA-334 7th ed 9.4.4.18
Version: 7.3
Expected: reject
Mutate: Resource resource;
Into: Resource resource = new Resource();
Csc: CS0165
*/
class Resource : System.IDisposable { public void Dispose() { } }
class Program
{
    static void Main() { Resource resource; using (resource) { } }
}
