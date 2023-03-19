using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserNameManeger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userNameText;

    public void SetUserName(string userName)
    {
        _userNameText.text = userName;
    }
}
