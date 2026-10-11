/*
Rules: E12-19-2-no-attributes
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: [Marker] int value
Into: int value
*/
class MarkerAttribute : System.Attribute { }
delegate int Transform(int value);
class Program { static void Main() { Transform function = ([Marker] int value) => value; } }
