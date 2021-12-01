using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnim : MonoBehaviour
{
    public GameObject Title;
    public GameObject Combat01;
    public GameObject Combat02;
    public GameObject Quit;

    private float Timer;
    private bool Bool01 = true;
    private bool Bool02 = true;
    private bool Bool03 = true;
    private bool Bool04 = true;

    private Vector3 TitleStartPos;
    private Vector3 C01StartPos;
    private Vector3 C02StartPos;
    private Vector3 QuitStartPos;

    // Start is called before the first frame update
    void Start()
    {
        TitleStartPos = Title.transform.position;
        C01StartPos = Combat01.transform.position;
        C02StartPos = Combat02.transform.position;
        QuitStartPos = Quit.transform.position;

        Title.transform.position -= new Vector3(0, 1000, 0);
        Combat01.transform.position -= new Vector3(0, 900, 0);
        Combat02.transform.position -= new Vector3(0, 900, 0);
        Quit.transform.position -= new Vector3(0, 900, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > 0f && Bool01)
        {
            Title.transform.DOMoveY(TitleStartPos.y, 1f).SetEase(Ease.OutBounce);
            Bool01 = false;
        }
        else if (Timer > 0.6f && Bool02)
        {
            Combat01.transform.DOMoveY(C01StartPos.y, 1f).SetEase(Ease.OutBounce);
            Bool02 = false;
        }
        else if (Timer > 0.9f && Bool03)
        {
            Combat02.transform.DOMoveY(C02StartPos.y, 1f).SetEase(Ease.OutBounce);
            Bool03 = false;
        }
        else if (Timer > 1.2f && Bool04)
        {
            Quit.transform.DOMoveY(QuitStartPos.y, 1f).SetEase(Ease.OutBounce);
            Bool04 = false;
        }
    }
}
