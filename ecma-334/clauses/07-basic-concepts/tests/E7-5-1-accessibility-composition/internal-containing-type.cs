/*
Rules: E7-5-1-accessibility-composition; E7-5-3-public-nested-domain; E7-5-1-outside-domain-access
Authority: ECMA-334 7th ed 7.5.1
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: internal class Envelope
Into: public class Envelope
*/
#if LIBRARY
internal class Envelope { public class Nested { public static int Read() { return 61; } } }
#else
class Program { static void Main() { Envelope.Nested.Read(); } }
#endif
