/*
Rules: E19-4-outside-qualified-name
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: Code value = Mark
Into: Code value = Code.Mark
*/
enum Code { Mark }
class Program { static void Main() { Code value = Mark; } }
