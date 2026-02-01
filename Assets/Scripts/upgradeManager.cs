using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
    public upgradeStats[] upgradeStats;
    public Image upgradeIcon;
    public TextMeshProUGUI coinCost;
    public int currentUpgradeLevel;
    public rewardSystem rewardSystem;
    public TextMeshProUGUI upgradeText;
    public Slider upgradeSlider;

    void Start()
    {
        
    }

    void Update()
    {
        upgradeSlider.value = currentUpgradeLevel;
        if(currentUpgradeLevel >= upgradeStats.Length)
        {
            coinCost.text = upgradeStats[upgradeStats.Length - 1].cost.ToString();
            upgradeIcon.sprite = upgradeStats[upgradeStats.Length - 1].icon;
            upgradeText.text = upgradeStats[upgradeStats.Length - 1].name;
            return;
        }
        coinCost.text = upgradeStats[currentUpgradeLevel].cost.ToString();
        upgradeIcon.sprite = upgradeStats[currentUpgradeLevel].icon;
        upgradeText.text = upgradeStats[currentUpgradeLevel].name;
    }

    public void upgrade()
    {
        if(currentUpgradeLevel < upgradeStats.Length && rewardSystem.coinCount >= upgradeStats[currentUpgradeLevel].cost)
        {
            upgradeStats[currentUpgradeLevel].action.Invoke();
            rewardSystem.coinCount -= upgradeStats[currentUpgradeLevel].cost;
            currentUpgradeLevel += 1;         
        }
    }
}
