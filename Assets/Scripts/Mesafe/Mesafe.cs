using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mesafe : MonoBehaviour
{
    [SerializeField] private GameObject karakter;
    [SerializeField] private GameObject hedefMektup;
    [SerializeField] private GameObject hedefPuzzle;
    [SerializeField] private GameObject hedefPC;
    [SerializeField] private TextMeshProUGUI hedefNesneMektupText;
    [SerializeField] private TextMeshProUGUI hedefPuzzleText;
    [SerializeField] private TextMeshProUGUI hedefPCText;
    [SerializeField] private GorevManager _gorevManager;
    [SerializeField] private TextMeshProUGUI _gorevText;
    [SerializeField] private Image _gorevImage;
    [SerializeField] private Sprite mektupImage, puzzleImage, pcImage;

    void Update()
    {
        Mesafe_();
    }
    private void Mesafe_()
    {
        switch (_gorevManager.StringLevelName)
        {
            case ("Puzzle"):
                _gorevText.text = "Find 4 puzzle pieces";
                _gorevImage.sprite = puzzleImage;
                break;
            case ("Puzzle2"):
                float distance = Vector3.Distance(karakter.transform.position, hedefPuzzle.transform.position);
                hedefPuzzleText.text = distance.ToString("F2") + "m";
                _gorevText.text = "Go to the bedroom, complete the puzzle";
                _gorevImage.sprite = puzzleImage;
                break;
            case ("PC"):
                float distance2 = Vector3.Distance(karakter.transform.position, hedefPC.transform.position);
                hedefPCText.text = distance2.ToString("F2") + "m";
                _gorevText.text = "Use the computer";
                _gorevImage.sprite = pcImage;
                break;
            default:
                float distance10 = Vector3.Distance(karakter.transform.position, hedefMektup.transform.position);
                hedefNesneMektupText.text = distance10.ToString("F2") + "m";
                _gorevText.text = "Read the Letter";
                _gorevImage.sprite = mektupImage;
                break;
        }




    }
}
