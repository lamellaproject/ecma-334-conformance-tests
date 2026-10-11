/*
Rules: E7-5-3-protected-internal-domain; E7-5-4-protected-access-derived-context
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: protected internal int value = 79;
Into: public int value = 79;
*/
#if LIBRARY
public class Root { protected internal int value = 79; }
#else
class Program { static void Main() { int value = new Root().value; } }
#endif
