/*
Rules: E15-7-3-get-end-unreachable
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: if (Choose) return 27;
Into: return 27;
*/
class Box { public bool Choose; public int Item { get { if (Choose) return 27; } } }
class Program { static void Main() { } }
