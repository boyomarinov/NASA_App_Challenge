using UnityEngine;
using System.Collections;

public class Frame : MonoBehaviour 
{
    public Texture FrameTexture;

    void OnGUI()
    {
        GUILayout.Box(FrameTexture);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
