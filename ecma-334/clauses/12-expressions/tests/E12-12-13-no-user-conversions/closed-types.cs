/*
Rules: E12-12-13-no-user-conversions
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Mutate: value as Target
Into: (Target)value
*/
sealed class Target { }
sealed class Source { public static explicit operator Target(Source s) { return new Target(); } }
class Program { static void Main() { Source value = new Source(); Target result = value as Target; } }
