using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPatternLoader : MonoBehaviour
{

    [System.Serializable]
    public class Player
    {
        public int hp;
        public int attack;
        public int defense;
    }

    [Serializable]
    public class MagicRoot
    {
        public int[] test;
        public int[] magicPatterns;
    }

    [Serializable]
    public class MagicPatterns
    {
        public int[][] patterns;
    }

    [Serializable]
    public class LineByNumberArray
    {
        public int[] pattern;
    }



    // Use this for initialization
    void Start()
    {
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("Magics") as TextAsset; //Resourcesフォルダから対象テキストを取得
        string itemJson = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる
        MagicRoot magicRoot = JsonUtility.FromJson<MagicRoot>(itemJson);
        Debug.Log(magicRoot.magicPatterns[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
