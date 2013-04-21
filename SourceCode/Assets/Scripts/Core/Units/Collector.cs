using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collector : MonoBehaviour
{
    public Dictionary<ResourcesColony, double> carriedGoods;
    public Transform Sender { get; set; }

    void Start()
    {
        carriedGoods = new Dictionary<ResourcesColony, double>();
        carriedGoods.Add(ResourcesColony.Regolith, 0);
    }

    public void UnloadResources(ResourcesColony[] cargo)
    {
        foreach (var item in cargo)
        {
            carriedGoods[item] = 0;
        }
    }

    public void AddResources(ResourcesColony type, double amount)
    {
        carriedGoods[type] += amount;
    }
}
