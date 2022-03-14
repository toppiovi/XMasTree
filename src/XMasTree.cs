namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        var xmas = new XMas(height);
        return xmas.GrowTree();
    }

    private int height;
    private int treeWidth;
    private int paddingWidth;

    public XMas(int height)
    {
        if (height < 0)
            throw new ArgumentOutOfRangeException();

        this.height = height;
    }

    public List<string> GrowTree()
    {
        if (height == 0)
            return new List<string>();

        var leaves = GrowLeaves();
        var tree = GrowTrunk(leaves);
        return tree;
    }

    private List<string> GrowLeaves()
    {
        var leaves = new List<string>();
        treeWidth = 1;
        paddingWidth = MaxPaddingWidth();
        
        for (int i = 0; i < height; i++)
            GrowNextRowOfLeaves(leaves);

        return leaves;
    }

    private int MaxPaddingWidth() => height-1;

    private void GrowNextRowOfLeaves(List<string> leaves)
    {
        leaves.Add(PaddedTreeRow());
        treeWidth += 2;
        paddingWidth--;
    }

    private List<string> GrowTrunk(List<string> tree)
    {
        tree.Add(PaddedTrunk());
        if (height > 1)
            tree.Add(PaddedTrunk());
        return tree;
    }

    private string PaddedTrunk()
    {
        treeWidth = 1;
        paddingWidth = MaxPaddingWidth();
        return PaddedTreeRow();
    }

    private string PaddedTreeRow()
    {
        var treePart = InitStringWith('#', treeWidth);
        return AddPadding(treePart);
    }

    private string AddPadding(string treePart)
    {
        var padding = InitStringWith('_', paddingWidth);
        return padding + treePart + padding;
    }

    private static string InitStringWith(char value, int n) {
        return new String(Enumerable.Repeat(value, n).ToArray());
    }
}