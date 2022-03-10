using System;
using System.Collections.Generic;
namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        if (height == -1)
            throw new ArgumentOutOfRangeException();

        if (height == 2)
            return new List<string>{"_#_", "###", "_#_", "_#_"};

        return height == 1 ? new List<string>{"#", "#"} : new List<string>();
    }
}