using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SheetCharacterPanel : MonoBehaviour
{

    private GameObject sheet;

    void Start()
    {
        Character joueur = Global.S_Joueur;

        Text nameText = transform.FindChild("NameText").GetComponent<Text>();
        Text healthText = transform.FindChild("HealthText").GetComponent<Text>();
        Text manaText = transform.FindChild("ManaText").GetComponent<Text>();
        Text experienceText = transform.FindChild("ExperienceText").GetComponent<Text>();
        Text statInformationText = transform.FindChild("StatInformationText").GetComponent<Text>();

        ProgressBar pbHealth = transform.FindChild("HealthProgressBar").GetComponent<ProgressBar>();
        ProgressBar pbMana = transform.FindChild("ManaProgressBar").GetComponent<ProgressBar>();
        ProgressBar pbXp = transform.FindChild("ExperienceProgressBar").GetComponent<ProgressBar>();

        Image charImage = transform.FindChild("CharacterImage").GetComponent<Image>();
        charImage.sprite = Resources.Load<Sprite>(joueur.ImageEmplacement);

        nameText.text = joueur.Nom + Environment.NewLine + joueur.Espece.Nom + " / " + joueur.Metier.Nom + Environment.NewLine + joueur.Genre + " de "
            + joueur.Age + " ans de niveau " + joueur.Lvl;

        healthText.text = "Santé : " + Mathf.Round(joueur.Pv.ValeurActu) + " / " + Mathf.Round(joueur.Pv.Valeur);
        manaText.text = "Mana : " + Mathf.Round(joueur.Mana.ValeurActu) + " / " + Mathf.Round(joueur.Mana.Valeur);
        experienceText.text = "Xp : " + Mathf.Round(joueur.Xp.ValeurActu) + " / " + Mathf.Round(joueur.Xp.Valeur);

        pbHealth.SetValues(joueur.Pv.Valeur, 0, joueur.Pv.ValeurActu);
        pbMana.SetValues(joueur.Mana.Valeur, 0, joueur.Mana.ValeurActu);
        pbXp.SetValues(joueur.Xp.Valeur, 0, joueur.Xp.ValeurActu);

        statInformationText.text = "Force : " + Mathf.Round(joueur.Force.Valeur) + Environment.NewLine;
        statInformationText.text += "Intelligence : " + Mathf.Round(joueur.Intel.Valeur) + Environment.NewLine;
        statInformationText.text += "Agilité : " + Mathf.Round(joueur.Agi.Valeur) + Environment.NewLine;
        statInformationText.text += "Charisme : " + Mathf.Round(joueur.Cha.Valeur) + Environment.NewLine;
        statInformationText.text += "Cap de Combat : " + Mathf.Round(joueur.Cc.Valeur) + Environment.NewLine;
        statInformationText.text += "Cap de Tir : " + Mathf.Round(joueur.Ct.Valeur) + Environment.NewLine;
        statInformationText.text += "Vitesse : " + Mathf.Round(joueur.Vit.Valeur) + Environment.NewLine;
        statInformationText.text += "Resist Physique : " + Mathf.Round(joueur.ResiP.Valeur) + Environment.NewLine;
        statInformationText.text += "Resist Magique : " + Mathf.Round(joueur.ResiM.Valeur);
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
