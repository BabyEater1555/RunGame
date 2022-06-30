using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public static bool isDrop;

    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
        isDrop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            restart.PrintGameOver();

            // クリアフラグ
            isDrop = restart.IsFinish();
        }

        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
        
    }
}
