/*
Rules: E16-2-2-readonly-no-setter
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/explicit-setter-cf103deddb.cs.part
Mutate: set { }
Into: 
*/
readonly struct Entry { public int Value { get { return 5; } set { } } }
class Program { static void Main() { } }
