using UnityEngine;
using System.Collections;

public class MouseClickHandler : MonoBehaviour
{
    bool orderForBuildPlaced;
    public LayerMask mask;
    public Transform target;
    Camera cam;
    Buildings building;
    CreationDispatcher creator;

    public void Start()
    {
        cam = Camera.main;
        creator = GameObject.Find("CreationDispatcher").GetComponent<CreationDispatcher>();
    }

    void Update()
    {
        if (orderForBuildPlaced && Input.GetMouseButtonUp(0))
        {
            creator.CreateBuilding(GetMouseClickPosition(), building);
            orderForBuildPlaced = false;
        }
    }

    public void PlaceOrderForBuildment(Buildings type)
    {
        building = type;
        orderForBuildPlaced = true;
    }

    public Vector3 GetMouseClickPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
        {
            return new Vector3(hit.point.x, hit.point.y + .1f, hit.point.z);
        }

        return new Vector3();
    }
}
