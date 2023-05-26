using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BedsOpenPanel : MonoBehaviour
{
    [SerializeField] private VegetableGarden _vegetableGarden;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Canvas _canvasPanel;
    
    private int _priceOpen = 10;
    private float _duration = 1f;
    private float _maxDurationValue = 1f;
    private float _animationDuration = 1f;

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
            _vegetableGarden.gameObject.SetActive(true);
            _canvasPanel.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }   
    }

    
}
