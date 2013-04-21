using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class StartMenu : MonoBehaviour
{
    public bool isMiner = false;
    public bool isBuilder = false;
    public bool isBulldozer = false;
    public bool isCollector = false;

    public bool isRichMan = false;
    public bool isNasa = false;

    public bool isLaunch = false;
    public bool isAbout = false;
    public Texture2D buildTexture;


    //private bool colonyClicked = false;
    //private bool buildingClicked = false;
    //private bool machinesClicked = false;
    //private bool resourcesClicked = false;
    //private bool budgetClicked = false;
    //private bool economyClicked = false;
    //private bool earthClicked = false;
    //private bool settingsClicked = false;
    //private bool helpClicked = false;
    //private bool closeClicked = false;
    public static int Money = 10000000;

    /// <summary>
    /// This static field will keep the start package, player has chose, to sent to the moon
    /// </summary>
    /// 
   

    public static Dictionary<Units, int> chosenUnitsForStartPackage = new Dictionary<Units, int>()
    {
        {Units.Builder,0},
        {Units.Bulldozer,0},
        {Units.Collector,0},
        {Units.Miner,0},
    };

    /// <summary>
    /// When hoover with mouse make text red or cyan(depends of scenes and objects)
    /// </summary>
    void OnMouseEnter()
    {
        if (isMiner || isBuilder || isBulldozer || isCollector || isRichMan || isNasa)
        {
            renderer.material.color = Color.cyan;
            this.audio.Play();

        }

        if(isLaunch || isAbout)
        {
            renderer.material.color = Color.red;
            this.audio.Play();
        }
    }

    /// <summary>
    /// When move out mouse from text, set it again to white(reset color)
    /// </summary>
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    /// <summary>
    /// When text is clicked
    /// </summary>
    void OnMouseDown()
    {
        if (isAbout)
        {
            // рнDн Application.LoadLevel(0);
        }
        else if (isLaunch)
        {
            Application.LoadLevel(1);
        }
        else if (isMiner)
        {
            if (!(Money < 1000000))
            {
                Money -= 1000000;
                chosenUnitsForStartPackage[Units.Miner]++;
            }
        }
        else if (isBuilder)
        {
            if (!(Money < 5000000))
            {
                Money -= 5000000;
                chosenUnitsForStartPackage[Units.Builder]++;
            }
        }
        else if (isBulldozer)
        {
            if (!(Money < 1000000))
            {
                Money -= 1000000;
                chosenUnitsForStartPackage[Units.Bulldozer]++;
            }
        }
        else if (isCollector)
        {
            if (!(Money < 1000000))
            {
                Money -= 1000000;
                chosenUnitsForStartPackage[Units.Collector]++;
            }
        }
        else if (isRichMan)
        {
            // TODO
        }
        else if (isNasa)
        {
            // TODO
        }
        else
        {
            //Application.LoadLevel(0);
        }
    }

    
    //// Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    void Update()
    {
        //foreach (var item in chosenUnitsForStartPackage)
        //{
        //    Debug.Log(item.Value + " " + item.Key);
        //}
        //Debug.Log(Money);
    }
}

