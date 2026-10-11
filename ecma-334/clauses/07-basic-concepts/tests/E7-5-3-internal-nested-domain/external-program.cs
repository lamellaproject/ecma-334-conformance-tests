/*
Rules: E7-5-3-internal-nested-domain; E7-5-1-outside-domain-access
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: internal static int Read()
Into: public static int Read()
*/
#if LIBRARY
public class Envelope { internal static int Read() { return 67; } }
#else
class Program { static void Main() { Envelope.Read(); } }
#endif
