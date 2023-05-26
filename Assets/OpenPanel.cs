using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] private AviaryOpen _aviary;
    [SerializeField] private GameObject _garden;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Canvas _canvasPanel;
    
    private float _duration = 0.5f;
    private float _animationDuration = 0.5f;
    private float _maxDurationValue = 0.5f;
    private Vector3 _scale;

    private int _priceOpen = 60;

    private void OnEnable()
    {
        if (transform.localScale == Vector3.zero)
            transform.localScale = _scale;
        
    }

    private void Start()
    {
        _text.text = $"{_priceOpen}";
        var scale = transform.localScale + new Vector3(0.005f, 0, 0.005f);
        transform.DOScale(scale, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (_priceOpen == 0)
        {
            _canvasPanel.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet playerWallet) && _priceOpen > 0)
        {
            _duration -= 0.01f;

            if (_duration > 0)
                return;

            if (playerWallet.MoneyPlayer <= 0)
                return;

            if (playerWallet.GetMoney(out Money money))
            {
                GetMoneyPlayer(money);
                _duration = _maxDurationValue;
            }
        }
    }

    private void GetMoneyPlayer(Money money)
    {
        var scale = new Vector3(0.73f,0.26f,0.4f);
        
        money.transform.localScale = scale;
        
        money.transform.DOMove(_text.transform.position, _animationDuration);
        money.transform.DOScale(new Vector3(0, 0, 0), _animationDuration).OnComplete(() =>
        {
            money.Reset();
            WriteMoney(money.Price);
        });
    }

    private void WriteMoney(int price)
    {
        if (price > 0)
        {
            _priceOpen -= price;
            _text.text = $"{_priceOpen}";
            OpenObject();
        }
    }

    private void OpenObject()
    {
        if (_priceOpen <= 0)
        {
            _aviary.AviaryCreate();
            _garden.SetActive(true);
        }   
    }

}