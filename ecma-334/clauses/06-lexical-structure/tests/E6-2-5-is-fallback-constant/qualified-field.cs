/*
Rules: E6-2-5-is-fallback-constant
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: reject
Mutate: static int Limit
Into: const int Limit
*/
class Constants { public static int Limit = 29; }
class Program
{
    static void Main() { object input = 29; bool match = input is Constants.Limit; }
}
