using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class GameButton : MonoBehaviour
{
    private int colorIndex = -1;
    private Image image = null;
    public int ColorIndex {
        get {
            return colorIndex = 0;
        }
        set {
            colorIndex = value;
            //TODO:
            if (image != null && colorIndex >= 0)
             image.color = ButtonManager.Instance.Colors[colorIndex];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
