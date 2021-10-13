using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Join : MonoBehaviour
{
    public GameObject connecterManetteJ1;
    public GameObject connecterManetteJ2;
    public int player;
    private bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        player = 0;
    }
    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            player++;
            if (player == 1)
            {
                connecterManetteJ1.SetActive(false);

            }
            if (player == 2)
            {
                connecterManetteJ2.SetActive(false);
            }
        }
        
    }
}
