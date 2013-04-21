using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
    public int hitpointsCurrent = 0;
    public static Building selectedBuilding;

    public List<GameObject> AvailableUnits {get; protected set;} // UNITS CURRENTLY INSIDE THE BUILDING LIKE MAINTENANCE PERSONAL OR AVAILABLE UNITS
    //protected Dictionary<Resources, double> storedGoods;
}
