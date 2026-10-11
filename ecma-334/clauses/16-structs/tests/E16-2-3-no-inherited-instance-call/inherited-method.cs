/*
Rules: E16-2-3-no-inherited-instance-call
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry { }
Into: ref struct Entry { public override string ToString() { return "entry"; } }
*/
ref struct Entry { }
class Program { static void Main() { Entry item = default(Entry); string text = item.ToString(); } }
