using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�^�C�g���Ń}�l�[�W���[�̃I�u�W�F�N�g�������肢���܂�

public sealed class sum_meal_manager : MonoBehaviour
{
    private static sum_meal_manager instance;
    public static sum_meal_manager Instance => instance;

    [SerializeField] public static float calorie_goal;
    public static float calorie_sum = 0.0f;
    public static string meal_name = "��";
    public static int meat_num = 0;
    public static int vegetable_num = 0;
    public static int cereal_num = 0;
    public static int meal_num = 0;

    private void Awake()
    {
        // instance�����łɂ������玩������������B
        if (instance && this != instance)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        // Scene�J�ڂŔj������Ȃ悤�ɂ���B      
        DontDestroyOnLoad(this);
    }

    public void InitMeal()
    {
        calorie_sum = 0.0f;
        meal_name = "��";
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
                adjective += "�{�����[��MAX�I�I";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "�{�����[�������Ղ�";
            }

            if (meat_num >= vegetable_num)
            {
                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "�������낲��";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "��������";
                }

                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "��؂̓�����";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "��ؓ���";
                }
            }
            else
            {
                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "��؂̓�����";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "��ؓ���";
                }

                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "�������낲��";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "��������";
                }
            }

            string[] meal_names = { adjective, meal_name, "��"};
            return meal_names;
        }
        else if(max_ratio == meat_num)
        {
            if (0.7f <= cereal_num / meal_num)
            {
                adjective += "�X�^�~�i���_�I�I";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "���������ς�";
            }

            if(cereal_num >= vegetable_num)
            {
                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "�������";
                }

                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "��؂̓�����";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "��ؓ���";
                }
            }
            else
            {
                if (0.3f <= vegetable_num / meal_num)
                {
                    adjective += "��؂̓�����";
                }
                else if (0.2f <= vegetable_num / meal_num)
                {
                    adjective += "��ؓ���";
                }

                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "�������";
                }
            }
            string[] meal_names = { adjective, meal_name, "��" };
            return meal_names;
        }
        else
        {
            if (0.7f <= cereal_num / meal_num)
            {
                adjective += "��؂̎|������";
            }
            else if (0.5f <= cereal_num / meal_num)
            {
                adjective += "��؂����Ղ�";
            }

            if (cereal_num >= meat_num)
            {
                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "�������";
                }

                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "�������낲��";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "��������";
                }
            }
            else
            {
                if (0.3f <= meat_num / meal_num)
                {
                    adjective += "�������낲��";
                }
                else if (0.2f <= meat_num / meal_num)
                {
                    adjective += "��������";
                }

                if (0.3f <= cereal_num / meal_num)
                {
                    adjective += "�������";
                }
            }
            string[] meal_names = { adjective, meal_name, "��" };
            return meal_names;
        }
    }
}