using System.Collections.Generic;

static class KeyToIndexDictionary {

    static Dictionary<string, int> _dict = new Dictionary<string, int>
    {
        //music reactive
        {"1", 0},
        {"2", 1},
        {"3", 2},
        {"4", 3},
        {"5", 4},
        {"6", 5},
        {"7", 6},
        {"8", 7},
        {"9", 8},
        {"0", 9},
        {"q", 10},
        {"w", 11},
        {"e", 12},
        {"r", 13},
        {"t", 14},
        //backgrounds
        {"y", 15},
        {"u", 16},
        {"i", 17},
        {"o", 18},
        {"p", 19},
        {"a", 20},
        {"s", 21},
        {"d", 22},
        {"f", 23},
        {"g", 24},
        {"h", 25},
        {"j", 26},
        {"k", 27},
        {"l", 28},
        {";", 29}
    };

    public static int GetIndex( string keyString ) {
        int result;
        if ( _dict.TryGetValue( keyString, out result ) ) {
            return result;
        }
        else {
            return 9999;
        }
    }
}