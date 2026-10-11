/*
Rules: E13-14-declaration-disposable-conversion-required
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: class Resource
Into: class Resource : IDisposable
*/
using System;
class Program
{
    class Resource { public void Dispose() { } }
    static void Use() { using (Resource resource = new Resource()) { } }
    static void Main() { }
}
