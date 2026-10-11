/*
Rules: E13-14-resource-out-argument-error
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: Create(out resource);
Into: Resource copy; Create(out copy);
*/
using System;
class Program
{
    class Resource : IDisposable { public void Dispose() { } }
    static void Create(out Resource value) { value = new Resource(); }
    static void Use() { using (Resource resource = new Resource()) { Create(out resource); } }
    static void Main() { }
}
