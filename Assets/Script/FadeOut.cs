using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Image img;
    private bool Out = false;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Out = true;
            
        }
        if (Out)
        {
            Fadeout();
        }

    }
    void Fadeout()
    {

        img.color = Color.Lerp(img.color, Color.clear, 1.5f * Time.deltaTime);
        if (img.color.a < 0.05f)
        {
            this.gameObject.SetActive(false);
        }

    }
}
