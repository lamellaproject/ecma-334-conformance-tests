/*
Rules: E7-5-3-private-protected-domain; E7-5-1-outside-domain-access
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: private protected int value = 83;
Into: protected int value = 83;
*/
#if LIBRARY
public class Root { private protected int value = 83; }
#else
class Branch : Root { public int Read() { return value; } }
class Program { static void Main() { new Branch().Read(); } }
#endif
