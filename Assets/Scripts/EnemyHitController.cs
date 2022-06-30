using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public static bool isHitEnemy;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
        isHitEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == player.name)
        {
            restart.PrintGameOver();

            //ゲームオーバーフラグ
            isHitEnemy = restart.IsFinish();
        }
    }
}
