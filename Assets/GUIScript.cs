using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    public GUIStyle fontSize;
    public bool showWindows = false;
    public string task;
    public string killed;

    // Start is called before the first frame update
    void Start()
    {
        fontSize = new GUIStyle();
        fontSize.fontSize = 60;
        showWindows = true;

    }

    // Update is called once per frame
    void Update()
    {
        task = NPC.task;
        killed = NPC.killed;
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (showWindows)
                showWindows = false;
            else
                showWindows = true;
        }
    }

    void OnGUI()
    {
        if (showWindows) GUI.Box(new Rect(0, 900, 100, 100), task+killed, fontSize);
    }
}
