using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image icon;
    public Button B;
    // Start is called before the first frame update
    public void AddItem(string name)
    {
        B.name = name;
        B.enabled = true;
        icon.sprite = Resources.Load(name, typeof(Sprite)) as Sprite;
        icon.enabled = true;
    }

    public void Clear()
    {
        B.enabled = false;
        icon.enabled = false;
    }

    public void OnB ()
    {
        PlayerController.instance.Change(B.name);      
    }

}
