/*
Rules: E12-9-6-setter-required
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: reject
Mutate: public int Value { get { return 3; } }
Into: public int Value { get { return 3; } set { } }
*/
class Box { public int Value { get { return 3; } } }
class Program { static void Main() { Box box = new Box(); var result = --box.Value; } }
