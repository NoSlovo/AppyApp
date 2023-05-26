using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  private List<Money> _moneyPool = new (10);

  public void AddObjectPool(Money money)
  {
    _moneyPool.Add(money);
    money.gameObject.SetActive(false);
  }

  public void GetMoney(out Money money)
  {
    for(int i = 0; i <  _moneyPool.Count;i++)
    {
      if (_moneyPool[i].isActiveAndEnabled == false)
      {
        _moneyPool[i].gameObject.SetActive(true);
        money = _moneyPool[i];
        return;
      }
    }
    money = Instantiate(_moneyPool[1]);
    _moneyPool.Add(money);
  }
  
}
