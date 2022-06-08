using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] bool hideonFull;
    float scaleTarget;
    float startScale;
     SpriteRenderer sprite;
    
     void Start() {
        sprite = GetComponent<SpriteRenderer>();
        startScale = scaleTarget = transform.localScale.x;
    }
    public void Set(float fraction) {
        scaleTarget = fraction;
    }
    void Update()
    {
        if(hideonFull && scaleTarget==startScale) sprite.enabled = false;
        else sprite.enabled = true;
        transform.localScale = new Vector2(scaleTarget * startScale,transform.localScale.y);
    }
}
