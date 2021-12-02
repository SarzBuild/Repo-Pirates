using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnim : MonoBehaviour
{
    [SerializeField] public GameObject Title;
    [SerializeField] public GameObject Combat01;
    [SerializeField] public GameObject Combat02;
    [SerializeField] public GameObject Quit;
    [SerializeField] public GameObject Ship;
    [SerializeField] public SpriteRenderer ShipSprite;
    [SerializeField] public GameObject Octo1;
    [SerializeField] public GameObject Octo2;

    [SerializeField] [HideInInspector] private float _timer;
    [SerializeField] [HideInInspector] private bool _bool01 = true;
    [SerializeField] [HideInInspector] private bool _bool02 = true;
    [SerializeField] [HideInInspector] private bool _bool03 = true;
    [SerializeField] [HideInInspector] private bool _bool04 = true;
    [SerializeField] [HideInInspector] private bool _boolShip = true;
    [SerializeField] [HideInInspector] private bool _boolOcto1 = true;
    [SerializeField] [HideInInspector] private bool _boolOcto2 = true;

    [SerializeField] [HideInInspector] private Vector3 _titleStartPos;
    [SerializeField] [HideInInspector] private Vector3 _c01StartPos;
    [SerializeField] [HideInInspector] private Vector3 _c02StartPos;
    [SerializeField] [HideInInspector] private Vector3 _quitStartPos;

    // Start is called before the first frame update
    void Start()
    {
        _titleStartPos = Title.transform.position;
        _c01StartPos = Combat01.transform.position;
        _c02StartPos = Combat02.transform.position;
        _quitStartPos = Quit.transform.position;

        Title.transform.position -= new Vector3(0, 1000, 0);
        Combat01.transform.position -= new Vector3(0, 900, 0);
        Combat02.transform.position -= new Vector3(0, 900, 0);
        Quit.transform.position -= new Vector3(0, 900, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > 0f && _bool01)
        {
            Title.transform.DOMoveY(_titleStartPos.y, 1f).SetEase(Ease.OutBounce);
            _bool01 = false;
        }
        else if (_timer > 0.6f && _bool02)
        {
            Combat01.transform.DOMoveY(_c01StartPos.y, 1f).SetEase(Ease.OutBounce);
            _bool02 = false;
        }
        else if (_timer > 0.9f && _bool03)
        {
            Combat02.transform.DOMoveY(_c02StartPos.y, 1f).SetEase(Ease.OutBounce);
            _bool03 = false;
        }
        else if (_timer > 1.2f && _bool04)
        {
            Quit.transform.DOMoveY(_quitStartPos.y, 1f).SetEase(Ease.OutBounce).OnComplete(StartAnims);
            _bool04 = false;
        }
    }

    private void Octo1Move()
    {
        if (_boolOcto1)
        {
            Octo1.transform.DOMoveY(-3.5f, 4f).SetEase(Ease.OutSine).OnComplete(Octo2Move);
            _boolOcto1 = false;
        }
        else
        {
            Octo2.transform.DOMoveY(-3.5f, 4f).SetEase(Ease.OutSine).OnComplete(Octo2Move);
            _boolOcto1 = true;
        }
    }

    private void Octo2Move()
    {
        if (_boolOcto2)
        {
            Octo1.transform.DOMoveY(-7f, 4f).SetEase(Ease.InSine).OnComplete(Octo1Move);
            _boolOcto2 = false;
        }
        else
        {
            Octo2.transform.DOMoveY(-7f, 4f).SetEase(Ease.InSine).OnComplete(Octo1Move);
            _boolOcto2 = true;
        }
    }

    private void ShipMove()
    {
        if (_boolShip)
        {
            Ship.transform.DOMoveX(10f, 30f).SetEase(Ease.Linear).OnComplete(ShipMove);
            ShipSprite.flipX = false;
            _boolShip = false;
        }
        else
        {
            Ship.transform.DOMoveX(-10f, 30f).SetEase(Ease.Linear).OnComplete(ShipMove);
            ShipSprite.flipX = true;
            _boolShip = true;
        }
    }

    private void StartAnims()
    {
        Octo1Move();
        ShipMove();
    }
}
