using UnityEngine;
using System.Collections;

public class CreationDispatcher : MonoBehaviour
{
    public Transform commandCenterPrefab;
    public Transform refineryPrefab;
    public Transform powerPlantPrefab;
    public Transform minePrefab;
    public Transform siloPrefab;
    public Transform hangarPrefab;
    public Transform unitsFactoryPrefab;

    public Transform constructionSite;

    public void CreateBuilding(Vector3 position, Buildings type)
    {
        switch (type)
        {
            case Buildings.CommandCenter:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(commandCenterPrefab, position, commandCenterPrefab.rotation);
                    //newBuilding.GetComponent<MeshRenderer>().enabled = false;
                    //newBuilding.GetComponent<ConstructionSite>().constructionSite = constructionSite;
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = commandCenterPrefab;
                    cs.hitpointsMax = CommandCenter.hitpointsMax;
                    foreach (var item in CommandCenter.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.Refinery:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(refineryPrefab, position, refineryPrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = refineryPrefab;
                    cs.hitpointsMax = Refinery.hitpointsMax;
                    foreach (var item in Refinery.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.Mine:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(minePrefab, position, minePrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = minePrefab;
                    cs.hitpointsMax = Mine.hitpointsMax;
                    foreach (var item in Mine.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.Hangar:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(hangarPrefab, position, hangarPrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = hangarPrefab;
                    cs.hitpointsMax = Hangar.hitpointsMax;
                    foreach (var item in Hangar.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.UnitsFactory:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(unitsFactoryPrefab, position, unitsFactoryPrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = unitsFactoryPrefab;
                    cs.hitpointsMax = UnitsFactory.hitpointsMax;
                    foreach (var item in UnitsFactory.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.PowerPlant:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(powerPlantPrefab, position, powerPlantPrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = powerPlantPrefab;
                    cs.hitpointsMax = PowerPlant.hitpointsMax;
                    foreach (var item in PowerPlant.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
            case Buildings.Silo:
                {
                    //Transform newBuilding = (Transform)GameObject.Instantiate(siloPrefab, position, siloPrefab.rotation);
                    //AstarPath.active.UpdateGraphs(newBuilding.collider.bounds);
                    Transform newContruction = (Transform)GameObject.Instantiate(constructionSite, position, Quaternion.identity);
                    ConstructionSite cs = newContruction.GetComponent<ConstructionSite>();
                    cs.createdBuilding = siloPrefab;
                    cs.hitpointsMax = Silo.hitpointsMax;
                    foreach (var item in Silo.cost)
                    {
                        Colony.colonyResources[item.Key] -= item.Value;
                    }
                    break;
                }
        }
    }
}
