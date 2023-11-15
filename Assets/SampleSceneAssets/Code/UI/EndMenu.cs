using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TMP_Text titleMeshPro;
    [SerializeField] TMP_Text scoreMeshPro;

    private void Start()
    {
        titleMeshPro.text = GameManager.instance.musicSelect.title;
        scoreMeshPro.text = "final score : " + GameManager.instance.averageScore.ToString("D3");
    }

    public void ReturnSelectionMenu()
    {
        SceneManager.LoadScene("SelectionMusic");
    }
}
