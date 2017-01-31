using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SheetCharacterPanel : MonoBehaviour
{
    private GameObject sheet;

    void Start()
    {
        if (Global.S_Joueur == null) return;

        Character joueur = Global.S_Joueur;

        Text nameText = transform.FindChild("NameText").GetComponent<Text>();
        Text healthText = transform.FindChild("HealthText").GetComponent<Text>();
        Text manaText = transform.FindChild("ManaText").GetComponent<Text>();
        Text experienceText = transform.FindChild("ExperienceText").GetComponent<Text>();
        Text statInformationText = transform.FindChild("StatInformation").FindChild("StatInformationText").GetComponent<Text>();

        ProgressBar pbHealth = transform.FindChild("HealthProgressBar").GetComponent<ProgressBar>();
        ProgressBar pbMana = transform.FindChild("ManaProgressBar").GetComponent<ProgressBar>();
        ProgressBar pbXp = transform.FindChild("ExperienceProgressBar").GetComponent<ProgressBar>();

        Image charImage = transform.FindChild("CharacterImage").GetComponent<Image>();
        charImage.sprite = Resources.Load<Sprite>(joueur.ImageEmplacement);

        CharacteristicConsumable hp, mana;

        hp = (CharacteristicConsumable)joueur.Charac[(int)Statistic.EStat.Hp];
        mana = (CharacteristicConsumable)joueur.Charac[(int)Statistic.EStat.Mana];


        nameText.text = joueur.Name + Environment.NewLine + joueur.Species.Name + " / " + joueur.Classe.Name + Environment.NewLine + joueur.Genre + " de "
            + joueur.Age + " ans de niveau " + joueur.Lvl;

        healthText.text = "Santé : " + Mathf.Round(hp.ValeurActu) + " / " + Mathf.Round(hp.Valeur);
        manaText.text = "Mana : " + Mathf.Round(mana.ValeurActu) + " / " + Mathf.Round(mana.Valeur);
        experienceText.text = "Xp : " + Mathf.Round(joueur.Xp.ValeurActu) + " / " + Mathf.Round(joueur.Xp.Valeur);

        pbHealth.SetValues(hp.Valeur, 0, hp.ValeurActu);      
        pbMana.SetValues(mana.Valeur, 0, mana.ValeurActu);
        pbXp.SetValues(joueur.Xp.Valeur, 0, joueur.Xp.ValeurActu);

        statInformationText.text = "Force : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Str].Valeur) + Environment.NewLine;
        statInformationText.text += "Intelligence : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Int].Valeur) + Environment.NewLine;
        statInformationText.text += "Agilité : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Agi].Valeur) + Environment.NewLine;
        statInformationText.text += "Charisme : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Cha].Valeur) + Environment.NewLine;
        statInformationText.text += "Cap de Combat : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Cc].Valeur) + Environment.NewLine;
        statInformationText.text += "Cap de Tir : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Ct].Valeur) + Environment.NewLine;
        statInformationText.text += "Vitesse : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Spd].Valeur) + Environment.NewLine;
        statInformationText.text += "Resist Physique : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.ResiP].Valeur) + Environment.NewLine;
        statInformationText.text += "Resist Magique : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.ResiM].Valeur) + Environment.NewLine;
        statInformationText.text += "Point d'Action : " + Mathf.Round(joueur.Charac[(int)Statistic.EStat.Pa].Valeur) + Environment.NewLine;
        statInformationText.text += "Point de Carac restant : " + joueur.PtsAmelioration;

        //statInformationText.text = joueur.Classe.ToString();
    }

    public void Close()
    {
        sheet = GameObject.Find(Global.S_SheetCharacterName);

        if (sheet != null)
        {
            Global.S_SheetCharacterOpen = false;
            Destroy(sheet);
        }
    }
}
