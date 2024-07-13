using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    const int MAX_OPTION = 4;
    [SerializeField] SelectOption selectOptionTemplate;
    [SerializeField] GameObject container;
    List<SelectOption> options = new();
    void Awake() {
        selectOptionTemplate.gameObject.SetActive(false);
    }
    public void GenerateOption(List<UpgradeOptionSO> pool){
        int optionnum = Math.Min(MAX_OPTION,pool.Count);
        ClearOptionList();
        for (int i = 0; i < optionnum; i++)
        {
            SelectOption option = Instantiate(selectOptionTemplate,container.transform);
            option.SetOptionData(i,pool[i]);
            option.gameObject.SetActive(true);
            options.Add(option);
        }
    }
    void ClearOptionList(){
        foreach (var item in options)
        {
            Destroy(item.gameObject);
        }
        options.Clear();
    }
}
