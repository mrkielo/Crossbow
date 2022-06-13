using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    Image fadeImage;
    [SerializeField] float cooldown;
    float timer;

    public void SetTimer() {
        timer = Time.time;
    }

    void Start() {
        SetTimer();
        Image[] images = GetComponentsInChildren<Image>();
        fadeImage = images[1];
    }

    public void Click() {
        if(timer+cooldown<Time.time){
            GetComponent<ISpell>().Setup();
        }

    }

     void Update() {
        fadeImage.fillAmount = 1- (Time.time - timer )/ cooldown;
    }

}
