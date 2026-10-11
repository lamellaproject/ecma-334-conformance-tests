/*
Rules: E7-5-5-method-return-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal class Hidden
Into: public class Hidden
*/
internal class Hidden { }
public class Api { public Hidden Read() { return null; } }
class Program { static void Main() { } }
