using UnityEngine;
using System.Collections.Generic;

public class LoadTruck : MonoBehaviour
{
    public Dictionary<Resources, int> CarriedGoods { get; protected set; }
    public Transform destinationFrom;
    public Transform destinationTo;

    void Start()
    {
        CarriedGoods = new Dictionary<Resources, int>();
        destinationTo = GetComponent<AIPath>().target;
    }

    public void ReturnToSender()
    {
        Transform temp = destinationFrom;
        destinationFrom = destinationTo;
        destinationTo = temp;
        gameObject.GetComponent<AIPath>().target = destinationTo;
    }
}
