/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile Mark Value;
Into: public Mark Value;
Csc: CS0677
*/
enum Mark : long { Ready = 283L }
class Holder { public volatile Mark Value; }
class Program { static void Main() { new Holder().Value = Mark.Ready; } }
