using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string sceneName = "Entrez le nom de la Scene à charger";

    /// <summary>
    /// Chargement d'une scéne avec le nom à noter dans Unity. Coucou
    /// </summary>
    public void Use ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
