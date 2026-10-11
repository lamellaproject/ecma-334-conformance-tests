/*
Rules: E7-5-5-delegate-return-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal class Hidden
Into: public class Hidden
*/
internal class Hidden { }
public delegate Hidden Factory();
class Program { static void Main() { } }
