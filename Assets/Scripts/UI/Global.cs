using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public static PlateauManager S_PlateauManager;
    public static Character S_Joueur, S_Joueur2;
    public static GameObject S_DisplayInformation;
    public static GameObject S_MenuCanvas;

    public static GameObject S_SheetCharacter;
    public static string S_SheetCharacterName;

    public static bool S_SheetCharacterOpen;

    private Race _race, _race2;
    private Classe _classe, _classe2;

    

    void Awake()
    {
        S_DisplayInformation = Resources.Load<GameObject>("Prefab/DisplayInformation");
        S_MenuCanvas = GameObject.Find("MenuCanvas");
        S_SheetCharacter = Resources.Load<GameObject>("Prefab/SheetCharacterPanel");

        //Debug.Log(CanevasMenu.name);
    }


	// Use this for initialization
	void Start () {
        S_SheetCharacterName = "SheetCharacterPanel";
        S_SheetCharacterOpen = false;


        //Génération plateau pour visuel (test)
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountJoueur, S_PlateauManager.ColonneCountJoueur, ref S_PlateauManager.PlateauJoueur, true, "Sprite/Case/frame-0-blue");
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountPnj, S_PlateauManager.ColonneCountPnj, ref S_PlateauManager.PlateauPnj, false, "Sprite/Case/frame-0-red");


        //Test
        _race = new Race("Humain", new Aleatoire(15, 25), new Aleatoire(10, 15), new Aleatoire(12, 18), new Aleatoire(5, 12), new Aleatoire(16, 22), new Aleatoire(5, 10), new Aleatoire(1, 1),
            new Aleatoire(10, 14), new Aleatoire(5, 10), new Aleatoire(3, 8), new Aleatoire(90, 120), new Aleatoire(100, 100));

        _race2 = new Race("Elfe", new Aleatoire(10, 18), new Aleatoire(18, 25), new Aleatoire(15, 22), new Aleatoire(5, 12), new Aleatoire(18, 25), new Aleatoire(10, 15), new Aleatoire(1, 1),
            new Aleatoire(12, 18), new Aleatoire(2, 6), new Aleatoire(4, 9), new Aleatoire(70, 90), new Aleatoire(120, 150));

        _classe = new Classe("Paladin", 5, 0, 0, -2, 2, -2, 0, -5, 2, 0, 15, 0);
        _classe2 = new Classe("Mage", 0, 5, 0, -2, -2, -2, 0, 0, 0, 10, 0, 50);

        S_Joueur = new Character("Thao", Character.EGenre.Homme, 27, _race, _classe, "Sprite/Icone/Soldat");
        S_Joueur.Pv.ValeurActu -= 50;
        S_Joueur.Xp.Valeur = 100;
        S_Joueur.Xp.ValeurActu = 37;

        S_Joueur2 = new Character("Nariya", Character.EGenre.Femme, 27, _race2, _classe2, "Sprite/Icone/Mage");
        S_Joueur2.Mana.ValeurActu -= 75;
        S_Joueur2.Pa.ValeurActu = 0;
        S_Joueur2.Xp.Valeur = 100;

        CasePlateau _case = S_PlateauManager.PlateauJoueur[0,2].GetComponent<CasePlateau>();
        _case.Personnage = S_Joueur;
        _case.Affichage();

        _case = S_PlateauManager.PlateauJoueur[1, 2].GetComponent<CasePlateau>();
        _case.Personnage = S_Joueur2;
        _case.Affichage();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    /// <summary>
    /// Affiche la fiche du personnage du joueur.
    /// </summary>
    public void OpenSheetCharacter()
    {
        if (S_SheetCharacter != null)
        {
            if (!S_SheetCharacterOpen)
            {
                S_SheetCharacterOpen = true;

                GameObject sheet = Instantiate(S_SheetCharacter, Vector3.zero, Quaternion.identity) as GameObject;
                sheet.transform.SetParent(S_MenuCanvas.transform);
                sheet.name = S_SheetCharacterName;

                float sizeX = sheet.transform.GetComponent<RectTransform>().rect.size.x;
                float sizeY = sheet.transform.GetComponent<RectTransform>().rect.size.y;

                sheet.transform.position = new Vector3(S_MenuCanvas.transform.GetComponent<RectTransform>().rect.size.x / 2, S_MenuCanvas.transform.GetComponent<RectTransform>().rect.size.y / 2);
            }
        }
        else
        {
            Debug.LogError("SheetCharacterModel can't be null");
        }       
    }  
}