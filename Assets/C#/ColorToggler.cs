using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToggler: MonoBehaviour
{
    Image sprite;
    void Start() {
        sprite = GetComponent<Image>();
        sprite.color = Color.white;
    }
    public void Toggle( Color color) {
        sprite.color = color;
    }
}
