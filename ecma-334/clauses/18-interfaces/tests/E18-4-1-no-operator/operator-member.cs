/*
Rules: E18-4-1-no-operator; E18-4-1-no-static-member; E18-1-no-member-implementations
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: public static int operator +(IAdd left, IAdd right) { return 1; }
Into: int Add(IAdd left, IAdd right);
*/
// Use a complete operator declaration valid in a class. Its modifiers and body
// belong to this operator construct and touch the related interface prohibitions.
interface IAdd { public static int operator +(IAdd left, IAdd right) { return 1; } }
class Program { static void Main() { } }
