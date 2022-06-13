using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayerFix : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("elo");
        if(other.gameObject.layer == gameObject.layer && transform.position.y <= other.transform.position.y) {
            Debug.Log("This: " + GetComponent<SpriteRenderer>().sortingOrder);  
            Debug.Log("Other: " + other.gameObject.GetComponent<SpriteRenderer>().sortingOrder);
            GetComponent<SpriteRenderer>().sortingOrder = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
    }
}