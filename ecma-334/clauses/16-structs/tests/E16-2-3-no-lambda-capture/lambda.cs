/*
Rules: E16-2-3-no-lambda-capture
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry
Into: struct Entry
*/
delegate int Getter();
ref struct Entry { public int Value; }
class Program { static void Main() { Entry item = default(Entry); Getter read = () => item.Value; } }
