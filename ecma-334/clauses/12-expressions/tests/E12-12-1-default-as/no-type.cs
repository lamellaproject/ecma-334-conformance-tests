/*
Rules: E12-12-1-default-as
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: reject
Mutate: default as string
Into: default(string) as string
*/
class Program { static void Main() { string b = default as string; } }
