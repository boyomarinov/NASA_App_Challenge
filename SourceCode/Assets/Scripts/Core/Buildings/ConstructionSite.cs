using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructionSite : MonoBehaviour
{
    private int hitpointsCurrent;
    public int hitpointsMax;
    bool constructionStarted = false;
    public Transform createdBuilding;
    MeshRenderer buildingMR;
    MeshRenderer unitMR;
    Bounds bounds;
    Transform unit;
    AIPath unitPath;
    Transform commandCenter;

    void Start()
    {
        commandCenter = GameObject.FindGameObjectWithTag("command-center").transform;
        hitpointsCurrent = 0;
        createdBuilding = (Transform)GameObject.Instantiate(createdBuilding, transform.position, Quaternion.identity);
        AstarPath.active.UpdateGraphs(createdBuilding.collider.bounds);
        //buildingMR = createdBuilding.GetComponent<MeshRenderer>();
        //buildingMR.enabled = false;
        bounds = createdBuilding.collider.bounds;
        Vector3 boundsSize = bounds.size;
        transform.localScale = new Vector3(boundsSize.x + 10, boundsSize.y, boundsSize.z + 10);
        transform.position = bounds.center;

        //REQUEST BUILDMENT ORDER
        commandCenter.GetComponent<CommandCenter>().AddBuildmentRequest(transform);
    }

    void LateUpdate()
    {
        if (!constructionStarted && unit != null && hitpointsCurrent < hitpointsMax)
        {
            constructionStarted = true;
            StartCoroutine(BuildYourself());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "builder" && other.gameObject.GetComponent<AIPath>().target == transform)
        {
            unit = other.transform;
            //Destroy(other.gameObject);
            //other.gameObject.GetComponent<AIPath>().canSearch = false;
            //unitMR = unit.GetComponent<MeshRenderer>();
            //unitMR.enabled = false;
            unitPath = unit.GetComponent<AIPath>();
            unitPath.enabled = false;
        }
    }

    IEnumerator BuildYourself()
    {
        while (hitpointsCurrent < hitpointsMax)
        {
            yield return new WaitForSeconds(2);
            hitpointsCurrent += 20000;
            if (hitpointsCurrent > hitpointsMax)
            {
                hitpointsCurrent = hitpointsMax;
            }
        }
        //buildingMR.enabled = true;
        //gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        //unitMR.enabled = true;
        unitPath.enabled = true;
        unitPath.target = (commandCenter);
        Destroy(gameObject);
    }
}
