using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mesafe : MonoBehaviour
{
    [SerializeField] private GameObject karakter;
    [SerializeField] private GameObject hedefMektup;
    [SerializeField] private GameObject hedefPuzzle;
    [SerializeField] private GameObject hedefPC;
    [SerializeField] private GameObject hedefKapi;
    [SerializeField] private GameObject hedefKedi;
    [SerializeField] private TextMeshProUGUI hedefNesneMektupText;
    [SerializeField] private TextMeshProUGUI hedefPuzzleText;
    [SerializeField] private TextMeshProUGUI hedefPCText;
    [SerializeField] private TextMeshProUGUI hedefkapiText;
    [SerializeField] private TextMeshProUGUI hedefkediText;
    [SerializeField] private GorevManager _gorevManager;
    [SerializeField] private TextMeshProUGUI _gorevText;
    [SerializeField] private Image _gorevImage;
    [SerializeField] private Sprite mektupImage, puzzleImage, pcImage, lastImage, giftImage;
    [SerializeField] private GameObject player;
    public ParcalarToplandi parcalarToplandi;

    private void Start()
    {
        switch (_gorevManager.StringLevelName)
        {
            case ("Puzzle"):

                break;
            case ("Puzzle2"):



                break;
            case ("PC"):

                player.transform.position = new Vector3(-5.9267354f, 0.335999429f, -5.17039156f);
                break;
            case ("Last"):

                player.transform.position = new Vector3(0.646609724f, 0.075999856f, -1.86716795f);
                break;
            case ("Cat"):

                break;
            default:

                player.transform.position = new Vector3(-2.4230001f, 3.07999992f, 3.98300004f);


                break;
        }
    }
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
            case ("Last"):
                float distance3 = Vector3.Distance(karakter.transform.position, hedefKapi.transform.position);
                hedefkapiText.text = distance3.ToString("F2") + "m";
                _gorevText.text = "Exit through the main door.";
                _gorevImage.sprite = lastImage;

                break;
            case ("Cat"):
                float distance4 = Vector3.Distance(karakter.transform.position, hedefKedi.transform.position);
                hedefkediText.text = distance4.ToString("F2") + "m";
                _gorevText.text = "Get Your Gift!";
                _gorevImage.sprite = giftImage;
                break;
            default:
                float distance10 = Vector3.Distance(karakter.transform.position, hedefMektup.transform.position);
                hedefNesneMektupText.text = distance10.ToString("F2") + "m";
                _gorevText.text = "Read the Letter";
                _gorevImage.sprite = mektupImage;
                //  player.transform.position = new Vector3(-2.4230001f, 3.07999992f, 3.98300004f);


                break;
        }




    }
}
