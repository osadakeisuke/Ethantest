using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{

    public Vector3 BallOffset = Vector3.zero;
    public GameObject BallPrefab;
    public int BallCount = 20;
    GameObject BallText;

    private void Start()
    {
        BallText = GameObject.Find("BallNum");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BallCount > 0)
            {

                GameObject Ball = Instantiate(BallPrefab) as GameObject;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 worldDir = ray.direction;
                Ball.transform.position = Camera.main.gameObject.transform.position + BallOffset;
                Ball.GetComponent<BallController>().Shoot(worldDir.normalized * 2000);
                BallCount -= 1;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }

        }
        this.BallText.GetComponent<Text>().text = BallCount.ToString("D2");
    }
    public void attackHit(){
        BallCount += 5;
    }
}
