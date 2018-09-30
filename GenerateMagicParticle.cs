using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System.IO;

public class GenerateMagicParticle : MonoBehaviour
{
    public SendMagicSummoned sendMagicGenerate;
    private GameObject parent;

    void Start()
    {
        parent = new GameObject();

        sendMagicGenerate.subject.Subscribe(magic =>
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(
                    Path.Combine(
                        Application.streamingAssetsPath, "magicparticles"
                        )
                );
            GameObject particle_ = assetBundle.LoadAsset<GameObject>(magic.particleName);
            Instantiate(particle_, parent.transform);
        });
    }
   
    // Update is called once per frame
    public void DeleteAllParticles()
    {
        parent = new GameObject();
    }
}
