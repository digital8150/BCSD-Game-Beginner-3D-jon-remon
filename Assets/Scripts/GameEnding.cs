using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [Header("��ũ�� ǥ�� �ð�")]
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    [Header("���� ���� ��ũ�� ����")]
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    [Header("���� ������Ʈ ����")]
    public GameObject player;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
            Debug.Log("��������!!");

        }
        else
        {
            Debug.Log($"{other.name}");
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);

            }
            else
            {
                Application.Quit();
            }
        }
    }
}
