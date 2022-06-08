using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bow : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public float damage;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] public float firerate;
    [SerializeField] float arrowSpeed;

    float lastShoot;
    Vector3 screenBounds;
    float width;

    
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
     width = screenBounds.x - transform.lossyScale.x/2;
     lastShoot = Time.time;
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)) {
            float delay = 60/firerate;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.position = new Vector2(Mathf.Clamp(mousePos.x,-width,width),rb.position.y);
            if(lastShoot + delay<Time.time) {       
                Shoot();
                lastShoot = Time.time;
            }  
        }  
    }
     void Shoot() {
        GameObject arrow = Instantiate(arrowPrefab,transform.position,transform.rotation);
        arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.up * arrowSpeed);  
    }
}
