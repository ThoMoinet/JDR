﻿using UnityEngine;
using System.Collections;

public class PlateauManager : MonoBehaviour
{

    //Variable à renseigner directement dans Unity
    public GameObject ModelCase;
    public int LigneCountJoueur = 0;
    public int ColonneCountJoueur = 0;
    public int LigneCountPnj = 0;
    public int ColonneCountPnj = 0;
    public float Espacement = 0;
    public Camera Cam;
    public float VitesseCamera = 0;
    public float VitesseZoom = 0;
    public float ZoomMin = 0;
    public float ZoomMax = 0;

    //Variable Camera

    private Transform _cameraTransform;
    private Vector3 _directionCamera;
    private Vector3 _positionCliqueCentrale;
    private Vector3 _anciennePositionCliqueCentrale;

    public GameObject[,] PlateauJoueur;
    public GameObject[,] PlateauPnj;

    /// <summary>
    /// Se lance avant Start et permet d'affecter le script à Global pour pouvoir être utilisé avec les valeurs données dans Unity
    /// </summary>
    void Awake()
    {
        Global.S_PlateauManager = this;

        if (Cam == null)
        {
            Debug.LogError("Cam ne peux pas être null");
            return;
        }
        _cameraTransform = Cam.GetComponent<Transform>();
    }

    // Use this for initialization
    void Start()
    {
        if (Cam == null) return;
        _directionCamera = new Vector3();

        _positionCliqueCentrale = new Vector3();
        _anciennePositionCliqueCentrale = new Vector3();

        PlateauJoueur = new GameObject[0, 0];
        PlateauPnj = new GameObject[0, 0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Cam == null) return;

        DeplacementCameraSourie();

        //_directionCamera = Vector3.zero;

        ////Gestion du déplacement de la camera avec la souris
        //if (Input.GetMouseButton(2))
        //{
        //    _positionCliqueCentrale = Input.mousePosition; //On récupére la position de la sourie

        //    if (_anciennePositionCliqueCentrale != null) //Si il y a une ancienne position
        //    {
        //        _directionCamera = _positionCliqueCentrale - _anciennePositionCliqueCentrale; //On calcule la direction du vecteur
        //        _directionCamera = _directionCamera.normalized * -1; // On la normalise en force de 1 pour ne garder que la direction, et on inverse le sens pour bouger la camera comme sur tablette
        //    }

        //    _anciennePositionCliqueCentrale = _positionCliqueCentrale; //On actualise l'ancienne position
        //}

        //Debug.Log("Sourie OK " + _directionCamera);

        //Déplacement de la camera
        _cameraTransform.position += VitesseCamera * _directionCamera * Time.deltaTime;

        //Gestion du zoom
        GestionZoom();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="PosStart">Emplacement de la première case du tableau</param>
    /// <param name="NbColonne">Nombre de colonne</param>
    /// <param name="NbLigne">Nombre de ligne</param>
    /// <param name="NumPlateau">Numéro du plateau, sert juste pour le Name des cases</param>
    public void GenerationTableau(int NbLigne, int NbColonne, ref GameObject[,] Plateau, bool PJoueur, string EmplacementBordure)
    {
        if (ModelCase == null)
        {
            Debug.Log("Erreur : Une case doit avoir un model");
            return;
        }

        Vector3 emplacementCase;
        Vector3 emplacementPremiereCase;
        Plateau = new GameObject[NbLigne, NbColonne];

        if (PJoueur == true)
        {
            emplacementPremiereCase = new Vector3(((Espacement * NbColonne) / 2) * -1, Espacement * -1);
        }
        else
        {
            emplacementPremiereCase = new Vector3(((Espacement * NbColonne) / 2) * -1, Espacement);
        }

        emplacementCase = new Vector3(emplacementPremiereCase.x, emplacementPremiereCase.y);
        for (int i = 0; i < NbLigne; i++)
        {
            for (int j = 0; j < NbColonne; j++)
            {
                //Création d'une case

                Plateau[i, j] = Instantiate(ModelCase, emplacementCase, Quaternion.identity) as GameObject;
                CasePlateau caseplateau = Plateau[i, j].GetComponent<CasePlateau>();

                caseplateau.SpriteBordure = EmplacementBordure;
                caseplateau.Affichage();

                if (PJoueur == true)
                {
                    Plateau[i, j].name = "Case (" + i + " : " + j + ") Joueur";
                }
                else
                {
                    Plateau[i, j].name = "Case (" + i + " : " + j + ") Pnj";
                }

                //Changement du future emplacement en X
                emplacementCase.x += Espacement;
            }

            //Changement du future emplacement en Y
            if (PJoueur == true)
            {
                emplacementCase.y -= Espacement;
            }
            else
            {
                emplacementCase.y += Espacement;
            }

            emplacementCase.x = emplacementPremiereCase.x;
        }
    }

    public void DeplacementCameraSourie()
    {
        _directionCamera = Vector3.zero;

        //Gestion du déplacement de la camera avec la souris
        if (Input.GetMouseButton(2))
        {
            _positionCliqueCentrale = Input.mousePosition; //On récupére la position de la sourie

            _directionCamera = _positionCliqueCentrale - _anciennePositionCliqueCentrale; //On calcule la direction du vecteur
            _directionCamera = _directionCamera.normalized * -1; // On la normalise en force de 1 pour ne garder que la direction, et on inverse le sens pour bouger la camera comme sur tablette

            _anciennePositionCliqueCentrale = _positionCliqueCentrale; //On actualise l'ancienne position
        }
    }

    public void GestionZoom()
    {
        float axisScroll = Input.GetAxis("Mouse ScrollWheel");

        if (axisScroll > 0) //On scroll vers le haut
        {
            if (Cam.orthographicSize > ZoomMin)
            {
                //_camera.orthographicSize -= axisScroll * Time.deltaTime;
                Cam.orthographicSize -= Mathf.Abs(axisScroll) * VitesseZoom;

            }
        }
        else if (axisScroll < 0) //On scroll vers le bas
        {
            if (Cam.orthographicSize < ZoomMax)
            {
                //_camera.orthographicSize += axisScroll * Time.deltaTime;
                Cam.orthographicSize += Mathf.Abs(axisScroll) * VitesseZoom;
            }
        }
    }
}
