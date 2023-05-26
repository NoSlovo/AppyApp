using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarrotTower : MonoBehaviour
{
    private Stack<Carrot> _colection = new (2);
    private bool _isRefreshExecuted;
    private int _currentCount;
    private float _itemHeight = 0.25f;

    public int CountItemsTower => _colection.Count; 

    public bool PutElementColection(Carrot collectable)
    {
        if (_currentCount < 2)
        {
            var targetPosition = new Vector3(0, _currentCount * _itemHeight, 0);
            _currentCount++;
            collectable.transform.SetParent(transform);
            collectable.transform.DOLocalJump(targetPosition, 1f, 1, 0.3f)
                .OnComplete(() =>
                {
                    _colection.Push(collectable);
                });

            collectable.transform.DOLocalRotate(new Vector3(90f, 100f, 0f), 0.1f).OnComplete(() =>
            {
                var targetRotation = new Vector3(90f, 100f, 0f);
                collectable.transform.DOLocalRotate(targetRotation, 0);
            });

            return true;
        }

        return false;
    }
    
    public Carrot TryElement()
    {
        if (_colection.Count > 0)
        {
            var elemntColection = _colection.Pop();
            _currentCount--;
            elemntColection.transform.SetParent(null);
            return elemntColection;
        }
        return null;
    }
}
