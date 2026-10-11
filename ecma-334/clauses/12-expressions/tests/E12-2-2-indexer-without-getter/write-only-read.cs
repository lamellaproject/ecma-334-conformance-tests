/*
Rules: E12-2-2-indexer-without-getter
Authority: ECMA-334 7th ed 12.2.2
Version: 7.3
Expected: reject
Mutate: int value = box[2];
Into: box[2] = 7;
*/
class Box { public int this[int index] { set { } } }
class Program { static void Main() { Box box = new Box(); int value = box[2]; } }
