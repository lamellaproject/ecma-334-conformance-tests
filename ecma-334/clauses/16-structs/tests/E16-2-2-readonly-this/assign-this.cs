/*
Rules: E16-2-2-readonly-this; E16-2-2-readonly-immutable; E16-2-2-readonly-no-write
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Mutate: this = default(Entry);
Into: Entry copy = default(Entry);
*/
readonly struct Entry { public void Clear() { this = default(Entry); } }
class Program { static void Main() { } }
