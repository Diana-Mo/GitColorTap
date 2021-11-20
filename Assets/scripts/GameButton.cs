using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class GameButton : MonoBehaviour

// gets game button info and assigns them colors

{
    [SerializeField]
    private int colorIndex = -1;    
    private Image image = null;

    public int ColorIndex {
        get {
            return colorIndex;
        }
        set {
            colorIndex = value;
            UpdateImageColor();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        UpdateImageColor();
    }

    // Update is called once per frame
    void UpdateImageColor()
    {
        if (image != null && colorIndex >= 0)
             image.color = GameManager.Instance.Colors[colorIndex];
    }
}
