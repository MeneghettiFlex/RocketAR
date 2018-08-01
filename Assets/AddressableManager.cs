﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableManager : MonoBehaviour
{
    #region Delegates
    public delegate void AssetLoadingHandler(AssetReference assetRef);
    public AssetLoadingHandler OnLoadAll;
    public AssetLoadingHandler OnLoadAsset;

    public void LoadAllAssets()
    {
        if (OnLoadAll != null) OnLoadAll(null);
    }

#endregion

    public static AddressableManager instance = null;

    [SerializeField] AssetLabelReference stationLabel;

    private void Awake()
    {
#region Instance 
        // Ensure that there's exactly ONE instance of GameManager.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
#endregion

    }

    public void LoadAllAssetsButtonTest() // Just a test method
    {
        AddressableManager.instance.LoadAllAssets();
    }
}