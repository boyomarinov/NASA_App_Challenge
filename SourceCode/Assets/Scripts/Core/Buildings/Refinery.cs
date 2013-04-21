using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refinery : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    //public static Dictionary<ResourcesColony, double> storedGoods;
    public static int hitpointsMax;

    static Refinery()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 1000);
        //cost.Add(Resources.Nickel, 10000);
        //cost.Add(Resources.Gold, 100);
        hitpointsMax = 6000;
    }

    void Start()
    {
        GameObject[] collectors = GameObject.FindGameObjectsWithTag("collector");
        foreach (var collector in collectors)
        {
            if (collector.GetComponent<AIPath>().target == null)
            {
                collector.GetComponent<AIPath>().canSearch = true;
                collector.GetComponent<AIPath>().target = transform;
            }
        }
        Colony.requestedPower += 5;
        GameMenu.UpdateEnergyLevel();
    }

    void OnTriggerEnter(Collider visitor)
    {
        //Destroy(visitor.gameObject);
        if (visitor.gameObject.tag == "collector" && visitor.gameObject.GetComponent<AIPath>().target == transform)
        {
            visitor.gameObject.transform.GetComponent<AIPath>().canMove = false;
            //Destroy(visitor.gameObject);
            StartCoroutine(BeginUnloading(visitor.gameObject.transform));
        }
    }

    void AdjustGoods(Dictionary<ResourcesColony, double> cargo)
    {
        Dictionary<ResourcesColony, double> cargoDistributed = new Dictionary<ResourcesColony, double>();
        foreach (var item in cargo)
        {
            if (item.Key == ResourcesColony.Regolith && item.Value > 0)
            {
                cargoDistributed.Add(ResourcesColony.Silica, Mathf.Round((float)item.Value * .40F));
                cargoDistributed.Add(ResourcesColony.Titanium, Mathf.Round((float)item.Value * .1F));
                cargoDistributed.Add(ResourcesColony.Aluminium, Mathf.Round((float)item.Value * .132F));
            }
            else if(item.Value > 0)
            {
                cargoDistributed.Add(item.Key, item.Value);
            }
        }
        
        foreach (var item in cargoDistributed)
        {
            AdjustGood(item.Key, item.Value);
        }
    }

    void AdjustGood(ResourcesColony type, double amount)
    {
        Colony.AdjustResource(type, amount);
    }

    IEnumerator BeginUnloading(Transform collector)
    {
        collector.GetComponent<AIPath>().target = GameObject.FindGameObjectWithTag("mine").transform;
        collector.GetComponent<Collector>().Sender = transform;
        AdjustGoods(collector.GetComponent<Collector>().carriedGoods);

        collector.GetComponent<Collector>().UnloadResources(new ResourcesColony[] { ResourcesColony.Regolith });
        yield return new WaitForSeconds(3);
        collector.GetComponent<AIPath>().canMove = true;
    }
}
