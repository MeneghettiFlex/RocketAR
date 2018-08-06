using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTest : MonoBehaviour {

	public void LoadScene(int index)
    {
        AddressableManager.instance.LoadAssetSceneButtonTest(index);
    }
}
