/*
Rules: E12-12-7-inapplicable-error
Authority: ECMA-334 7th ed 12.12.7
Version: 7.3
Expected: reject
Mutate: left == right
Into: (object)left == right
*/
sealed class Left { }
sealed class Right { }
class Program { static void Main() { Left left = new Left(); Right right = new Right(); bool b = left == right; } }
