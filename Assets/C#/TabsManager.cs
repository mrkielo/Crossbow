using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsManager : MonoBehaviour
{
    [SerializeField] GameObject[] tabs;
    [SerializeField] ColorToggler[] buttons;
    [SerializeField] Color offColor;
    [SerializeField] Color onColor;

    public void ShowMenu() {
        gameObject.SetActive(true);
        ShowTab(0);
    }

    public void HideMenu() {
        gameObject.SetActive(false); 
    }
    
    public void ShowTab(int index) {
        for(int i=0; i<tabs.Length;i++) {
            tabs[i].SetActive(false);
            buttons[i].Toggle(offColor);
        }
        tabs[index].SetActive(true);
        buttons[index].Toggle(onColor);
    }
}
