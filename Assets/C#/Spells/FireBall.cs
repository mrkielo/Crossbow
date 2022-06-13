using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour, ISpell
{
    [SerializeField] float damage;
    [SerializeField] float radius;
    [SerializeField] GameObject  circlePrefab;
    [SerializeField] LayerMask enemyLayers;
    
    GameObject circle;
    bool setup = false;
    public void Setup() {
        circle = Instantiate(circlePrefab,transform.position,transform.rotation);
        setup = true;
    }
    public void Cast() {
        GetComponent<Spell>().SetTimer();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(circle.transform.position,circle.transform.localScale.x/2,enemyLayers);
        Enemy[] enemies =new Enemy[colliders.Length];
        if(colliders!=null) {
            for (int i=0; i<colliders.Length;i++) {
                enemies[i] = colliders[i].gameObject.GetComponent<Enemy>();
                if(enemies[i] !=null) enemies[i].TakeDamage(damage);
            }

            setup = false;
            Destroy(circle);
        }
    }

     void Update() {
       if(Input.GetKeyUp(KeyCode.Mouse0) && setup) {
           Cast();
       }
    }
    
}
