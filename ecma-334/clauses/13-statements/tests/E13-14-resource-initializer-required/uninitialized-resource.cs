/*
Rules: E13-14-resource-initializer-required
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: using (Resource resource)
Into: using (Resource resource = new Resource())
*/
using System;
class Program
{
    class Resource : IDisposable { public void Dispose() { } }
    static void Use() { using (Resource resource) { } }
    static void Main() { }
}
