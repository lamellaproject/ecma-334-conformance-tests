/*
Rules: E15-7-5-accessor-modifier-no-overload-effect; E15-7-5-property-modifiers-determine-binding
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: box[1]
Into: box[(long)1]
*/
class Box
{
    public int this[int index] { private get { return 15; } set { } }
    public int this[long index] { get { return 28; } set { } }
}
class Program { static void Main() { Box box = new Box(); int seen = box[1]; } }
