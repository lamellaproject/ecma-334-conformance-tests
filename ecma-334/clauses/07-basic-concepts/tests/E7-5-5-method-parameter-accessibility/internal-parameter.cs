/*
Rules: E7-5-5-method-parameter-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal class Hidden
Into: public class Hidden
*/
internal class Hidden { }
public class Api { public void Write(Hidden value) { } }
class Program { static void Main() { } }
