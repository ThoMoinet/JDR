using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DisplayInformation : MonoBehaviour
{
    public void Affichage(Character pChar)
    {
        if (Global.S_MenuCanvas != null)
        {
            if (pChar != null)
            {
                Text nameText = transform.FindChild("NameText").GetComponent<Text>();
                Text healthText = transform.FindChild("HealthText").GetComponent<Text>();
                Text manaText = transform.FindChild("ManaText").GetComponent<Text>();
                Text paText = transform.FindChild("PaText").GetComponent<Text>();
                Text statInformationText = transform.FindChild("StatInformationText").GetComponent<Text>();

                CharacteristicConsumable hp, mana, pa;

                hp = (CharacteristicConsumable)pChar.Charac[(int)Statistic.EStat.Hp];
                mana = (CharacteristicConsumable)pChar.Charac[(int)Statistic.EStat.Mana];
                pa = (CharacteristicConsumable)pChar.Charac[(int)Statistic.EStat.Pa];

                nameText.text = pChar.Name + " (lvl : " + pChar.Lvl + ")" + Environment.NewLine + pChar.Species.Name + " / " + pChar.Classe.Name;
                healthText.text = "Santé : " + Mathf.Round(hp.ValeurActu) + " / " + Mathf.Round(hp.Valeur);
                manaText.text = "Mana : " + Mathf.Round(mana.ValeurActu) + " / " + Mathf.Round(mana.Valeur);
                paText.text = "Pa : " + Mathf.Round(pa.ValeurActu) + " / " + Mathf.Round(pa.Valeur);

                statInformationText.text = "Force : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Str].Valeur) + Environment.NewLine;
                statInformationText.text += "Intelligence : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Int].Valeur) + Environment.NewLine;
                statInformationText.text += "Agilité : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Agi].Valeur) + Environment.NewLine;
                statInformationText.text += "Charisme : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Cha].Valeur) + Environment.NewLine;
                statInformationText.text += "Cap de Combat : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Cc].Valeur) + Environment.NewLine;
                statInformationText.text += "Cap de Tir : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Ct].Valeur) + Environment.NewLine;
                statInformationText.text += "Vitesse : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.Spd].Valeur) + Environment.NewLine;
                statInformationText.text += "Resist Physique : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.ResiP].Valeur) + Environment.NewLine;
                statInformationText.text += "Resist Magique : " + Mathf.Round(pChar.Charac[(int)Statistic.EStat.ResiM].Valeur);

                ProgressBar pbHealth = transform.FindChild("HealthProgressBar").GetComponent<ProgressBar>();
                ProgressBar pbMana = transform.FindChild("ManaProgressBar").GetComponent<ProgressBar>();
                ProgressBar pbPa = transform.FindChild("PaProgressBar").GetComponent<ProgressBar>();

                pbHealth.SetValues(hp.Valeur, 0, hp.ValeurActu);
                pbMana.SetValues(mana.Valeur, 0, mana.ValeurActu);
                pbPa.SetValues(pa.Valeur, 0, pa.ValeurActu);
            }
            else
            {
                Debug.LogError("'pChar' can't be null");
            }
        }
        else
        {
            Debug.LogError("'CanevasMenu' can't be null");
        }
    }
}
