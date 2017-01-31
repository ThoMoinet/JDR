using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public static PlateauManager S_PlateauManager;
    public static Character S_Joueur, S_Joueur2;
    public static GameObject S_DisplayInformation;
    public static GameObject S_MenuCanvas;

    public static GameObject S_SheetCharacter;
    public static string S_SheetCharacterName;

    //Variable de controle d'ouverture des fenetres
    public static bool S_SheetCharacterOpen;

    //Test
    private Race _race, _race2;
    private Job _classe, _classe2;

    //private int index = 0;
    //private float result = 100;


    void Awake()
    {
        S_DisplayInformation = Resources.Load<GameObject>("Prefab/DisplayInformation");
        S_MenuCanvas = GameObject.Find("MenuCanvas");
        S_SheetCharacter = Resources.Load<GameObject>("Prefab/SheetCharacterPanel");
    }

	// Use this for initialization
	void Start () {
        S_SheetCharacterName = "SheetCharacterPanel";
        S_SheetCharacterOpen = false;


        //Génération plateau pour visuel (test)
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountJoueur, S_PlateauManager.ColonneCountJoueur, ref S_PlateauManager.PlateauJoueur, true, "Sprite/Case/frame-0-blue");
        S_PlateauManager.GenerationTableau(S_PlateauManager.LigneCountPnj, S_PlateauManager.ColonneCountPnj, ref S_PlateauManager.PlateauPnj, false, "Sprite/Case/frame-0-red");

        RandomBuilder rb = new RandomBuilder();

        rb.SetAgi = new Rand(10,15);
        rb.SetCc = new Rand(15,20);
        rb.SetCha = new Rand(10,12);
        rb.SetCt = new Rand(10,15);
        rb.SetStr = new Rand(15,20);
        rb.SetInt = new Rand(12,18);
        rb.SetMana = new Rand(50,75);
        rb.SetPa = new Rand(1,1);
        rb.SetHp = new Rand(80,120);
        rb.SetResiM = new Rand(0,5);
        rb.SetResiP = new Rand(2,8);
        rb.SetSpd = new Rand(10,12);

        RandomBuilder rb2 = new RandomBuilder();

        rb2.SetAgi = new Rand(10, 15);
        rb2.SetCc = new Rand(15, 20);
        rb2.SetCha = new Rand(10, 12);
        rb2.SetCt = new Rand(10, 15);
        rb2.SetStr = new Rand(15, 20);
        rb2.SetInt = new Rand(12, 18);
        rb2.SetMana = new Rand(50, 75);
        rb2.SetPa = new Rand(1, 1);
        rb2.SetHp = new Rand(80, 120);
        rb2.SetResiM = new Rand(0, 5);
        rb2.SetResiP = new Rand(2, 8);
        rb2.SetSpd = new Rand(10, 12);


        //Test
        _race = new Race("Humain", rb);
        _race2 = new Race("Bébé", rb2);

        IntBuilder jb = new IntBuilder();
        jb.SetAgi = 3;
        jb.SetCc = 1;
        jb.SetCha = 4;
        jb.SetCt = 10;
        jb.SetStr = 1;
        jb.SetInt = 2;
        jb.SetMana = -10;
        jb.SetPa = 10;
        jb.SetHp = -20;
        jb.SetResiM = 5;
        jb.SetResiP = 2;
        jb.SetSpd = 5;

        IntBuilder jb2 = new IntBuilder();
        jb2.SetAgi = 3;
        jb2.SetCc = 1;
        jb2.SetCha = 4;
        jb2.SetCt = 10;
        jb2.SetStr = 1;
        jb2.SetInt = 2;
        jb2.SetMana = -10;
        jb2.SetPa = 10;
        jb2.SetHp = -20;
        jb2.SetResiM = 5;
        jb2.SetResiP = 2;
        jb2.SetSpd = 5;

        _classe = new Job("Paladin", jb);
        _classe2 = new Job("Dragon", jb2);

        S_Joueur = new Character("Thao", Character.EGenre.Homme, 27, _race, _classe, "Sprite/Icone/Soldat");

        S_Joueur2 = new Npc("Nariya", Character.EGenre.Femme, 27, _race2, _classe2, "Sprite/Icone/Mage", 50);

        CasePlateau _case = S_PlateauManager.PlateauJoueur[0,2].GetComponent<CasePlateau>();
        _case.Personnage = S_Joueur;
        _case.Affichage();

        _case = S_PlateauManager.PlateauPnj[0, 4].GetComponent<CasePlateau>();
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

                //float sizeX = sheet.transform.GetComponent<RectTransform>().rect.size.x;
                //float sizeY = sheet.transform.GetComponent<RectTransform>().rect.size.y;

                sheet.transform.position = new Vector3(S_MenuCanvas.transform.GetComponent<RectTransform>().rect.size.x / 2, S_MenuCanvas.transform.GetComponent<RectTransform>().rect.size.y / 2);
            }
        }
        else
        {
            Debug.LogError("SheetCharacterModel can't be null");
        }       
    }  
}