/*
Rules: E12-8-9-3-eligible-receiver-conversion
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: receiver.Read()
Into: ((Target)receiver).Read()
*/
class Target { }
class Source { public static implicit operator Target(Source value) { return new Target(); } }
static class Extensions { public static int Read(this Target receiver) { return 3; } }
class Program { static void Main() { Source receiver = new Source(); receiver.Read(); } }
