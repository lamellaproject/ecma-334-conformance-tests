/*
Rules: E13-14-resource-assignment-error; E13-14-resource-variable-readonly
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: resource = new Resource();
Into: Resource copy = new Resource();
*/
using System;
class Program
{
    class Resource : IDisposable { public void Dispose() { } }
    static void Use() { using (Resource resource = new Resource()) { resource = new Resource(); } }
    static void Main() { }
}
