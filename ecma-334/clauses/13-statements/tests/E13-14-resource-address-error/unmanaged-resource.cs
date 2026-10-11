/*
Rules: E13-14-resource-address-error
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/unmanaged-resource-f93b21290c.cs.part
Mutate: Resource* address = &resource;
Into: Resource copy = resource; Resource* address = &copy;
*/
using System;
class Program
{
    // Only taking the address needs clause 23 unsafe pointers.
    struct Resource : IDisposable { public int Value; public void Dispose() { } }
    static unsafe void Use() { using (Resource resource = new Resource()) { Resource* address = &resource; } }
    static void Main() { }
}
