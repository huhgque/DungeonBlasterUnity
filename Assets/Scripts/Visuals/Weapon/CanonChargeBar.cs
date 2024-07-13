using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonChargeBar : MonoBehaviour
{
    [SerializeField] LazerCanon weapon;
    [SerializeField] ParticleSystem chargePartical;
    Image chargeImage;
    void Start()
    {
        chargeImage = GetComponent<Image>();
        weapon.OnChargeFill += OnChargeFill;
        chargePartical.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        chargeImage.fillAmount = 0;
    }
    void OnChargeFill(object sender, LazerCanon.OnChargeFillArgs args)
    {
        if (args.currentCharge != 0)
        {
            if (args.currentCharge >= args.maxCharge)
            {
                if (chargePartical.isPlaying) chargePartical.Stop(false, ParticleSystemStopBehavior.StopEmitting); ;
            }
            chargeImage.fillAmount = args.currentCharge / args.maxCharge;
            if (!chargePartical.isPlaying) chargePartical.Play();
        }
        else
        {
            chargePartical.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            chargeImage.fillAmount = 0;
        }
    }
}
