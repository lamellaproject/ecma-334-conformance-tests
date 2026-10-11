/*
Rules: E18-4-1-no-constant
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: const int Limit = 43;
Into: int Limit { get; }
*/
interface ILimit { const int Limit = 43; }
class Program { static void Main() { } }
