using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReferencesUtil : MonoBehaviour
{
    public void LoadAllAssets()
    {
        AddressableManager.instance.LoadAllAssetsButtonTest();
    }
}