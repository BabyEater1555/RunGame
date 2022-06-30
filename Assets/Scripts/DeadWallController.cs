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

        // �Q�[���I�[�o�[��Ԃŉ�ʂ��N���b�N���ꂽ�Ƃ�
        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
    }

    //���j�e�B�����Ƃ̓����蔻��
    private void OnCollisionEnter(Collision other)
    {
        //�ڐG�����I�u�W�F�N�g�����j�e�B�����̂Ƃ�
        if (other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
        }
    }
}
