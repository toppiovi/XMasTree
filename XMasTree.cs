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
        if (height == 1)
            return new List<string>{"#", "#"};

        var tree = new List<string>();
        int treeWidth = 1;
        int totalPaddingWidth = (height-1)*2;
        
        for (int i = 0; i < height; i++)
        {
            tree.Add(CreatePartWithPadding(treeWidth, totalPaddingWidth));
            treeWidth += 2;
            totalPaddingWidth -= 2;
        }
        
        GrowTrunkWithPadding(tree, height);

        return tree;
    }

    private static void GrowTrunkWithPadding(List<string> tree, int height)
    {
        for (int i = 0; i < 2; i++)
        {
            tree.Add(CreatePartWithPadding(1, (height-1)*2));
        }
    }

    private static string CreatePartWithPadding(int treeWidth, int totalPaddingWidth)
    {
        var leaves = StringFrom('#', treeWidth);
        if (totalPaddingWidth == 0)
            return leaves;

        var padding = StringFrom('_', totalPaddingWidth/2);
        return padding + leaves + padding;
    }

    private static string StringFrom(char value, int n) {
        return new String(Enumerable.Repeat(value, n).ToArray());
    }
}