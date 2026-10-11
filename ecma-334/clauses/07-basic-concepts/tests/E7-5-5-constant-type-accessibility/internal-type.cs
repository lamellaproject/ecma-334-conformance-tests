/*
Rules: E7-5-5-constant-type-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal enum Hidden
Into: public enum Hidden
*/
internal enum Hidden { Selected }
public class Api { public const Hidden Value = Hidden.Selected; }
class Program { static void Main() { } }
