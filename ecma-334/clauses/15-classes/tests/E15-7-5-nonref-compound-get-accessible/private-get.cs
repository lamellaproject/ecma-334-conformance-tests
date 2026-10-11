/*
Rules: E15-7-5-nonref-compound-get-accessible
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: private get
Into: get
*/
class Box { int slot; public int Item { private get { return slot; } set { slot = value; } } }
class Program { static void Main() { Box box = new Box(); box.Item += 4; } }
