using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string sceneName = "Entrez le Nom de la Scene à charger";

    /// <summary>
    /// Chargement d'une scéne avec le Name à noter dans Unity.
    /// </summary>
    public void Use ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
