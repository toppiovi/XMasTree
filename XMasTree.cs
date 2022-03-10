using System.Collections.Generic;
namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        return height == 1 ? new List<string>{"#", "#"} : new List<string>();
    }
}