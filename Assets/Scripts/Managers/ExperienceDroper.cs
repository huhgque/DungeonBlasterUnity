using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDroper : MonoBehaviour
{
    [SerializeField] ExperienceOrb experienceOrb;

    public void DropExperience(Vector3 position,int value){
        ExperienceOrb orbObject = Instantiate(experienceOrb);
        orbObject.transform.position = position;
        orbObject.SetValue(value);
        orbObject.gameObject.SetActive(true);
    }
}
