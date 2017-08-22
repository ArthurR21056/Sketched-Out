using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImaginationBar : MonoBehaviour{

    public static float MaxImagin;
    public static float Imagin;
    public Slider ImaginBar;
    public float damage;
    public Text ImaginText;
    public float regenImagin;

    // Use this for initialization
    void Start()
    {
        MaxImagin = 100;
        Imagin = MaxImagin;
        ImaginText.text = "IMAG:  " + Imagin;
        regenImagin = 1;
        InvokeRepeating("RegenImagination", 0f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        ImaginBar.value = Imagin;
        ImaginText.text = "IMAG:  " + Imagin;
    }
   
    public static void AddDamage(int damage)
    {
        Imagin -= damage;
        
    }
    public void RegenImagination()
    {
        if (Imagin != 100)
            Imagin += regenImagin;

    }
}

