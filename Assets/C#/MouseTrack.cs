using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrack : MonoBehaviour
{
    Vector2 mousePos;
    [SerializeField] bool x = true;
    [SerializeField] bool y = true;
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(x && y) {
            transform.position = mousePos;
        }
        else if(x && !y) {
            transform.position = new Vector2(mousePos.x,transform.position.y);
        }

        else if(!x && y) {
            transform.position = new Vector2(transform.position.x, mousePos.y);
        }
    }
}
