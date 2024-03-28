using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class health : MonoBehaviour
{
    [SerializeField]private int maxHealth = 100;
    private float playerHealth;
    public float amount;
    public Vignette damageScreen;

    void Start()
    {
        playerHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown("space")){damage(20);
        Debug.Log("Took Damage!");}
        
    }

    public void damage(float amount)
    {
        playerHealth -= amount;
    }
}
