using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitsFactory : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    
    public Transform builderPrefab;
    public Transform collectorPrefab;
    public Transform minerPrefab;
    public Transform bulldozerPrefab;

    private Transform commandCenter;

    public static int hitpointsMax;

    static UnitsFactory()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 10000);
        cost.Add(ResourcesColony.Nickel, 10000);
        cost.Add(ResourcesColony.Gold, 100);
        hitpointsMax = 5000;
    }

    public void CreateUnit(Units type)
    {
        switch (type)
        {
            case Units.Builder:
                StartCoroutine(InitUnit(builderPrefab, commandCenter));
                break;
            case Units.Miner:
                StartCoroutine(InitUnit(minerPrefab, GameObject.FindGameObjectWithTag("mine").transform));
                break;
            case Units.Collector:
                StartCoroutine(InitUnit(collectorPrefab, GameObject.FindGameObjectWithTag("mine").transform));
                break;
            case Units.Bulldozer:
                //StartCoroutine(InitUnit(bulldozerPrefab));
                break;
            default:
                Debug.LogError("Bad unit type!");
                break;
        }
        
    }

    IEnumerator InitUnit(Transform type, Transform destination)
    {
        yield return new WaitForSeconds(3);
        Transform unit = (Transform)GameObject.Instantiate(type, new Vector3(transform.position.x, type.position.y, transform.position.z + 25), Quaternion.identity);
        unit.GetComponent<AIPath>().target = destination;
    }

    void Start()
    {
        commandCenter = GameObject.FindGameObjectWithTag("command-center").transform;
        Colony.requestedPower += 20;
        GameMenu.UpdateEnergyLevel();
    }
}
