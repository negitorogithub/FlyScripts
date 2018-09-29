using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System.IO;

public class GenerateMagicParticle : MonoBehaviour
{
    public MagicPatternLoader magicPatternLoader;
    public OnPointerClickingEnterHolder enterHolder;

    void Start()
    {

        enterHolder.addedLineNumber.Subscribe(_ =>
        {
            var equaledMagic = magicPatternLoader.Equaled(new MagicPatterns().SetList(enterHolder.lines));
            if (equaledMagic != null)
            {
                AssetBundle assetBundle = AssetBundle.LoadFromFile(
                        Path.Combine(
                            Application.streamingAssetsPath, "magicparticles"
                            )
                    );
                GameObject particle_ = assetBundle.LoadAsset<GameObject>(equaledMagic.particleName);
                Instantiate(particle_);
            }
        }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
