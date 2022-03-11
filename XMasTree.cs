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

        var tree = GrowLeaves(height);
        AddPaddedTrunk(tree, height);

        return tree;
    }

    private static List<string> GrowLeaves(int height)
    {
        var tree = new List<string>();
        int treeWidth = 1;
        int totalPaddingWidth = (height-1)*2;
        
        for (int i = 0; i < height; i++)
        {
            tree.Add(PaddedTreePart(treeWidth, totalPaddingWidth));
            treeWidth += 2;
            totalPaddingWidth -= 2;
        }

        return tree;
    }
    private static void AddPaddedTrunk(List<string> tree, int height)
    {
        tree.Add(PaddedTrunk(height));
        if (height > 1)
            tree.Add(PaddedTrunk(height));
    }

    private static string PaddedTrunk(int height)
    {
        return PaddedTreePart(1, (height-1)*2);
    }

    private static string PaddedTreePart(int treeWidth, int totalPaddingWidth)
    {
        var treePart = InitStringWith('#', treeWidth);
        if (NoPaddingRequired(totalPaddingWidth))
            return treePart;

        return AddPadding(treePart, totalPaddingWidth);
    }

    private static bool NoPaddingRequired(int totalPaddingWidth)
    {
        return totalPaddingWidth == 0;
    }
    private static string AddPadding(string treePart, int totalPaddingWidth)
    {
        var padding = InitStringWith('_', totalPaddingWidth/2);
        return padding + treePart + padding;
    }

    private static string InitStringWith(char value, int n) {
        return new String(Enumerable.Repeat(value, n).ToArray());
    }
}