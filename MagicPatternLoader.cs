using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagicPatternLoader : MonoBehaviour
{
    public MagicPatterns magicPatterns;

    [Serializable]
    public class MagicRoot
    {
        public int[] test;
        public int[] magicPatterns;
    }



    // Use this for initialization
    void Start()
    {
        magicPatterns = new MagicPatterns();
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("Magics") as TextAsset; //Resourcesフォルダから対象テキストを取得
        string itemJson = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる
        var magicRoot = JsonUtility.FromJson<MagicRoot>(itemJson);
        Debug.Log(magicRoot.magicPatterns[0]);
    }

    
}
