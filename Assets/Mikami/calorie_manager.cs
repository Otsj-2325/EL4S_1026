using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calorie_manager : MonoBehaviour
{
    [SerializeField] private float calorie_goal;
    private float calorie_sum = 0.0f;
    private string meal_name = "“ç";

    // Start is called before the first frame update
    void Start()
    {
        calorie_sum = 0.0f;
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
