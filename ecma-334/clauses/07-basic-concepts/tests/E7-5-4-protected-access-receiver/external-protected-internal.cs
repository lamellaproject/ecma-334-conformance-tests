/*
Rules: E7-5-4-protected-access-receiver; E7-5-3-protected-internal-domain
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: Read(Root receiver)
Into: Read(Branch receiver)
*/
#if LIBRARY
public class Root { protected internal int value = 107; }
#else
class Branch : Root { public int Read(Root receiver) { return receiver.value; } }
class Program { static void Main() { new Branch().Read(new Branch()); } }
#endif
