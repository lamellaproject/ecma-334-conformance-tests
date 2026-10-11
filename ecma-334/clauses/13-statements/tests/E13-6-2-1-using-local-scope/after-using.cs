/*
Rules: E13-6-2-1-using-local-scope
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: Resource copy = item;
Into: Resource copy = null;
*/
using System;
class Resource : IDisposable { public void Dispose() { } }
class Program { static void Main() { using (Resource item = new Resource()) { } Resource copy = item; } }
