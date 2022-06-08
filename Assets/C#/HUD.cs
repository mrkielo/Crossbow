using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] float smooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            Hide();
        }
    }

    public void Hide() {
        Vector3 target = new Vector3(transform.position.x-40,transform.position.y,0);
    
    }
}
