using System;
using System.Collections;
using UnityEngine;

public class VegetableGarden : Factory<Carrot>
{
    [SerializeField] private Sprout _sprout;
    [SerializeField] private float _delayBeforeSprout = 2.5f;
    [SerializeField] private float _delayBeforeMaturation = 2.5f;

    private bool IsSomethingGrowing = false;

    private Carrot _carrot;

    private void OnEnable()
    {
        IsSomethingGrowing = true;
        StartCoroutine(Nurture());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarrotTower carrotTower))
        {
            if (_carrot != null)
            {
                if (carrotTower.PutElementColection(_carrot))
                    _carrot = null;
            }

            if (!IsSomethingGrowing && _carrot is null)
            {
                IsSomethingGrowing = true;
                StartCoroutine(Nurture());
            }
        }
    }

    private IEnumerator Nurture()
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(_delayBeforeSprout);
        var waitForSecondsRealtimeTwo = new WaitForSecondsRealtime(_delayBeforeMaturation);
        
        while (IsSomethingGrowing)
        {
            yield return waitForSecondsRealtime;
            
            _sprout.gameObject.SetActive(true);

            yield return waitForSecondsRealtimeTwo;

            _sprout.gameObject.SetActive(false);
           var objectInstance =  InstanceObject();
           objectInstance.transform.position = transform.position;
           _carrot = objectInstance;
           IsSomethingGrowing = false;
        }
    }
}