using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    [SerializeField] float smooth;
    Image img;
    Text text;
    float target;

    void Start()
    {
        img = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        target = img.fillAmount;
    }

    void Update()
    {
        if(target!=img.fillAmount) {
            img.fillAmount = Mathf.Lerp(img.fillAmount,target,smooth);
        }
    }

    public void Set(float fraction) {
        target = fraction;
        if(text) {
            text.text = (fraction*100).ToString();
        }
    }
}
