/*
Rules: E13-14-resource-decrement-error
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: reject
Mutate: --resource;
Into: Resource copy = resource; --copy;
*/
using System;
class Program
{
    class Resource : IDisposable
    {
        public void Dispose() { }
        public static Resource operator --(Resource value) { return value; }
    }
    static void Use() { using (Resource resource = new Resource()) { --resource; } }
    static void Main() { }
}
