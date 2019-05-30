using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //時間計測用
    private float delta = 0f;

    //生成間隔
    public float span = 10f;

    //プレイヤー
    public GameObject player;

    //敵
    public GameObject enemy;

    //プレイヤー位置
    private float playerPosX;
    private float playerPosZ;

    //出現位置調整
    private float PosX;
    private float PosY = 5f;
    private float PosZ;

    //ランダム用
    private int RanX;
    private int RanZ;

    //出現位置決定
    private float genePosX;
    private float genePosZ;

    //敵出現数
    public int enemyAdd = 5;

    //敵出現数上限
    public int enemymax = 20;

    GameObject[] tagObjects;

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;
            tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数

            //敵出現数調整
            if (tagObjects.Length > enemymax - enemyAdd) enemyAdd = 20 - tagObjects.Length;
            if (enemyAdd < 0) enemyAdd = 0;

            if (tagObjects.Length < enemymax)
            {

                for (int i = 0; i < enemyAdd; i++)
                {
                    PosX = Random.Range(20, 51);
                    PosZ = Random.Range(20, 51);

                    RanX = Random.Range(0, 2);
                    RanZ = Random.Range(0, 2);
                    if (RanX == 0)
                    {
                        PosX = PosX * -1f;
                    }
                    if (RanZ == 0)
                    {
                        PosZ = PosZ * -1f;
                    }

                    //プレイヤー位置
                    playerPosX = player.transform.position.x;
                    playerPosZ = player.transform.position.z;

                    //出現位置調整
                    genePosX = playerPosX + PosX;
                    genePosZ = playerPosZ + PosZ;

                    //出現位置上限を190とする
                    if (genePosX > 190f) genePosX = 190f;
                    if (genePosZ > 190f) genePosZ = 190f;

                    //出現数上限

                    //敵の出現
                    Vector3 genePos = new Vector3(genePosX, PosY, genePosZ);
                    GameObject go = Instantiate(enemy) as GameObject;
                    go.transform.position = genePos;
                }
            }

            enemyAdd = 5;

        }
    }
}