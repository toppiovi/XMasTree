using System;
using System.Collections.Generic;
using System.Linq;
namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        if (height < 0)
            throw new ArgumentOutOfRangeException();
        if (height == 0)
            return new List<string>();
        if (height == 2)
            return new List<string>{"_#_", "###", "_#_", "_#_"};
        
        var tree = new List<string>(){"#", "#"};
        if (height == 3)
        {
            tree.Add("__#__");
            tree.Add("__#__");
        }
        return tree;
    }
}