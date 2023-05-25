using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
   [SerializeField] private ObjectPool _objectPool;
   public int MoneyPlayer { get; private set; } = 0;
   
   public event Action MoneyIncreased;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out IObjectСollected objectСollected))
      {
         objectСollected.MoveToPlayer(this);
      }
   }

   public void AddMoney(int price)
   {
      if (price > 0)
      {
         MoneyPlayer += price;
         MoneyIncreased?.Invoke();  
      }
      else
         throw new Exception("отрицательное значение " + price);
   }
   
   public bool GetMoney(out Money money)
   {
      var moneyGet = _objectPool.GetMoney();

      if (moneyGet != null)
      {
         money = moneyGet;
         return true;
      }
        
      money = null;
      return false;
   }
}
