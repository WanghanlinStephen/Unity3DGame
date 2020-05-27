using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    private int page = 0;
    public Button front;
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.transform.Find("background").gameObject.SetActive(!this.transform.Find("background").gameObject.activeSelf);
            if (this.transform.Find("background").gameObject.activeSelf)
            {
                FindObjectOfType<Parent>().addItem(page);
            }
            else
            {
                page = 0;
            }
            
        }
    }


    public void OnFront()
    {
        if (page > 0)
        {
            page--;
            FindObjectOfType<Parent>().addItem(page);
        }
    }

    public void OnBack()
    {
        if (page < PlayerController.instance.backPack.Count / 20)
        {
            page++;
            FindObjectOfType<Parent>().addItem(page);
        }
    }
}
