using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthFix : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] bool height;
    void Start()
    {
        
        float y;
        float screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0)).x;
        if(height)  y = screenBounds/transform.lossyScale.x * transform.lossyScale.y;
        else    y = transform.lossyScale.y;
        transform.localScale = new Vector2(screenBounds/transform.lossyScale.x * transform.localScale.x * 2,y/transform.lossyScale.y * transform.localScale.y); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
