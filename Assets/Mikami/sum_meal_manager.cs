using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class sum_meal_manager : MonoBehaviour
{
    private static sum_meal_manager instance;
    public static sum_meal_manager Instance => instance;

    [SerializeField] public static float calorie_goal;
    public static float calorie_sum = 0.0f;
    public static string meal_name = "“ç";

    private void Awake()
    {
        // instance‚ª‚·‚Å‚É‚ ‚Á‚½‚ç©•ª‚ğÁ‹‚·‚éB
        if (instance && this != instance)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        // Scene‘JˆÚ‚Å”jŠü‚³‚ê‚È‚æ‚¤‚É‚·‚éB      
        DontDestroyOnLoad(this);
    }
}

public class Title_Meal
{
    public void InitMeal()
    {
        sum_meal_manager.calorie_sum = 0.0f;
        sum_meal_manager.meal_name = "“ç";
    }
}

// "GameScene"‘¤
public class Sum_Meal
{
    public void PlusCalorie(float cal)
    {
        sum_meal_manager.calorie_sum += cal;
    }
    public void PlusMealName(string name)
    {
        sum_meal_manager.meal_name = name + sum_meal_manager.meal_name;
    }
    public int GetScore()
    {
        int score = 100;
        score -= (int)Mathf.Abs((1 - sum_meal_manager.calorie_sum / sum_meal_manager.calorie_goal) * 100);
        return score;
    }
}

// "ResultScene"‘¤
public class Result_Meal
{
    public int GetScore()
    {
        int score = 100;
        score -= (int)Mathf.Abs((1 - sum_meal_manager.calorie_sum / sum_meal_manager.calorie_goal) * 100);
        return score;
    }

    public string GetMealName()
    {
        return sum_meal_manager.meal_name;
    }
}