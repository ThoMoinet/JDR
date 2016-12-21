using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public static PlateauManager S_PlateauManager;
    public static PersonnageScript S_Joueur;
    public static GameObject S_DisplayInformation;
    public static GameObject S_MenuCanvas;

    private Race _race;
    private Classe _classe;

    void Awake()
    {
        S_DisplayInformation = Resources.Load<GameObject>("Prefab/DisplayInformation");
        S_MenuCanvas = GameObject.Find("MenuCanvas");

        //Debug.Log(CanevasMenu.name);
    }


	// Use this for initialization
	void Start () {
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountJoueur, S_PlateauManager.ColonneCountJoueur, ref S_PlateauManager.PlateauJoueur, true, "Sprite/Case/frame-0-blue");
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountPnj, S_PlateauManager.ColonneCountPnj, ref S_PlateauManager.PlateauPnj, false, "Sprite/Case/frame-0-red");

        _race = new Race("Humain", new Aleatoire(15, 25), new Aleatoire(10, 15), new Aleatoire(12, 18), new Aleatoire(5, 12), new Aleatoire(16, 22), new Aleatoire(5, 10), new Aleatoire(1, 1),
            new Aleatoire(10, 14), new Aleatoire(5, 10), new Aleatoire(3, 8), new Aleatoire(90, 120), new Aleatoire(10, 10));

        _classe = new Classe("Paladin", 5, 0, 0, -2, 2, -2, 0, -5, 2, 0, 15, 0);

        S_Joueur = new PersonnageScript("Thao", PersonnageScript.EGenre.Homme, 27, _race, _classe, "Sprite/Icone/PackFantasy/axe");

        CasePlateau _case = S_PlateauManager.PlateauJoueur[0,0].GetComponent<CasePlateau>();
        _case.Personnage = S_Joueur;
        _case.Affichage();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    
}