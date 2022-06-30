using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityChan;
using UnityEngine.UI;

public class DeadWallController : MonoBehaviour
{
    public float spped = 2.0f;
    public float max_x = 10.0f;
    public GameObject player;
    public GameObject text;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(spped, 0, 0);
        
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            spped *= -1;
        }

        // ゲームオーバー状態で画面がクリックされたとき
        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
    }

    //ユニティちゃんとの当たり判定
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if (other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
        }
    }
}
