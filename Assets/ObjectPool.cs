using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  private List<Money> _moneyPool = new (10);
  private int _poolSize = 10;

  public void AddObjectPool(Money money)
  {
    if (_moneyPool.Count > _poolSize)
      Destroy(money);
    
    money.transform.SetParent(transform);
    _moneyPool.Add(money);
    money.gameObject.SetActive(false);
  }

  public Money GetMoney()
  {
    foreach (var money in _moneyPool)
    {
      if (!money.isActiveAndEnabled)
      {
        money.gameObject.SetActive(true);
        return money;
      }
    }

    var monetInstantiate = Instantiate(_moneyPool[1]);
    AddObjectPool(monetInstantiate);
    return monetInstantiate;
  }
  
}
