/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile Offset Value;
Into: public Offset Value;
Csc: CS0677
*/
struct Offset { public int Count; }
class Holder { public volatile Offset Value; }
class Program { static void Main() { new Holder().Value = default(Offset); } }
