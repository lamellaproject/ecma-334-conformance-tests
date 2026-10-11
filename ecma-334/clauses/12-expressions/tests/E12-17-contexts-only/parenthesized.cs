/*
Rules: E12-17-contexts-only
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: reject
Mutate: Use((int number))
Into: Use(3)
*/
class Program { static void Use(int value) { } static void Main() { Use((int number)); } }
