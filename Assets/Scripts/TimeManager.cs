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
        // �C���X�^���X�쐬
        restart = new RestartManager(player, text);
        // �������Ԃ�ݒ�
        timeText.text = "�c�莞�ԁF" + limit + "�b";
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I�[�o�[���̏���
        if (restart.IsFinish() && Input.GetMouseButtonDown(0))
        {
            restart.Restart();
        }
        
        // �J�E���g�_�E���I�����̏���
        if(limit < 0)
        {
            restart.PrintGameOver();

            return;
        }

        if (!restart.IsFinish())
        {
            // �J�E���g�_�E������
            limit -= Time.deltaTime;
            timeText.text = "�c�莞�ԁF" + limit.ToString("f1") + "�b";
        }
        Debug.Log(restart.IsFinish());
    }
}
