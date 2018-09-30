using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System.IO;

public class GenerateMagicParticle : MonoBehaviour
{
    private const string Path2Load = "magicparticles";
    public SendMagicSummoned sendMagicGenerate;
    private GameObject parent;
    private AssetBundle assetBundle;

    void Start()
    {
        parent = new GameObject();

        sendMagicGenerate.subject.Subscribe(magic =>
        {
            if (assetBundle == null)
            {
                assetBundle = AssetBundle.LoadFromFile(
                    Path.Combine(
                        Application.streamingAssetsPath, Path2Load
                        )
                );
            }
            GameObject particle_ = assetBundle.LoadAsset<GameObject>(magic.particleName);
            Instantiate(particle_, parent.transform);
        });
    }
   
    // Update is called once per frame
    public void DeleteAllParticles()
    {
        Destroy(parent);
        parent = new GameObject();
    }
}
