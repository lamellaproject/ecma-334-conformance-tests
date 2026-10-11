/*
Rules: E12-19-2-omitted-signature-no-out
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: delegate { }
Into: delegate(out int value) { value = 31; }
*/
delegate void Assign(out int value);
class Program { static void Main() { Assign function = delegate { }; } }
