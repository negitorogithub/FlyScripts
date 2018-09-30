using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class LoadMagicPattern : MonoBehaviour
{
    public List<MagicPatterns> magicPatternsList;
    private String rootDir = "MasterData";
    private String docName = "Magics.json";

    [Serializable]
    public class MagicRoot
    {
        public Magic[] root;
    }

    [Serializable]
    public class Magic
    {
        public string name;
        public int[] magicPatterns;
        public string particleName;
    }



    // Use this for initialization
    void Start()
    {
        magicPatternsList = new List<MagicPatterns>();
        //Resources.Load("Magics") as TextAsset; //Resourcesフォルダから対象テキストを取得
        string itemJson = File.ReadAllText(Path.Combine(Application.dataPath, rootDir, docName)); //テキスト全体をstring型で入れる変数を用意して入れる
        magicPatternsList = LoadFromJson(itemJson);
    }

    //nullを返すことがある!
    public MagicPatterns Equaled(MagicPatterns magicPatterns)
    {
        MagicPatterns magicPatterns2Return = magicPatternsList.FirstOrDefault(pattern => pattern.Equals(magicPatterns));
        if (magicPatterns2Return == null)
        {
            return null;
        }
        else
        {
            return magicPatterns2Return;
        }
    }

    public static List<MagicPatterns> LoadFromJson(string itemJson)
    {
        var magicPatternsList_ = new List<MagicPatterns>();
        MagicRoot magicRoot = JsonUtility.FromJson<MagicRoot>(itemJson);
        foreach (var magicIndexed in magicRoot.root.Select((value, index) => new { value, index }))
        {
            magicPatternsList_.Add(
                MagicPatterns.FromIntArray(magicIndexed.value.magicPatterns,
                magicRoot.root[magicIndexed.index].name,
                magicRoot.root[magicIndexed.index].particleName)
                );
        }
        return magicPatternsList_;
    }

}