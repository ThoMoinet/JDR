using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class CasePlateau : MonoBehaviour
{
    public Character Personnage;
    public float ScalBordureX;
    public float ScalBordureY;
    public string SpriteBordure;
    public Vector3 Correction;

    private GameObject _displayInformation;
    private SpriteRenderer _spriteBordure;
    private SpriteRenderer _spritPerso;

    void Awake()
    {
        Vector3 scale = new Vector3(ScalBordureX, ScalBordureY, 0);
        transform.localScale = scale;

        _spriteBordure = transform.GetComponent<SpriteRenderer>();
        _spritPerso = transform.Find("ImagePerso").GetComponent<SpriteRenderer>();

        _spritPerso.transform.localScale = new Vector3(4.5F,4.5F);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Affichage()
    {
        if (_spriteBordure == null || _spritPerso == null) return;
        _spriteBordure.sprite = Resources.Load<Sprite>(SpriteBordure);

        if (Personnage == null) return;
        _spritPerso.sprite = Resources.Load<Sprite>(Personnage.ImageEmplacement);
    }

    void OnMouseEnter()
    {
        if (_displayInformation != null || Personnage == null || Global.S_SheetCharacterOpen) return;

        if (Global.S_MenuCanvas != null)
        {
            Vector3 screenPosition = Global.S_PlateauManager._camera.WorldToScreenPoint(transform.position + Correction);
            float sizeX, sizeY;

            _displayInformation = Instantiate(Global.S_DisplayInformation, Vector3.zero, Quaternion.identity) as GameObject;
            _displayInformation.transform.SetParent(Global.S_MenuCanvas.transform);

            sizeX = _displayInformation.transform.GetComponent<RectTransform>().rect.size.x;
            sizeY = _displayInformation.transform.GetComponent<RectTransform>().rect.size.y;

            _displayInformation.transform.position = new Vector3(screenPosition.x + (sizeX / 2), screenPosition.y - (sizeY / 2));

            Text nameText = _displayInformation.transform.FindChild("NameText").GetComponent<Text>();
            Text healthText = _displayInformation.transform.FindChild("HealthText").GetComponent<Text>();
            Text manaText = _displayInformation.transform.FindChild("ManaText").GetComponent<Text>();
            Text paText = _displayInformation.transform.FindChild("PaText").GetComponent<Text>();
            Text statInformationText = _displayInformation.transform.FindChild("StatInformationText").GetComponent<Text>();

            nameText.text = Personnage.Nom + Environment.NewLine + Personnage.Espece.Nom + " / " + Personnage.Metier.Nom;
            healthText.text = "Santé : " + Mathf.Round(Personnage.Pv.ValeurActu) + " / " + Mathf.Round(Personnage.Pv.Valeur);
            manaText.text = "Mana : " + Mathf.Round(Personnage.Mana.ValeurActu) + " / " + Mathf.Round(Personnage.Mana.Valeur);
            paText.text = "Pa : " + Mathf.Round(Personnage.Pa.ValeurActu) + " / " + Mathf.Round(Personnage.Pa.Valeur);

            statInformationText.text = "Force : " + Mathf.Round(Personnage.Force.Valeur) + Environment.NewLine;
            statInformationText.text += "Intelligence : " + Mathf.Round(Personnage.Intel.Valeur) + Environment.NewLine;
            statInformationText.text += "Agilité : " + Mathf.Round(Personnage.Agi.Valeur) + Environment.NewLine;
            statInformationText.text += "Charisme : " + Mathf.Round(Personnage.Cha.Valeur) + Environment.NewLine;
            statInformationText.text += "Cap de Combat : " + Mathf.Round(Personnage.Cc.Valeur) + Environment.NewLine;
            statInformationText.text += "Cap de Tir : " + Mathf.Round(Personnage.Ct.Valeur) + Environment.NewLine;
            statInformationText.text += "Vitesse : " + Mathf.Round(Personnage.Vit.Valeur) + Environment.NewLine;
            statInformationText.text += "Resist Physique : " + Mathf.Round(Personnage.ResiP.Valeur) + Environment.NewLine;
            statInformationText.text += "Resist Magique : " + Mathf.Round(Personnage.ResiM.Valeur);

            ProgressBar pbHealth = _displayInformation.transform.FindChild("HealthProgressBar").GetComponent<ProgressBar>();
            ProgressBar pbMana = _displayInformation.transform.FindChild("ManaProgressBar").GetComponent<ProgressBar>();
            ProgressBar pbPa = _displayInformation.transform.FindChild("PaProgressBar").GetComponent<ProgressBar>();

            pbHealth.SetValues(Personnage.Pv.Valeur, 0, Personnage.Pv.ValeurActu);
            pbMana.SetValues(Personnage.Mana.Valeur, 0, Personnage.Mana.ValeurActu);
            pbPa.SetValues(Personnage.Pa.Valeur, 0, Personnage.Pa.ValeurActu);
        }
        else
        {
            Debug.LogError("'CanevasMenu' can't be null");
        }
    }

    void OnMouseExit()
    {
        if (_displayInformation != null) Destroy(_displayInformation);
    }
}
