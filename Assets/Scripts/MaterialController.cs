using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public static MaterialController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MaterialController>();
            }
            return m_instance;
        }
    }

    private static MaterialController m_instance;



    public GameObject water;
    public GameObject coffee;
    public GameObject ice;
    public GameObject milk;
    //public GameObject syrup;
    //public GameObject h_syrup;
    //public GameObject v_syrup;
    //public GameObject chocolate;
    //public GameObject icecream;
    //public GameObject banana;
    //public GameObject apple;
    //public GameObject honey;
    //public GameObject soda;
    //public GameObject lemon;
    //public GameObject cherry;
    //public GameObject strawberry;
    //public GameObject pineapple;
    //public GameObject orange;
    //public GameObject grape;

    public void MaterialSetUp()
    {
        switch(DayContorller.instance.CurrentDay)
        {   
            //1일차 = 커피 얼음 물
            case 1:
                water.SetActive(true);
                coffee.SetActive(true);
                ice.SetActive(true);
                milk.SetActive(false);
                //syrup.SetActive(false);
                //h_syrup.SetActive(false);
                //v_syrup.SetActive(false);
                //chocolate.SetActive(false);
                //icecream.SetActive(false);
                //banana.SetActive(false);
                //apple.SetActive(false);
                //honey.SetActive(false);
                //lemon.SetActive(false);
                //orange.SetActive(false);
                //cherry.SetActive(false);
                //strawberry.SetActive(false);
                //grape.SetActive(false);
                //pineapple.SetActive(false);
                //soda.SetActive(false);
                break;
            //2 = 우유
            case 2:
                water.SetActive(true);
                coffee.SetActive(true);
                ice.SetActive(true);
                milk.SetActive(true);
                //syrup.SetActive(false);
                //h_syrup.SetActive(false);
                //v_syrup.SetActive(false);
                //chocolate.SetActive(false);
                //icecream.SetActive(false);
                //banana.SetActive(false);
                //apple.SetActive(false);
                //honey.SetActive(false);
                //lemon.SetActive(false);
                //orange.SetActive(false);
                //cherry.SetActive(false);
                //strawberry.SetActive(false);
                //grape.SetActive(false);
                //pineapple.SetActive(false);
                //soda.SetActive(false);
                break;
            //3 = 시럽
            //case 3:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(false);
            //    v_syrup.SetActive(false);
            //    chocolate.SetActive(false);
            //    icecream.SetActive(false);
            //    banana.SetActive(false);
            //    apple.SetActive(false);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////4 = h시럽,v시럼
            //case 4:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(false);
            //    icecream.SetActive(false);
            //    banana.SetActive(false);
            //    apple.SetActive(false);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////6 = 초코
            //case 6:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(false);
            //    banana.SetActive(false);
            //    apple.SetActive(false);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////8 = 아이스크림
            //case 8:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(false);
            //    apple.SetActive(false);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////11 = 바나나
            //case 11:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(false);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////14 = 사과
            //case 14:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(false);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////17 = 꿀
            //case 17:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(false);
            //    break;
            ////21 = 사이다
            //case 21:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(false);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(true);
            //    break;
            //// 24 = 레몬
            //case 24:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(false);
            //    cherry.SetActive(false);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(true);
            //    break;
            ////26 = 체리
            //case 26:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(false);
            //    cherry.SetActive(true);
            //    strawberry.SetActive(false);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(true);
            //    break;
            ////31 = 딸기
            //case 31:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(false);
            //    cherry.SetActive(true);
            //    strawberry.SetActive(true);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(true);
            //    break;
            ////36 = 오렌지
            //case 36:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(true);
            //    cherry.SetActive(true);
            //    strawberry.SetActive(true);
            //    grape.SetActive(false);
            //    pineapple.SetActive(false);
            //    soda.SetActive(true);
            //    break;
            ////41 = 파인애플
            //case 41:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(true);
            //    cherry.SetActive(true);
            //    strawberry.SetActive(true);
            //    grape.SetActive(false);
            //    pineapple.SetActive(true);
            //    soda.SetActive(true);
            //    break;
            ////46 = 포도
            //case 46:
            //    water.SetActive(true);
            //    coffee.SetActive(true);
            //    ice.SetActive(true);
            //    milk.SetActive(true);
            //    syrup.SetActive(true);
            //    h_syrup.SetActive(true);
            //    v_syrup.SetActive(true);
            //    chocolate.SetActive(true);
            //    icecream.SetActive(true);
            //    banana.SetActive(true);
            //    apple.SetActive(true);
            //    honey.SetActive(true);
            //    lemon.SetActive(true);
            //    orange.SetActive(true);
            //    cherry.SetActive(true);
            //    strawberry.SetActive(true);
            //    grape.SetActive(true);
            //    pineapple.SetActive(true);
            //    soda.SetActive(true);
            //    break;

            default:
                break;
        }
    }


}
