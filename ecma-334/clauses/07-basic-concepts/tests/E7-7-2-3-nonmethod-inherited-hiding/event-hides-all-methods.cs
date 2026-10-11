/*
Rules: E7-7-2-3-nonmethod-inherited-hiding
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: reject
Mutate: return Read(5);
Into: return base.Read(5);
*/
delegate int Notice();
class Root { public int Read() { return 17; } public int Read(int value) { return 23; } }
class Branch : Root { public new event Notice Read; public int Probe() { return Read(5); } }
class Program { static void Main() { } }
