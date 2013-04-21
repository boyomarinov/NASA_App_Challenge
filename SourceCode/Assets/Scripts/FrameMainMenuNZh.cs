using UnityEngine;
using System.Collections;

public class FrameMainMenuNZh : MonoBehaviour {

    public Texture2D FrameLeft_KD;
    public Texture2D FrameRight_KD;
    public Texture2D FrameTopLeft_KD;
    public Texture2D FrameTopRight_KD;
    public Texture2D FrameTopMiddle_KD;
    public Texture2D FrameBottomMiddle_KD;
    public Texture2D FrameBottomLeft_KD;
    public Texture2D FrameBottomRight_KD;

    public Texture2D FrameMoon_KD;

    public Texture2D ButtonsBG_KD;

    public Texture2D Logo_KD;

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
        //GUI.Box(new Rect(Screen.width - 33, Screen.height - 232, 30, 200), EnergyBar_KD, designStyle);
        //GUI.DrawTexture(new Rect(Screen.width - 33, Screen.height - 232, 25, 200 - PowerLevel * 200 / 100), EnergyBarBW_KD, ScaleMode.ScaleAndCrop);
        //GUI.Box(new Rect(Screen.width - 33, Screen.height - 232, 30, 200 * .5f), EnergyBarBW_KD, designStyle);

    }
}
