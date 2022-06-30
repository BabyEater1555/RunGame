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

    // �R���X�g���N�^
    public RestartManager(GameObject player, GameObject text)
    {
        this.player = player;
        this.text = text;
    }

    public void PrintGoal()
    {
        // �S�[���e�L�X�g��\��
        text.GetComponent<Text>().text = "GOAL!";
        text.SetActive(true);

        //���j�e�B�����𓮂��Ȃ�����
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        //�A�j���[�V�������I�t�ɂ���
        player.GetComponent<Animator>().enabled = false;

        // �Q�[���I���t���O
        isFinish = true;
    }

    public void PrintGameOver()
    {
        // �Q�[���I�[�o�[�e�L�X�g��\������
        text.GetComponent<Text>().text = "GAMEOVER...";
        text.SetActive(true);

        // ���j�e�B�����𓮂��Ȃ�����
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        // �A�j���[�V�������I�t�ɂ���
        player.GetComponent<Animator>().enabled = false;

        // �Q�[���I���t���O
        isFinish = true;
    }

    public void Restart()
    {
        // ���݂̃V�[�����擾
        Scene loadScene = SceneManager.GetActiveScene();
        // �V�[���̓ǂݒ���
        SceneManager.LoadScene(loadScene.name);
    }

    // �Q�[���I������
    public bool IsFinish()
    {
        return isFinish;
    }
}
