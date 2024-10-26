using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]

public class FooDatad : MonoBehaviour
{
    #region 設定パラメータ
    [Header("食材のパラメータ")]

    [SerializeField][Tooltip("食材名")]
    string foodName = "";

    [SerializeField]
    [Tooltip("テクスチャ")]
    Sprite texture = null;

    [SerializeField][Tooltip("カロリー値")]
    float calorie = 0;

    #endregion


    #region 処理変数
    private SpriteRenderer sprender;
    private Sum_Meal summeal;
    private Result_Meal result;

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
        summeal.PlusCalorie(calorie);
        summeal.PlusMealName(foodName);


        print("Calorie : " + result.GetScore());
        print("Name : " + result.GetMealName());

    }
}
