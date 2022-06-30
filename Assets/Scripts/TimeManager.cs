using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float limit = 30.0f;
    public GameObject text;
    public GameObject player;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        // インスタンス作成
        restart = new RestartManager(player, text);
        // 初期時間を設定
        timeText.text = "残り時間：" + limit + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバー時の処理
        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
        
        // カウントダウン終了時の処理
        if(limit < 0)
        {
            restart.PrintGameOver();

            return;
        }

        if (!restart.IsFinish())
        {
            // カウントダウン処理
            limit -= Time.deltaTime;
            timeText.text = "残り時間：" + limit.ToString("f1") + "秒";
        }
        Debug.Log(restart.IsFinish());
    }
}
