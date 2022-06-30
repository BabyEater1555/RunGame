using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class RestartManager : MonoBehaviour
{
    private GameObject player;
    private GameObject text;
    private bool isFinish = false;

    // コンストラクタ
    public RestartManager(GameObject player, GameObject text)
    {
        this.player = player;
        this.text = text;
    }

    public void PrintGoal()
    {
        // ゴールテキストを表示
        text.GetComponent<Text>().text = "GOAL!";
        text.SetActive(true);

        //ユニティちゃんを動けなくする
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        //アニメーションをオフにする
        player.GetComponent<Animator>().enabled = false;

        // ゲーム終了フラグ
        isFinish = true;
    }

    public void PrintGameOver()
    {
        // ゲームオーバーテキストを表示する
        text.GetComponent<Text>().text = "GAMEOVER...";
        text.SetActive(true);

        // ユニティちゃんを動けなくする
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        // アニメーションをオフにする
        player.GetComponent<Animator>().enabled = false;

        // ゲーム終了フラグ
        isFinish = true;
    }

    public void Restart()
    {
        // 現在のシーンを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // シーンの読み直し
        SceneManager.LoadScene(loadScene.name);
    }

    // ゲーム終了判定
    public bool IsFinish()
    {
        return isFinish;
    }
}
