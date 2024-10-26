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
    public static int meat_num = 0;
    public static int vegetable_num = 0;
    public static int cereal_num = 0;
    public static int meal_num = 0;

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
        meat_num = 0;
        vegetable_num = 0;
        cereal_num = 0;
        meal_num = 0;
    }

    public void PlusCalorie(float cal)
    {
        calorie_sum += cal;
    }

    public void PlusMeal(int kinds)
    {
        switch (kinds)
        {
            case 1:
                vegetable_num++;
                break;
            case 2:
                meat_num++;
                break;
            case 3:
                cereal_num++;
                break;
        }
        meal_num++;
    }

    public void PlusMeal(int kinds, string name)
    {
        meal_name = name;
        PlusMeal(kinds);
    }

    public int GetScore()
    {
        int score = 100;
        score -= (int)Mathf.Abs((1 - calorie_sum / calorie_goal) * 100);
        return score;
    }

    public string[] GetMealName()
    {
        int max_ratio = Mathf.Max(vegetable_num, meat_num, cereal_num);
        string adjective = "";
        if (max_ratio == cereal_num)
        {
            if(0.7f <= cereal_num / meal_num)
            {
                adjective += "ボリュームMAX！！";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "ボリュームたっぷり";
            }

            if (meat_num >= vegetable_num)
            {
                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "お肉ごろごろ";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "お肉入り";
                }

                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "野菜の入った";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "野菜入り";
                }
            }
            else
            {
                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "野菜の入った";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "野菜入り";
                }

                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "お肉ごろごろ";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "お肉入り";
                }
            }

            string[] meal_names = { adjective, meal_name, "鍋"};
            return meal_names;
        }
        else if(max_ratio == meat_num)
        {
            if (0.7f <= cereal_num / meal_num)
            {
                adjective += "スタミナ満点！！";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "お肉いっぱい";
            }

            if(cereal_num >= vegetable_num)
            {
                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "具だくさん";
                }

                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "野菜の入った";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "野菜入り";
                }
            }
            else
            {
                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "野菜の入った";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "野菜入り";
                }

                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "具だくさん";
                }
            }
            string[] meal_names = { adjective, meal_name, "鍋" };
            return meal_names;
        }
        else
        {
            if (0.7f <= cereal_num / meal_num)
            {
                adjective += "野菜の旨味溢れる";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "野菜たっぷり";
            }

            if (cereal_num >= meat_num)
            {
                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "具だくさん";
                }

                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "お肉ごろごろ";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "お肉入り";
                }
            }
            else
            {
                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "お肉ごろごろ";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "お肉入り";
                }

                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "具だくさん";
                }
            }
            
            string[] meal_names = { adjective, meal_name, "鍋" };
            return meal_names;
        }
    }
}