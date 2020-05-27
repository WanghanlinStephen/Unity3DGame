using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowMap : MonoBehaviour
{
    public GameObject Map;
    public bool showmap = false;
    void Start()
    {
        Map.SetActive(false);
    }
    void Update()
    {
        show();
           
    }
    public void show()
    {
        if(showmap == false)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Map.SetActive(true);
                showmap = true;
            }
        }
        else if (showmap == true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Map.SetActive(false);
                showmap = false;

            }
        }

    }
  
}
