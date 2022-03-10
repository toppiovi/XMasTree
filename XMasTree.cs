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
            GrowWidestPart(tree, height);
        }
        if (height == 2)
        {
            tree.Insert(0,CreatePartWithPadding(1,2));
        }
        if (height == 3)
        {
            tree.Insert(0,CreatePartWithPadding(3,2));
            tree.Insert(0,CreatePartWithPadding(1,4));
        }

        return tree;
    }

    private static void GrowTrunkWithPadding(List<string> tree, int height)
    {
        for (int i = 0; i < 2; i++)
        {
            var padding = StringFrom('_', height-1);
            tree[i] = padding + tree[i] + padding;
        }
    }

    private static void GrowWidestPart(List<string> tree, int height)
    {
        var widestPart = StringFrom('#', (height*2)-1);
        tree.Insert(0, widestPart);
    }

    private static string CreatePartWithPadding(int treeWidth, int totalPaddingWidth)
    {
        var padding = StringFrom('_', totalPaddingWidth/2);
        var leaves = StringFrom('#', treeWidth);
        return padding + leaves + padding;
    }

    private static string StringFrom(char value, int n) {
        return new String(Enumerable.Repeat(value, n).ToArray());
    }
}