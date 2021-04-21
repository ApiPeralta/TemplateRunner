//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Slider : MonoBehaviour
//{
//    public Slider mainSlider;
//    public float SliderBarD;

//    void Start()
//    {
//        mainSlider = GetComponent<Slider>();
//        SliderBarD = 1;
//    }
//    void Update()
//    {
//        if(Controller_Hud.gameOver == false)
//        {
//            SliderBarD += Time.deltaTime;
//            mainSlider.value = SliderBarD;
//        }
//        if(mainSlider.value == 10)
//        {
//            Controller_Hud.gameOver = true;
//        }
//    }
//}
