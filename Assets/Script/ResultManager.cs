using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform button01;
    public Transform button02;
    private int score;
    public Text scoreText;
    bool isStarted;


    public GameObject food;

    
    public int[] ShowType = { 1, 1, 2 };
    void Start()
    {
        //GetComponent<ScoreManager>().SetScore(100);
        button01.gameObject.SetActive(false);
        button02.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("Score");
        if (!isStarted)
        {
            StartCoroutine(ShowName);
        }

            

    }
    private IEnumerator ShowName
    {
        get
        {
            isStarted = true;
            for(int i = 0; i < 3; i++) 
            {
                GameObject food1 = Instantiate(food, new Vector3(0, 0, 0), Quaternion.identity);
                food1.GetComponent<NameManager>().pos = Vector3.zero;
                food1.GetComponent<NameManager>().type = i;
                yield return new WaitForSeconds(1f);
            }
            StartCoroutine(AnimaScore());
        }
    }

    private IEnumerator AnimaScore()
    {
        scoreText.gameObject.SetActive(true);
        int enumScore = 0;
        while (enumScore <= score)
        {
            scoreText.text = enumScore.ToString();
            enumScore++;
            yield return null;
        }
        button01.gameObject.SetActive(true);
        button02.gameObject.SetActive(true);
    }
}
