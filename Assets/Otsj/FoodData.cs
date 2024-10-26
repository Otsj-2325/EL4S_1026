using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]

public class FooDatad : MonoBehaviour
{
    private enum FoodKind
    {
        Vegetable = 1,
        Meat,
        Carbo,
    }

    #region 設定パラメータ
    [Header("食材のパラメータ")]

    [SerializeField][Tooltip("食材名")]
    string foodName = "";

    [SerializeField]
    [Tooltip("テクスチャ")]
    Sprite texture = null;

    [SerializeField][Tooltip("カロリー値")]
    float calorie = 0;

    [SerializeField][Tooltip("分類")]
    FoodKind kind = 0;

    #endregion


    #region 処理変数
    private SpriteRenderer sprender;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<SpriteRenderer>(out sprender);
        sprender.sprite = texture;


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Cooking()
    {
        switch(kind)
        {
            case FoodKind.Vegetable:
                sum_meal_manager.Instance.PlusCalorie(calorie);
                sum_meal_manager.Instance.PlusMeal((int)kind, name);
                break;

            case FoodKind.Meat:
                sum_meal_manager.Instance.PlusCalorie(calorie);
                sum_meal_manager.Instance.PlusMeal((int)kind, name);
                break;

            case FoodKind.Carbo:
                sum_meal_manager.Instance.PlusCalorie(calorie);
                break;

        }

        print("鍋に投入 : " + gameObject.name);
    }

}
