using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public float m_speed = 50f;
    public float m_durationTime = 0.5f;
    public bool m_isUp = false;
    public Text m_txtUpDown;
    public bool m_isPlaying = false;

    public Animation m_ani;

    void Awake()
    {
        m_txtUpDown.text = "^";
    }

    public void Click_UpDown()
    {
        if(m_isPlaying == true)
        {
            return;
        }

        m_isPlaying = true;
        StartCoroutine(IE_PlayUpDown());
    }

    IEnumerator IE_PlayUpDown()
    {

        // =====애니메이션 처리
        if (m_isUp)
        {
            m_ani.Play("MenuDown");
            m_isUp = false;
        }
        else
        {
            m_ani.Play("MenuUp");
            m_isUp = true;
        }

        yield return new WaitForSeconds(m_durationTime);
        // =====애니메이션 처리

        // ===== deltaTime으로 처리
        // float updateTime = 0;
        // Vector3 direction = m_isUp ? Vector3.down : Vector3.up;
        // while (updateTime < m_durationTime)
        // {
        //    // 이동 공식
        //    transform.position += m_speed * direction * Time.deltaTime;
        //    updateTime += Time.deltaTime;
        //    yield return null;
        // }

        // m_isUp = !m_isUp;
        // ===== deltaTime으로 처리

        m_txtUpDown.text = m_isUp ? "v" : "^";
        m_isPlaying = false;
    }

}
