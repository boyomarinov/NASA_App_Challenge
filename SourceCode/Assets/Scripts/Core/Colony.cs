using UnityEngine;
using System.Collections.Generic;

public class Colony : MonoBehaviour
{
    public static Dictionary<ResourcesColony, double> colonyResources;

    public static int colonyPower;
    public static int requestedPower;

    void Start()
    {
        colonyPower = 20;
        requestedPower = 15;
        colonyResources = new Dictionary<ResourcesColony, double>();
        colonyResources.Add(ResourcesColony.Iron, 100000);
        colonyResources.Add(ResourcesColony.Gold, 100000);
        colonyResources.Add(ResourcesColony.Nickel, 100000);
        //colonyResources.Add(ResourcesColony.Regolith, 0);
    }

    public static void AdjustResource(ResourcesColony type, double amount)
    {
        if (colonyResources.ContainsKey(type))
        {
            colonyResources[type] += amount;
        }
        else
        {
            colonyResources.Add(type, 0);
            AdjustResource(type, amount);
        }
    }
}
