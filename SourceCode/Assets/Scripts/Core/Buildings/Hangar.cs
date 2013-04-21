using UnityEngine;
using System.Collections.Generic;

public class Hangar : Building
{
    public static int hitpointsMax;
    public static Dictionary<ResourcesColony, double> cost;
    static Hangar()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 10000);
        cost.Add(ResourcesColony.Nickel, 10000);
        cost.Add(ResourcesColony.Gold, 100);
        hitpointsMax = 5000;
    }

    void Start()
    {
        Colony.requestedPower += 4;
        GameMenu.UpdateEnergyLevel();
    }
}
