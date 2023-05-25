using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
   [SerializeField] private PlayerWallet _playerWallet;
   [SerializeField] private TextMeshProUGUI _text;

   private void OnEnable() => _playerWallet.MoneyIncreased += ShowValue;
   

   private void Start() => _text.text = $"${_playerWallet.MoneyPlayer}";
   

   private void ShowValue() => _text.text = $"${_playerWallet.MoneyPlayer}";
   

   private void OnDisable() => _playerWallet.MoneyIncreased -= ShowValue;
   
}
