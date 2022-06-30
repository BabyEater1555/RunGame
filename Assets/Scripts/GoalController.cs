using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public GameObject enemy;
    private float rotateSpeed = 1.0f;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        // ゴールオブジェクトを回転させる
        this.gameObject.transform.Rotate(0, rotateSpeed, 0);

        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
    }

    // 当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == player.name)
        {
            // クリアサウンド再生
            this.gameObject.GetComponent<AudioSource>().Play();

            // 敵非表示
            enemy.SetActive(false);

            restart.PrintGoal();
        }
    }
}
