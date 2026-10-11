/*
Rules: E8-4-5-type-constraint-conversion-required
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Mutate: Gate<Entry, int> value
Into: Gate<Entry, short> value
*/
interface ITag<T> { }
class Entry : ITag<short> { }
class Gate<T, U> where T : ITag<U> { }
class Program { static void Main() { Gate<Entry, int> value = null; } }
