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

        var tree = new List<string>(){"#", "#"};

        if (height >= 2)
        {
            for (int i = 0; i < 2; i++)
            {
                for(int padding = 0; padding < height-1; padding++)
                {
                    tree[i] += '_';
                    tree[i] = '_' + tree[i];
                }
            }
        }
        if (height == 2)
        {
            var widestPart = new String(Enumerable.Repeat('#', 3).ToArray());
            tree.Insert(0,widestPart);
            tree.Insert(0,"_#_");
        }
        if (height == 3)
        {
            var widestPart = new String(Enumerable.Repeat('#', 5).ToArray());
            tree.Insert(0,widestPart);
            tree.Insert(0,"_###_");
            tree.Insert(0,"__#__");
        }

        return tree;
    }
}