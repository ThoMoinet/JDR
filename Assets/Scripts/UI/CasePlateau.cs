﻿using UnityEngine;
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
    public Vector3 CorecLocationDisplay;

    private GameObject _displayInformation;
    private SpriteRenderer _spriteBordure;
    private SpriteRenderer _spritPerso;

    void Awake()
    {
        Vector3 scale = new Vector3(ScalBordureX, ScalBordureY, 0);
        transform.localScale = scale;

        _spriteBordure = transform.GetComponent<SpriteRenderer>();
        _spritPerso = transform.Find("ImagePerso").GetComponent<SpriteRenderer>();

        _spritPerso.transform.localScale = new Vector3(4.5F, 4.5F);
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

        Vector3 screenPosition = Global.S_PlateauManager.Cam.WorldToScreenPoint(transform.position + CorecLocationDisplay);

        float sizeX, sizeY;

        //Paramétrage du displayInformation
        _displayInformation = Instantiate(Global.S_DisplayInformation, Vector3.zero, Quaternion.identity) as GameObject;
        _displayInformation.transform.SetParent(Global.S_MenuCanvas.transform);
        sizeX = _displayInformation.transform.GetComponent<RectTransform>().rect.size.x;
        sizeY = _displayInformation.transform.GetComponent<RectTransform>().rect.size.y;
        _displayInformation.transform.position = new Vector3(screenPosition.x + (sizeX / 2), screenPosition.y - (sizeY / 2));

        //Affichage de ce dernier
        _displayInformation.GetComponent<DisplayInformation>().Affichage(Personnage);
    }

    void OnMouseExit()
    {
        if (_displayInformation != null) Destroy(_displayInformation);
    }
}
