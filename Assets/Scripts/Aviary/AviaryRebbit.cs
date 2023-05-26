using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AviaryRebbit : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _text;
   [SerializeField] private Canvas _canvas;
   [SerializeField] private int _counterCarret = 0;
   [SerializeField] private int _maxCarretValue = 4;
   
   private float _delay = 0.2f;
   private float _delayMax = 0.2f;

   private void Start()
   {
      _text.text = $"{_counterCarret}/ {_maxCarretValue}";
   }

   private void OnTriggerStay(Collider other)
   {
      _delay -= Time.deltaTime;

      if (_counterCarret == _maxCarretValue)
         return;
      
      
      if (other.TryGetComponent(out CarrotTower tower) && _delay <= 0)
      {
         var carrot = tower.TryElement();
         if (carrot is null)
            return;
         
         carrot.transform.DOMove(transform.position, 0.5f);
         carrot.transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
         {
            _counterCarret++;
            _text.text = $"{_counterCarret}/ {_maxCarretValue}";
            DisableCanvas();
            Destroy(carrot);
         });
         _delay = _delayMax;
      }
      
   }

   private void DisableCanvas()
   {
      if (_counterCarret == _maxCarretValue)
      {
         StartCoroutine(CanvasDisable());
      }
   }

   private IEnumerator CanvasDisable()
   {
      var waitForSecondsRealtime = new WaitForSecondsRealtime(1f);
      yield return waitForSecondsRealtime;
      _canvas.gameObject.SetActive(false);
      
   }
}
