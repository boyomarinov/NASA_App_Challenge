using UnityEngine;
using System.Collections;

public class ShowStartMoney : MonoBehaviour {
    public string moneySpend = string.Empty;
    public string countOfBuilderString = string.Empty;
    public string countOfCollectorString = string.Empty;
    public string countOfMinerString = string.Empty;
    public string countOfBulldozerString = string.Empty;

    void OnGUI()
    {
        // TODO GUI.backgroundColor = Color.red;

        //dipslay money
        int moneyResult = StartMenu.Money;
        GUI.skin.label.normal.textColor = Color.green;
        if (moneyResult <= 0)
        {
             GUI.skin.label.normal.textColor = Color.red;
        }
        moneySpend = "Budget: " + moneyResult;
        GUI.Label(new Rect(120, 70, 200, 500), moneySpend);

        //display count of Builder
        int builderCount = StartMenu.chosenUnitsForStartPackage[Units.Builder];
        GUI.skin.label.normal.textColor = Color.green;
        countOfBuilderString = builderCount + " X Builder";
        GUI.Label(new Rect(350, 70, 100, 50), countOfBuilderString);

        //display count of Bulldozer
        int buldozerCount = StartMenu.chosenUnitsForStartPackage[Units.Bulldozer];
        GUI.skin.label.normal.textColor = Color.green;
        countOfBulldozerString = buldozerCount + " X Bulldozer";
        GUI.Label(new Rect(550, 70, 100, 50), countOfBulldozerString);

        //display count of Collector
        int collectorCount = StartMenu.chosenUnitsForStartPackage[Units.Collector];
        GUI.skin.label.normal.textColor = Color.green;
        countOfCollectorString = collectorCount + " X Collector";
        GUI.Label(new Rect(450, 70, 100, 50), countOfCollectorString);

        //display count of Miner
        int minerCount = StartMenu.chosenUnitsForStartPackage[Units.Miner];
        GUI.skin.label.normal.textColor = Color.green;
        countOfMinerString = minerCount + " X Miner";
        GUI.Label(new Rect(650, 70, 100, 50), countOfMinerString);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //// Use this for initialization
    //void Start () {
	
    //}

    
}
