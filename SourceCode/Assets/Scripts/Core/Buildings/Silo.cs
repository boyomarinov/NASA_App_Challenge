using UnityEngine;
using System.Collections.Generic;

public class Silo : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    public static int hitpointsMax;

    static Silo()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 10000);
        cost.Add(ResourcesColony.Nickel, 10000);
        cost.Add(ResourcesColony.Gold, 100);
        hitpointsMax = 5000;
    }
}
