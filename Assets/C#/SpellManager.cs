using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{   
   [SerializeField] Spell topSpell;
   [SerializeField] Spell downSpell;
   Image topFade;
   Image downFade;

    void Start() {
        topFade = topSpell.GetComponentInChildren<Image>();
        downFade = downSpell.GetComponentInChildren<Image>();
    }

    
    public void OnTopButtonClick() {
        topSpell.Click();
    }

    public void OnDownButtonClick() {
        downSpell.Click();
    }
   





}
