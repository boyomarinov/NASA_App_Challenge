using UnityEngine;
using System.Collections.Generic;

public class CommandCenter : Building
{
    public static Dictionary<ResourcesColony, double> cost;
    public Transform builderPrefab;
    private Queue<Transform> buildmentOrders;
    private Queue<Transform> builders;
    public static int hitpointsMax;

    static CommandCenter()
    {
        cost = new Dictionary<ResourcesColony, double>();
        cost.Add(ResourcesColony.Iron, 20000);
        cost.Add(ResourcesColony.Nickel, 450000);
        cost.Add(ResourcesColony.Gold, 300);
        hitpointsMax = 100000;
    }

    void Awake()
    {
        builders = new Queue<Transform>();
        buildmentOrders = new Queue<Transform>();
        GameObject[] currentAvailableUnits = GameObject.FindGameObjectsWithTag("builder");
        foreach (GameObject unit in currentAvailableUnits)
        {
            unit.GetComponent<AIPath>().target = transform;
        }
        currentAvailableUnits = null;
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.gameObject.tag == "builder")
        {
            Transform builder = other.gameObject.transform;
            if (builder.GetComponent<AIPath>().target == transform)
            {
                if (buildmentOrders.Count == 0)
                {
                    builder.GetComponent<MeshRenderer>().enabled = false;
                    //builder.GetComponent<AIPath>().enabled = false;
                    //builder.GetComponent<CharacterController>().enabled = false;
                    builder.Translate(Vector3.back);
                    //builder.RotateAroundLocal(builder.position, 180);
                    Transform newBuilder = (Transform)GameObject.Instantiate(builderPrefab, builder.position, builder.rotation);
                    //newBuilder.Translate(new Vector3(newBuilder.position.x, newBuilder.position.y - 200, newBuilder.position.z));
                    Destroy(builder.gameObject);

                    //newBuilder.GetComponent<MeshRenderer>().enabled = false;
                    builder.GetComponent<AIPath>().enabled = false;
                    newBuilder.GetComponent<CharacterController>().enabled = false;
                    
                    builders.Enqueue(newBuilder);
                }
                else
                {
                    builder.GetComponent<AIPath>().target = buildmentOrders.Dequeue();
                }
            }
            
        }
        else if (other.gameObject.tag == "collector")
        {

        }
        other = null;
    }

    public void AddBuildmentRequest(Transform constructionSite)
    {
        if (builders.Count > 0)
        {
            SendBuilder(builders.Dequeue(), constructionSite);
        }
        else
        {
            buildmentOrders.Enqueue(constructionSite);
        }
    }

    private void SendBuilder(Transform builder, Transform constructionSite)
    {
        builder.GetComponent<CharacterController>().enabled = true;
        //builder.GetComponent<MeshRenderer>().enabled = true;
        //builder.Translate(new Vector3(builder.position.x, builder.position.y + 200, builder.position.z));
        //builder.GetComponent<MeshRenderer>().enabled = true;
        builder.GetComponent<AIPath>().enabled = true;
        builder.GetComponent<AIPath>().target = constructionSite;
        builder.GetComponent<AIPath>().canSearch = true;
        
    }
}
