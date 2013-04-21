using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mine : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    public static Dictionary<ResourcesColony, double> storedGoods;
    public Transform regulitPositionPrefab;
    public static int hitpointsMax;
    private Vector3[] regolitPositions;
    private int currentRegolitPosition;

    static Mine()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 500);
        //cost.Add(Resource.Nickel, 10000);
        //cost.Add(Resource.Gold, 100);
        hitpointsMax = 3000;
    }

    void Start()
    {
        storedGoods = new Dictionary<ResourcesColony, double>();
        Vector3 center = collider.bounds.center;
        currentRegolitPosition = 0;
        Colony.requestedPower += 12;
        regolitPositions = new Vector3[5];
        regolitPositions[0] = new Vector3(center.x - 20, .2f, center.z - 20);
        regolitPositions[1] = new Vector3(center.x - 35, .2f, center.z - 44);
        regolitPositions[2] = new Vector3(center.x - 43, .2f, center.z + 66);
        regolitPositions[3] = new Vector3(center.x + 53, .2f, center.z - 65);
        regolitPositions[4] = new Vector3(center.x + 34, .2f, center.z + 23);

        GameObject[] miners = GameObject.FindGameObjectsWithTag("miner");
        foreach (var miner in miners)
        {
            if (miner.GetComponent<AIPath>().target == null)
            {
                miner.GetComponent<AIPath>().canSearch = true;
                miner.GetComponent<AIPath>().target = transform;
            }
        }
        GameMenu.UpdateEnergyLevel();
    }

    void OnTriggerEnter(Collider visitor)
    {
        if (visitor.gameObject.tag == "miner" && visitor.gameObject.GetComponent<AIPath>().target == transform)
        {
            visitor.gameObject.transform.GetComponent<AIPath>().canMove = false;
            StartCoroutine(BeginUnloading(visitor.gameObject.transform));
        }
        else if (visitor.gameObject.tag == "collector" && visitor.gameObject.GetComponent<AIPath>().target == transform)
        {
            visitor.gameObject.transform.GetComponent<AIPath>().canMove = false;
            StartCoroutine(BeginLoading(visitor.gameObject.transform));
        }
    }

    void AdjustGoods(Dictionary<ResourcesColony, double> cargo)
    {
        foreach (var item in cargo)
        {
            AdjustGood(item.Key, item.Value);
        }
    }

    void AdjustGood(ResourcesColony type, double amount)
    {
        if (!storedGoods.ContainsKey(type))
        {
            storedGoods.Add(type, 0);
        }
        storedGoods[type] += amount;
        Colony.AdjustResource(type, amount);
    }

    IEnumerator BeginUnloading(Transform miner)
    {
        if (currentRegolitPosition > 4)
        {
            currentRegolitPosition = 0;
        }
        miner.GetComponent<AIPath>().target = (Transform)(GameObject.Instantiate(regulitPositionPrefab, regolitPositions[currentRegolitPosition++], Quaternion.identity));
        miner.GetComponent<Miner>().Sender = transform;
        AdjustGoods(miner.GetComponent<Miner>().carriedGoods);
        List<ResourcesColony> availableResources = new List<ResourcesColony>();
        foreach (var item in storedGoods)
        {
            availableResources.Add(item.Key);
        }
        miner.GetComponent<Miner>().UnloadResources(availableResources.ToArray());
        yield return new WaitForSeconds(10);
        miner.GetComponent<AIPath>().canMove = true;
    }

    IEnumerator BeginLoading(Transform collector)
    {
        collector.GetComponent<AIPath>().target = collector.GetComponent<Collector>().Sender;
        //collector.GetComponent<Miner>().Sender = transform;
        //AdjustGoods(collector.GetComponent<Miner>().carriedGoods);
        //List<ResourcesColony> availableResources = new List<ResourcesColony>();
        //foreach (var item in storedGoods)
        //{
        //    availableResources.Add(item.Key);
        //}
        collector.GetComponent<Collector>().AddResources(ResourcesColony.Regolith, storedGoods[ResourcesColony.Regolith]);
        Colony.AdjustResource(ResourcesColony.Regolith, -storedGoods[ResourcesColony.Regolith]);
        storedGoods[ResourcesColony.Regolith] = 0;
        yield return new WaitForSeconds(3);
        collector.Translate(Vector3.back);
        collector.GetComponent<AIPath>().canMove = true;
    }
}
