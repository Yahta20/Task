using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControll : MonoBehaviour
{
    private List<ClickColorData> cCData;
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;


    void Awake() {
        scrollView.verticalNormalizedPosition = 1;
        cCData = new List<ClickColorData>();
    }
    void Update()
    {
        
    }

     
    public void addObject(ClickColorData ccd) {

        cCData.Add(ccd);
        GameObject itemToScroll = Instantiate(scrollItemPrefab);
        itemToScroll.transform.SetParent(scrollContent.transform, false);
        itemToScroll.transform.Find("number").gameObject.GetComponent<Text>().text =  cCData.Count.ToString();
        itemToScroll.transform.Find("seconds").gameObject.GetComponent<Text>().text = (ccd.time2Change/1000).ToString();
    }
}
