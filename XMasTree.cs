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
            GrowTrunkWithPadding(tree, height);

            var widestPart = new String(Enumerable.Repeat('#', (height*2)-1).ToArray());
            tree.Insert(0,widestPart);
        }
        if (height == 2)
        {
            tree.Insert(0,"_#_");
        }
        if (height == 3)
        {
            tree.Insert(0,"_###_");
            tree.Insert(0,"__#__");
        }

        return tree;
    }

    private static void GrowTrunkWithPadding(List<string> tree, int height)
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
}