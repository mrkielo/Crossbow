using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{   
    [SerializeField] float maxHp;
    [HideInInspector] public float hp;
    [SerializeField] BarUI hpBar;
    [SerializeField] BarUI adBar;
    [SerializeField] float delay;
    [SerializeField] float adDrain;
    [SerializeField] float maxAd;
    [SerializeField] float specialDuration;
    Bow bow;

    float timer;
    float specialTimer;
    float ad = 0;
    bool specialON = false;


    void Start()
    {
        timer = specialTimer = Time.time;
        bow = FindObjectOfType<Bow>();
        hp = maxHp;
    }

    public void TakeDamage(float damage) {
        hp-=damage;
        hpBar.Set(hp/maxHp);
        ad = 0;
    }

    public void Kill(float adGain) {
        ad+=adGain;
        adBar.Set(ad/maxAd);
    }

     void Update() {
         AdDrain();
         Special();

        
    }

    void AdDrain() {
        if(timer+delay<Time.time) {
            ad-=adDrain;
            if(ad<0) ad=0;
            timer = Time.time;
            adBar.Set(ad/maxAd);
        }
    }

    void Special() {
        if(ad>=maxAd && specialON==false) {
            specialON = true;
            bow.firerate*=2;
            specialTimer = Time.time;
            ad = 0; 

            if(specialTimer + specialDuration<Time.time && specialON) {
            specialON = false;
            bow.firerate/=2;                                     
            }
        }
    }
}
