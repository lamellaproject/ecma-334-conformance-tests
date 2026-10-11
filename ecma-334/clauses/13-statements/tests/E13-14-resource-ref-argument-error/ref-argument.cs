/*
Rules: E13-14-resource-ref-argument-error
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: Modify(ref resource);
Into: Resource copy = resource; Modify(ref copy);
*/
using System;
class Program
{
    class Resource : IDisposable { public void Dispose() { } }
    static void Modify(ref Resource value) { }
    static void Use() { using (Resource resource = new Resource()) { Modify(ref resource); } }
    static void Main() { }
}
