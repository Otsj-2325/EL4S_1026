using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//タイトルでマネージャーのオブジェクト生成お願いします

public sealed class sum_meal_manager : MonoBehaviour
{
    private static sum_meal_manager instance;
    public static sum_meal_manager Instance => instance;

    [SerializeField] public static float calorie_goal;
    public static float calorie_sum = 0.0f;
    public static string meal_name = "鍋";

    private void Awake()
    {
        // instanceがすでにあったら自分を消去する。
        if (instance && this != instance)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        // Scene遷移で破棄されなようにする。      
        DontDestroyOnLoad(this);
    }

    public void InitMeal()
    {
        calorie_sum = 0.0f;
        meal_name = "鍋";
    }

    public void PlusCalorie(float cal)
    {
        calorie_sum += cal;
    }

    public void PlusMealName(string name)
    {
        meal_name = name + meal_name;
    }

    public int GetScore()
    {
        int score = 100;
        score -= (int)Mathf.Abs((1 - calorie_sum / calorie_goal) * 100);
        return score;
    }

    public string GetMealName()
    {
        return meal_name;
    }
}

//public class Title_Meal
//{
//    public void InitMeal()
//    {
//        sum_meal_manager.calorie_sum = 0.0f;
//        sum_meal_manager.meal_name = "鍋";
//    }
//}

//// "GameScene"側
//public class Sum_Meal
//{
//    public void PlusCalorie(float cal)
//    {
//        sum_meal_manager.calorie_sum += cal;
//    }
//    public void PlusMealName(string name)
//    {
//        sum_meal_manager.meal_name = name + sum_meal_manager.meal_name;
//    }
//    public int GetScore()
//    {
//        int score = 100;
//        score -= (int)Mathf.Abs((1 - sum_meal_manager.calorie_sum / sum_meal_manager.calorie_goal) * 100);
//        return score;
//    }
//}

//// "ResultScene"側
//public class Result_Meal
//{
//    public int GetScore()
//    {
//        int score = 100;
//        score -= (int)Mathf.Abs((1 - sum_meal_manager.calorie_sum / sum_meal_manager.calorie_goal) * 100);
//        return score;
//    }

//    public string GetMealName()
//    {
//        return sum_meal_manager.meal_name;
//    }
//}