using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 pos;
    public int type;
    bool isStart;
    void Start()
    {
        this.transform.position = Vector3.zero;
        this.transform.localScale = Vector3.zero;
        isStart = false;
        switch (type)
        {
            case 0:
                GameObject text0 = this.transform.Find("Keiyou").gameObject;
                text0.gameObject.SetActive(true);
                text0.GetComponent<Text>().text = sum_meal_manager.Instance.GetMealName()[0];
                break;
            case 1:
                GameObject text1 = this.transform.Find("Syokuzai").gameObject;
                text1.gameObject.SetActive(true);
                text1.GetComponent<Text>().text = sum_meal_manager.Instance.GetMealName()[1];
                break;
            case 2:
                GameObject text2 = this.transform.Find("Nabe").gameObject;
                text2.gameObject.SetActive(true);
                text2.GetComponent<Text>().text = "“ç";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isStart)
        {
            StartCoroutine(ImageIn());
        }
    }

    private IEnumerator ImageIn()
    {
        isStart = true;
        while (this.transform.localScale.x < 1f)
        {
            this.transform.position += (pos / 60);
            this.transform.localScale += Vector3.one / 60;
            yield return null;
        }
    }
}
