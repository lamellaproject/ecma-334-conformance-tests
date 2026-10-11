/*
Rules: E16-2-1-ref-no-interfaces; E16-2-3-no-interface-implementation
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: reject
Mutate: ref struct Entry : ITag
Into: struct Entry : ITag
*/
interface ITag { }
ref struct Entry : ITag { }
class Program { static void Main() { } }
