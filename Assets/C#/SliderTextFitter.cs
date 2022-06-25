using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextFitter : MonoBehaviour
{
    Slider slider;
    bool textSide; /// false - left // true - right
    void Start() {
        slider = GetComponent<Slider>();
        textSide = false;
    }
    void Update()
    {
        if(slider.value < 0.5 && textSide == false) SetRight();
        if(slider.value >= 0.5 && textSide == true) SetLeft();
    }

    void SetRight() {
        textSide = true;
        Vector2 pos = slider.handleRect.position;
        Debug.Log(pos);
        pos.x = 1.2f;
        slider.handleRect.position = pos;
        slider.handleRect.GetComponent<Text>().color =Color.white;
        slider.handleRect.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
    }

    void SetLeft() {
        textSide = false;
        Vector2 pos = slider.handleRect.position;
        pos.x = -1.2f;
        slider.handleRect.position = pos;
        slider.handleRect.GetComponent<Text>().color =Color.black;
        slider.handleRect.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
    }
}
