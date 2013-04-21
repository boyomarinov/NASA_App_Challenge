using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class GameMenu : MonoBehaviour
{
    public bool mainMenu;
    string test;
    bool build;
    bool affordable;
    MouseClickHandler click;
    public Texture2D buildTexture;

    public Texture2D ColonyButton;
    public Texture2D BuildingButton;
    public Texture2D MachinesButton;
    public Texture2D ResourceButton;
    public Texture2D BudgetButton;
    public Texture2D EconomyButton;
    public Texture2D EarthButton;
    public Texture2D FrameBackground_KD;
    public Texture2D Logo_KD;
    public Texture2D FrameMoon_KD;
    public Texture2D FrameLeft_KD;
    public Texture2D FrameRight_KD;
    public Texture2D FrameTopLeft_KD;
    public Texture2D FrameTopRight_KD;
    public Texture2D FrameTopMiddle_KD;
    public Texture2D FrameBottomMiddle_KD;
    public Texture2D FrameBottomLeft_KD;
    public Texture2D FrameBottomRight_KD;
    public Texture2D ButtonsBG_KD;

    public Texture2D SettingsButton;
    public Texture2D HelpButton;
    public Texture2D CloseButton;

    private Vector2 scrollViewVector = Vector2.zero;

    public Texture2D topBoxTextureColony;
    public Texture2D topBoxTextureBuilding;
    public Texture2D topBoxTextureMachines;
    public Texture2D topBoxTextureResources;
    public Texture2D topBoxTextureBudget;
    public Texture2D topBoxTextureEconomy;
    public Texture2D topBoxTextureEarth;
    public Texture2D topBoxTextureSettings;
    public Texture2D topBoxTextureHelp;
    //public Texture2D topBoxTextureClose;

    public Texture2D BackgroundUnitInfo;

    public Texture2D CommandCenterTexture;
    public Texture2D RafineryTexture;
    public Texture2D HangarTexture;
    public Texture2D SiloTexture;
    public Texture2D MineTexture;
    public Texture2D UnitsFactoryTexture;
    public Texture2D PowerPlantTexture;

    //Menu backgrounds
    public Texture2D BudgetBG_KD;

    public Texture2D EnergyBar_KD;
    public Texture2D EnergyBarBW_KD;

    public Texture2D BuildButton_KD;

    public Texture2D builderTexture;
    public Texture2D collectorTexture;
    public Texture2D minerTexture;
    public Texture2D bulldozerTexture;

    private bool colonyClicked = false;
    private bool buildingClicked = false;
    private bool machinesClicked = false;
    private bool resourcesClicked = false;
    private bool budgetClicked = false;
    private bool economyClicked = false;
    private bool earthClicked = false;
    private bool settingsClicked = false;
    private bool helpClicked = false;
    private bool closeClicked = false;
    Vector3 cameraStartingPosition;
    public static float PowerLevel { get; set; }
    private Dictionary<Buildings, Texture2D> buildingImagesDatabase;
    private Dictionary<Units, Texture2D> unitsImagesDatabase;

    void Start()
    {
        //PowerLevel = .10f;
        UpdateEnergyLevel();
        cameraStartingPosition = transform.position;
        buildingImagesDatabase = new Dictionary<Buildings, Texture2D>();
        unitsImagesDatabase = new Dictionary<Units, Texture2D>();
        AddBuildingsTextures();
        AddUnitsTextures();
        Database.FillData();
        click = GetComponent<MouseClickHandler>();
    }

    private void AddUnitsTextures()
    {
        unitsImagesDatabase.Add(Units.Builder, builderTexture);
        unitsImagesDatabase.Add(Units.Bulldozer, bulldozerTexture);
        unitsImagesDatabase.Add(Units.Collector, collectorTexture);
        unitsImagesDatabase.Add(Units.Miner, minerTexture);
    }

    public static void UpdateEnergyLevel()
    {
        int capacity = Colony.colonyPower;
        int used = Colony.requestedPower;

        PowerLevel = (capacity - used) * 100 / capacity;
        if (PowerLevel < 0)
        {
            PowerLevel = 0;
        }
        if (PowerLevel > 100)
        {
            PowerLevel = 100;
        }
        // DrawTexture height: 200 - koef*200/100
    }

    void AddBuildingsTextures()
    {
        buildingImagesDatabase.Add(Buildings.CommandCenter, CommandCenterTexture);
        buildingImagesDatabase.Add(Buildings.Refinery, RafineryTexture);
        buildingImagesDatabase.Add(Buildings.Hangar, HangarTexture);
        buildingImagesDatabase.Add(Buildings.Silo, SiloTexture);
        buildingImagesDatabase.Add(Buildings.Mine, MineTexture);
        buildingImagesDatabase.Add(Buildings.UnitsFactory, UnitsFactoryTexture);
        buildingImagesDatabase.Add(Buildings.PowerPlant, PowerPlantTexture);
    }

    void OnGUI()
    {
        GUIStyle buttonStyle = new GUIStyle();
        buttonStyle.normal.background = null;

        GUIStyle designStyle = new GUIStyle();


        //Top and Bottom middle frame
        GUI.DrawTexture(new Rect(0, 0, Screen.width, 128), FrameTopMiddle_KD);
        GUI.DrawTexture(new Rect(0, Screen.height - 128, Screen.width, 128), FrameBottomMiddle_KD);

        //Left and Right middle frame
        GUI.DrawTexture(new Rect(0, 0, 128, Screen.height), FrameLeft_KD);
        GUI.DrawTexture(new Rect(Screen.width - 128, 0, 128, Screen.height), FrameRight_KD);

        //Frame corners
        GUI.Box(new Rect(Screen.width - 128, 0, 128, 128), FrameTopRight_KD, designStyle);
        GUI.Box(new Rect(0, 0, 128, 128), FrameTopLeft_KD, designStyle);
        GUI.Box(new Rect(Screen.width - 128, Screen.height - 128, 128, 128), FrameBottomRight_KD, designStyle);
        GUI.Box(new Rect(0, Screen.height - 128, 128, 128), FrameBottomLeft_KD, designStyle);

        GUI.Box(new Rect(0, 0, 1024, 1024), FrameMoon_KD, designStyle);
        GUI.Box(new Rect(100, 0, 512, 128), ButtonsBG_KD, designStyle);

        GUI.Box(new Rect(Screen.width - 256, 0, 256, 64), Logo_KD, designStyle);

        //Energy Bar
        //GUI.DrawTexture(new Rect(Screen.width - 33, Screen.height - 232, 30, 200 * .5f), EnergyBarBW_KD, ScaleMode.ScaleAndCrop);
        GUI.Box(new Rect(Screen.width - 33, Screen.height - 232, 30, 200), EnergyBar_KD, designStyle);
        GUI.DrawTexture(new Rect(Screen.width - 33, Screen.height - 232, 25, 200 - PowerLevel * 200 / 100), EnergyBarBW_KD, ScaleMode.ScaleAndCrop);
        //GUI.Box(new Rect(Screen.width - 33, Screen.height - 232, 30, 200 * .5f), EnergyBarBW_KD, designStyle);

        if (!mainMenu)
        {
            if (GUI.Button(new Rect(130, 35, 30, 30), ColonyButton, buttonStyle))
            {
                this.audio.Play();
                //colonyClicked = !ClearButtons(colonyClicked);
                transform.position = cameraStartingPosition;
                colonyClicked = false;
            }

            if (GUI.Button(new Rect(170, 35, 30, 30), BuildingButton, buttonStyle))
            {
                buildingClicked = !ClearButtons(buildingClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(210, 35, 30, 30), MachinesButton, buttonStyle))
            {
                machinesClicked = !ClearButtons(machinesClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(250, 35, 30, 30), ResourceButton, buttonStyle))
            {
                resourcesClicked = !ClearButtons(resourcesClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(290, 35, 30, 30), BudgetButton, buttonStyle))
            {
                budgetClicked = !ClearButtons(budgetClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(330, 35, 30, 30), EconomyButton, buttonStyle))
            {
                economyClicked = !ClearButtons(economyClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(370, 35, 30, 30), EarthButton, buttonStyle))
            {
                earthClicked = !ClearButtons(earthClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(460, 35, 30, 30), SettingsButton, buttonStyle))
            {
                settingsClicked = !ClearButtons(settingsClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(500, 35, 30, 30), HelpButton, buttonStyle))
            {
                helpClicked = !ClearButtons(helpClicked);
                this.audio.Play();
            }

            if (GUI.Button(new Rect(540, 35, 30, 30), CloseButton, buttonStyle))
            {
                closeClicked = !ClearButtons(closeClicked);
                this.audio.Play();
            }
            //GUI.contentColor = Color.green;
            GUI.BeginGroup(new Rect(80, 80, Screen.width - 160, 40));
            GUILayout.BeginHorizontal();
            foreach (var resource in Colony.colonyResources)
            {
                GUILayout.Label(resource.Key + " : " + resource.Value);
            }

            //string loremIpsum = database.buildings[1][1];

            GUILayout.EndHorizontal();
            GUILayout.Label(test);
            GUI.EndGroup();

            GUIStyle removeBackground = new GUIStyle();
            removeBackground.normal.background = null;


            int startSubmenuLeft = 240;
            int startSubmenuTop = 30;
            int submenuItemHeight = 235;

            GUIStyle boxStyle = new GUIStyle();
            boxStyle.wordWrap = true;
            boxStyle.normal.textColor = Color.white;
            boxStyle.normal.background = BackgroundUnitInfo;
            boxStyle.padding = new RectOffset(10, 10, 10, 10);
            boxStyle.alignment = new TextAnchor();


            if (buildingClicked)
            {
                DrawSubMenuWrapper();

                GUI.Box(new Rect(137, 65, topBoxTextureBuilding.width - 250, topBoxTextureBuilding.height - 200), topBoxTextureBuilding, removeBackground);

                scrollViewVector = GUI.BeginScrollView(
                    new Rect(65, 130, Screen.width - 160, Screen.height - 210), scrollViewVector, new Rect(0, 0, 800, Database.buildings.Count * submenuItemHeight + 30));

                foreach (var building in Database.buildings)
                {
                    GUI.Box(new Rect(30, startSubmenuTop, 200, 200), buildingImagesDatabase[building.Key], boxStyle);

                    GUI.Box(new Rect(startSubmenuLeft + 30, startSubmenuTop - 30, 150, 30), building.Value[0], boxStyle);
                    GUI.Box(new Rect(startSubmenuLeft, startSubmenuTop, Screen.width - 240 - 200, 200), building.Value[1], boxStyle);

                    #region Hummer Button
                    if (GUI.Button(new Rect(Screen.width - 240 - 20, startSubmenuTop + 155, 30, 30), BuildButton_KD, buttonStyle))
                    {
                        this.audio.Play();
                        switch (building.Key)
                        {
                            case Buildings.CommandCenter:
                                break;
                            case Buildings.Refinery:
                                affordable = true;
                                foreach (var item in Refinery.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.Refinery));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            case Buildings.Mine:
                                affordable = true;
                                foreach (var item in Mine.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.Mine));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            case Buildings.Hangar:
                                affordable = true;
                                foreach (var item in Hangar.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.Hangar));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            case Buildings.UnitsFactory:
                                affordable = true;
                                foreach (var item in UnitsFactory.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.UnitsFactory));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            case Buildings.PowerPlant:
                                affordable = true;
                                foreach (var item in PowerPlant.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.PowerPlant));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            case Buildings.Silo:
                                affordable = true;
                                foreach (var item in Silo.cost)
                                {
                                    if (Colony.colonyResources[item.Key] < item.Value)
                                    {
                                        affordable = false;
                                        test = "Not enough " + item.Key;
                                    }
                                }
                                if (affordable)
                                {
                                    StartCoroutine(PlaceBuildmentOrder(Buildings.Silo));
                                    test = "Please chose a place for the new building!";
                                }
                                break;
                            default:
                                Debug.LogError("No such building " + building.Key);
                                break;
                        }
                        buildingClicked = false;
                        GetComponent<CameraControl>().EnableControls(true);
                    }
                    #endregion

                    startSubmenuTop += submenuItemHeight;
                }

                GUI.EndScrollView();

            }

            if (machinesClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(177, 65, topBoxTextureMachines.width - 250, topBoxTextureMachines.height - 200), topBoxTextureMachines, removeBackground);

                scrollViewVector = GUI.BeginScrollView(
                 new Rect(65, 130, Screen.width - 160, Screen.height - 210), scrollViewVector, new Rect(0, 0, 800, Database.devices.Count * submenuItemHeight + 30));

                foreach (var device in Database.devices)
                {
                    GUI.Box(new Rect(30, startSubmenuTop, 200, 200), unitsImagesDatabase[device.Key], boxStyle);
                    GUI.Box(new Rect(startSubmenuLeft + 30, startSubmenuTop - 30, 150, 30), device.Value[0], boxStyle);
                    GUI.Box(new Rect(startSubmenuLeft, startSubmenuTop, Screen.width - 240 - 200, 200), device.Value[1], boxStyle);
                    if (GUI.Button(new Rect(Screen.width - 240 - 20, startSubmenuTop + 155, 30, 30), BuildButton_KD, buttonStyle))
                    {
                        this.audio.Play();
                        UnitsFactory uf = GameObject.FindGameObjectWithTag("units-factory").GetComponent<UnitsFactory>();
                        uf.CreateUnit(device.Key);
                        //StartCoroutine(PlaceBuildmentOrder(device.Key));
                        buildingClicked = false;
                    }
                    startSubmenuTop += submenuItemHeight;
                }

                GUI.EndScrollView();

            }

            if (resourcesClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(217, 65, topBoxTextureResources.width - 250, topBoxTextureResources.height - 200), topBoxTextureResources, removeBackground);

                GUIStyle resourcesStyle = new GUIStyle();
                resourcesStyle.wordWrap = true;
                resourcesStyle.normal.textColor = Color.white;
                resourcesStyle.padding = new RectOffset(10, 10, 10, 10);
                resourcesStyle.alignment = new TextAnchor();
                resourcesStyle.border.bottom = 2;


                startSubmenuLeft = 160;
                startSubmenuTop = 30;
                submenuItemHeight = 150;

                scrollViewVector = GUI.BeginScrollView(
       new Rect(65, 130, Screen.width - 160, Screen.height - 210), scrollViewVector, new Rect(0, 0, Screen.width - 190, Database.resources.Count * submenuItemHeight + 30));

                string readMore = "Read more";
                foreach (var resource in Database.resources)
                {
                    GUI.Box(new Rect(30, startSubmenuTop, 125, 25), resource.Value[0]);
                    GUI.Box(new Rect(startSubmenuLeft, startSubmenuTop - 10, Screen.width - 335, 100), resource.Value[1], resourcesStyle);
                    GUI.Box(new Rect(30, startSubmenuTop + 115, Screen.width - 300 + startSubmenuLeft, 2), "", boxStyle);
                    if (GUI.Button(new Rect(Screen.width - 300, startSubmenuTop + 80, 85, 25), readMore))
                    {
                        this.audio.Play();
                        //Application.OpenURL(resource.Value[2]);
                        string url = "window.open('" + resource.Value[2] + "'),'_blank'";
                        Application.ExternalEval(url);
                    }
                    startSubmenuTop += submenuItemHeight;
                }

                GUI.EndScrollView();

            }

            if (budgetClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(257, 65, topBoxTextureBudget.width - 250, topBoxTextureBudget.height - 200), topBoxTextureBudget, removeBackground);
                GUI.Box(new Rect(95, 120, Screen.width - 210, Screen.height - 190), BudgetBG_KD);

                GUI.Box(new Rect(125, 140, 140, 30), "Anual budget: ");
                GUI.Box(new Rect(280, 140, 100, 30), "$" + GlobalVariables.AnualBudget.ToString() + "m");

                GUI.Box(new Rect(125, 180, 140, 30), "Cost per kilogram: ");
                GUI.Box(new Rect(280, 180, 100, 30), "$" + GlobalVariables.PricePerKilogram.ToString());

                GUI.Box(new Rect(125, 220, 140, 30), "Spacecraft capacity: ");
                GUI.Box(new Rect(280, 220, 100, 30), GlobalVariables.FlightCapacity.ToString() + "kg");


                GUI.Box(new Rect(450, 140, Screen.width - 450 - 170, 300), "");
            }

            if (economyClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(297, 65, topBoxTextureEconomy.width - 250, topBoxTextureEconomy.height - 200), topBoxTextureEconomy, removeBackground);
            }

            if (earthClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(337, 65, topBoxTextureEarth.width - 250, topBoxTextureEarth.height - 200), topBoxTextureEarth, removeBackground);
                int lineHeight = 140;
                foreach (var resource in Database.resources)
                {
                    GUI.Box(new Rect(125, lineHeight, 200, 30), resource.Value[0]);
                    if (GUI.Button(new Rect(340, lineHeight, 25, 25), BudgetButton, buttonStyle))
                    {

                        this.audio.Play();
                    }

                    lineHeight += 40;
                }

                lineHeight = 140;

                foreach (var device in Database.devices)
                {
                    GUI.Box(new Rect(485, lineHeight, 200, 30), device.Value[0]);
                    if (GUI.Button(new Rect(700, lineHeight, 25, 25), BudgetButton, buttonStyle))
                    {

                        this.audio.Play();
                    }

                    lineHeight += 40;
                }
            }

            if (settingsClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(427, 65, topBoxTextureSettings.width - 250, topBoxTextureSettings.height - 200), topBoxTextureSettings, removeBackground);
            }

            if (helpClicked)
            {
                DrawSubMenuWrapper();
                GUI.Box(new Rect(467, 65, topBoxTextureHelp.width - 250, topBoxTextureHelp.height - 200), topBoxTextureHelp, removeBackground);
            }

            if (closeClicked)
            {
                DrawSubMenuWrapper();
                if (GUILayout.Button("Abort mission") || Input.GetKeyUp(KeyCode.Escape))
                {
                    Application.LoadLevel(0);
                }
            }
        }
    }

    bool ClearButtons(bool checkedButton)
    {
        if (checkedButton == false)
        {
            GetComponent<CameraControl>().EnableControls(false);
        }
        else
        {
            GetComponent<CameraControl>().EnableControls(true);
        }
        buildingClicked = false;
        machinesClicked = false;
        closeClicked = false;
        helpClicked = false;
        settingsClicked = false;
        earthClicked = false;
        economyClicked = false;
        budgetClicked = false;
        resourcesClicked = false;

        return checkedButton;
    }

    IEnumerator PlaceBuildmentOrder(Buildings type)
    {
        yield return new WaitForEndOfFrame();
        click.PlaceOrderForBuildment(type);
    }

    void DrawSubMenuWrapper()
    {
        GUI.Box(new Rect(75, 100, Screen.width - 150, Screen.height - 150), string.Empty);
    }
}
