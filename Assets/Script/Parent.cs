using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parent : MonoBehaviour
{
    public Transform itemsParent;
    Test[] slots;
    
    // Start is called before the first frame update


    public void addItem(int page)
    {
        slots = itemsParent.GetComponentsInChildren<Test>();
        for (int i= 0;i < 20; i++)
        {
            slots[i].Clear();
        }
        for (int i = page*20; i < PlayerController.instance.backPack.Count; i++)
        {
            if (i >= 20*(page+1))
            {
                return;
            }
            slots[i-20*page].AddItem(PlayerController.instance.backPack[i]);
        }
        
    }


    
}
