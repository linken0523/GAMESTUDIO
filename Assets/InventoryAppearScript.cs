using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAppearScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InventoryScreen;
    private bool isShowing = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            isShowing=!isShowing;
            InventoryScreen.SetActive(isShowing);
        }
    }
}
