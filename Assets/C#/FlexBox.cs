using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexBox : MonoBehaviour
{
   [SerializeField] Transform[] items;

   void Start() {
      Refersh();  
   }
   void Refersh() {
		Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
		float halfSpot = bounds.x / items.Length * 2;

		for(int i=0; i<items.Length;i++) {
			items[i].localScale = new Vector2(items[i].localScale.x * 2 * halfSpot / items[i].lossyScale.x,items[i].localScale.y);
			float x = (2*i+1) * halfSpot;
			items[i].position = new Vector2(x,items[i].position.y);
		}
   }
}
