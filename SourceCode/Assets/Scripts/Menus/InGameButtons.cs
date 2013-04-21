using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class InGameButtons : MonoBehaviour
{
    public bool isColonyButton = false;
    public bool isBuildingButton = false;
    public bool isMachinesButton = false;
    public bool isResourcesButton = false;
    public bool isBudgetButton = false;
    public bool isEconomyButton = false;
    public bool isEarthButton = false;

    public bool isSettingsButton = false;
    public bool isHelpButton = false;
    public bool isCloseButton = false;

    public Texture2D buildTexture;
    public Texture2D topBoxTexture;

    public Texture2D CommandCenterTexture;
    public Texture2D RafineryTexture;
    public Texture2D HangarTexture;
    public Texture2D SiloTexture;
    public Texture2D MineTexture;
    public Texture2D UnitsFactoryTexture;
    public Texture2D PowerPlantTexture;

    public Texture2D BackgroundUnitInfo;// = new Texture2D(580,200);

    private Vector2 scrollViewVector = Vector2.zero;

    public int boxStartLeftCoordinate = 0;

    public MenuCommands command;

    public bool showColonySubMenu = false;
    public bool showBuildingSubMenu = false;
    public bool showMachinesSubMenu = false;
    public bool showResourcesSubMenu = false;
    public bool showBudgetSubMenu = false;
    public bool showEconomySubMenu = false;
    public bool showEarthSubMenu = false;

    public bool showSettingsSubMenu = false;
    public bool showHelpSubMenu = false;
    public bool showCloseSubMenu = false;

    void OnGUI()
    {
        //-----------------GET PLAYER COMMAND AND THE POSITION OF THE BUTTON CLICKED-----------//
       
        if (isColonyButton)
        {
            boxStartLeftCoordinate = 130;
            command = MenuCommands.Colony;
        }
        else if (isBuildingButton)
        {
            boxStartLeftCoordinate = 170;
            command = MenuCommands.Building;
        }
        else if (isMachinesButton)
        {
            boxStartLeftCoordinate = 210;
            command = MenuCommands.Machines;
        }
        else if (isResourcesButton)
        {
            boxStartLeftCoordinate = 250;
            command = MenuCommands.Resources;
        }
        else if (isBudgetButton)
        {
            boxStartLeftCoordinate = 290;
            command = MenuCommands.Budget;
        }
        else if (isEconomyButton)
        {
            boxStartLeftCoordinate = 330;
            command = MenuCommands.Economy;
        }
        else if (isEarthButton)
        {
            boxStartLeftCoordinate = 370;
            command = MenuCommands.Earth;
        }
        else if (isSettingsButton)
        {
            boxStartLeftCoordinate = 460;
            command = MenuCommands.Settings;
        }
        else if (isHelpButton)
        {
            boxStartLeftCoordinate = 500;
            command = MenuCommands.Help;
        }
        else if (isCloseButton)
        {
            boxStartLeftCoordinate = 540;
            command = MenuCommands.Close;
        }

        //-------------------SET TOP BUTTONS IN IN-GAME MENU FRAME AND MARK/UNMARK THE BUTTON------------------//

        GUIStyle buttonStyle = new GUIStyle();
        buttonStyle.normal.background = null;
        if (GUI.Button(new Rect(boxStartLeftCoordinate, 25, 30, 30), buildTexture,buttonStyle))
        {
            this.audio.Play();
            if (command == MenuCommands.Colony)
            {
                if (showColonySubMenu)
                {
                    showColonySubMenu = false;
                }
                else
                {
                    showColonySubMenu = true;
                }
            }

            if (command == MenuCommands.Building)
            {
                if (showBuildingSubMenu)
                {
                    showBuildingSubMenu = false;
                }
                else
                {
                    showBuildingSubMenu = true;
                }
            }

            if (command == MenuCommands.Machines)
            {
                if (showMachinesSubMenu)
                {
                    showMachinesSubMenu = false;
                }
                else
                {
                    showMachinesSubMenu = true;
                }
            }

            if (command == MenuCommands.Resources)
            {
                if (showResourcesSubMenu)
                {
                    showResourcesSubMenu = false;
                }
                else
                {
                    showResourcesSubMenu = true;
                }
            }

            if (command == MenuCommands.Budget)
            {
                if (showBudgetSubMenu)
                {
                    showBudgetSubMenu = false;
                }
                else
                {
                    showBudgetSubMenu = true;
                }
            }

            if (command == MenuCommands.Economy)
            {
                if (showEconomySubMenu)
                {
                    showEconomySubMenu = false;
                }
                else
                {
                    showEconomySubMenu = true;
                }
            }

            if (command == MenuCommands.Earth)
            {
                if (showEarthSubMenu)
                {
                    showEarthSubMenu = false;
                }
                else
                {
                    showEarthSubMenu = true;
                }
            }

            if (command == MenuCommands.Settings)
            {
                if (showSettingsSubMenu)
                {
                    showSettingsSubMenu = false;
                }
                else
                {
                    showSettingsSubMenu = true;
                }
            }

            if (command == MenuCommands.Help)
            {
                if (showHelpSubMenu)
                {
                    showHelpSubMenu = false;
                }
                else
                {
                    showHelpSubMenu = true;
                }
            }

            if (command == MenuCommands.Close)
            {
                if (showCloseSubMenu)
                {
                    showCloseSubMenu = false;
                }
                else
                {
                    showCloseSubMenu = true;
                }
            }
        }

        //--------------------GET THE BOX BELOW CLICKED BUTTON--------------------//

        GUIStyle removeBackground = new GUIStyle();
        removeBackground.normal.background = null;

        string loremIpsum = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at,laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante,elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt lectus quis dui viverra vestibulum. Suspendisse vulputate aliquam dui. Nullaelementum dui ut augue. Aliquam vehicula mi at mauris. Maecenas placerat,nisl at consequat rhoncus, sem nunc gravida justo, quis eleifend arcu velitquis lacus. Morbi magna magna, tincidunt a, mattis non, imperdiet vitae, tellus.Sed odio est, auctor ac, sollicitudin in, consequat vitae, orci. Fusce idfelis. Vivamus sollicitudin metus eget eros.";

        if (showColonySubMenu) // TODO when open one submenu close others && !showBuildingSubMenu && !showMachinesSubMenu  && !showResourcesSubMenu && !showBudgetSubMenu && !showEconomySubMenu && !showEarthSubMenu && !showSettingsSubMenu && !showHelpSubMenu && !showCloseSubMenu) //does not work...else if doesn not work too wtf!?
        {
            //showBuildingSubMenu = false;
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(97, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);

            scrollViewVector = GUI.BeginScrollView(new Rect(65, 130, 840, 555), scrollViewVector, new Rect(0, 0, 800, 1500));

            GUI.Box(new Rect(30, 0, 200, 200), CommandCenterTexture, removeBackground);
            GUI.Box(new Rect(30, 210, 200, 200), RafineryTexture, removeBackground);
            GUI.Box(new Rect(30, 420, 200, 200), HangarTexture, removeBackground);
            GUI.Box(new Rect(30, 630, 200, 200), SiloTexture, removeBackground);
            GUI.Box(new Rect(30, 840, 200, 200), MineTexture, removeBackground);
            GUI.Box(new Rect(30, 1050, 200, 200), UnitsFactoryTexture, removeBackground);
            GUI.Box(new Rect(30, 1260, 200, 200), PowerPlantTexture, removeBackground);

            GUIStyle boxStyle = new GUIStyle();
            boxStyle.wordWrap = true;
            boxStyle.normal.textColor = Color.white;
            boxStyle.normal.background = BackgroundUnitInfo;
            boxStyle.padding = new RectOffset(10, 10, 10, 10);
            boxStyle.alignment = new TextAnchor();

            GUI.Box(new Rect(240, 0, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 210, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 420, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 630, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 840, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 1050, 580, 200), loremIpsum, boxStyle);
            GUI.Box(new Rect(240, 1260, 580, 200), loremIpsum, boxStyle);
            
            GUI.EndScrollView();

        }
        else if (showBuildingSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(137, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showMachinesSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(177, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showResourcesSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(217, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showBudgetSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(257, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showEconomySubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(297, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showEarthSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(337, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showSettingsSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(427, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showHelpSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(467, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
        else if (showCloseSubMenu)
        {
            GUI.Box(new Rect(65, 100, 845, 585), string.Empty);
            GUI.Box(new Rect(507, 65, topBoxTexture.width - 250, topBoxTexture.height - 200), topBoxTexture, removeBackground);
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
