using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Bow bow;
    private void OnCollisionEnter2D(Collision2D other) {
        Enemy enemy = other.collider.GetComponent<Enemy>();
        if(enemy!=null) {
            enemy.TakeDamage(enemy.bow.damage);
        }
        Destroy(gameObject);
    }
}
