using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxManager : MonoBehaviour

//speaks for itself

// {
//     public static SfxManager Instance;

//     public AudioClip[] clips;

//     public AudioSource audioSource;

//     void Awake()
//     {
//         Instance = this;
//     }

//     public void Play(int clip)
//     {
//         audioSource.clip = clips[clip];
//         audioSource.Play();
//     }
// }

{

    [SerializeField] GameObject scoreChangePrefab;
    [SerializeField] Color addPointsColor;

    [SerializeField] Color subtractPointsColor;
    [SerializeField] Color zeroPointsInvisible;
    [SerializeField] GameObject endPoint;
    int change;
    GameObject pointParent;
    [SerializeField] GameObject buttonObject;

    //audio for 6 colors possibly sacura themed (melodic pentatonic)
    //musical progression for each of the colors
    //audio for breaking pattern

    void Start () 
    {
        Button button = buttonObject.GetComponent<Button>();
        button.onClick.AddListener(() => ShowScoreChange());
    }

    public void ShowScoreChange ()
    //int change, GameObject pointParent
    {
        change = GameManager.Instance.addedPoints;
        pointParent = buttonObject;
        // Transform pointParentTransform = transform.LookAt(pointParent.transform);
        var inst = Instantiate(scoreChangePrefab, pointParent.transform.position, Quaternion.identity);
        inst.transform.SetParent(pointParent.transform, true);

        RectTransform rect = inst.GetComponent<RectTransform>();
        RectTransform endPointT = endPoint.GetComponent<RectTransform>();
        Text text = inst.GetComponent<Text>();
        text.text = (change > 0 ? "+ " : " ") + change.ToString();
        text.color = change > 0 ? addPointsColor : change < 0 ? subtractPointsColor : zeroPointsInvisible;

        LeanTween.move(rect, endPointT.anchoredPosition, 0.9f).setOnComplete(() => {Destroy(inst);});
        LeanTween.alphaText(rect, 0.25f, 1.25f);
    }

    public void ButtonNotes()
    {
        //get the color component of the button
    }

}
