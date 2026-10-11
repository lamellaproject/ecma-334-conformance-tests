/*
Rules: E12-19-3-omitted-signature-no-parameter-access
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: delegate { return argument; }
Into: delegate { return 7; }
*/
delegate int Ignore(int argument);
class Program { static void Main() { Ignore function = delegate { return argument; }; } }
