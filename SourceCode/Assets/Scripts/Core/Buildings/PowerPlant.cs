using UnityEngine;
using System.Collections.Generic;

public class PowerPlant : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    public static int hitpointsMax;

    static PowerPlant()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 10000);
        cost.Add(ResourcesColony.Nickel, 10000);
        cost.Add(ResourcesColony.Gold, 100);
        hitpointsMax = 5000;
    }

    void Start()
    {
        Colony.colonyPower += 50;
        GameMenu.UpdateEnergyLevel();
    }
}
