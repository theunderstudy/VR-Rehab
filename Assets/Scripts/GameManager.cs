using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float AugmentMax=5;
    public float AugmentMin=0;
    public float AugmentAmount = 2;
    public Slider AugmentSlider;
    public Text SliderText;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start () {
        if (instance != null)
        {
            //destroy the entire game object
            //since we don't want to double up on ui
            Destroy(gameObject);
            return;
        }
        //set up our singleton instance
        instance = this;

        AugmentSlider.maxValue = AugmentMax;
        AugmentSlider.minValue = AugmentMin;
        if (PlayerPrefs.HasKey("AugmentSlider"))
        {
            AugmentSlider.value = PlayerPrefs.GetInt("AugmentSlider");
        }
        else
        {
            AugmentSlider.value = AugmentAmount;
        }
    }
	public void Slide()
    {
        AugmentAmount = AugmentSlider.value;
        PlayerPrefs.SetFloat("AugmentSlider",AugmentAmount);
        SliderText.text = AugmentSlider.value.ToString("F2");
    }
	// Update is called once per frame
	void Update () {
       
	}
}
