using UnityEngine;
using TMPro;
public class Score_UI : MonoBehaviour
{
[SerializeField] private TextMeshProUGUI scoreUI;
[SerializeField] private GameObject startMenuUI;
[SerializeField] private GameObject gameoverUI;
GameManager gm;
private void Start(){
    gm = GameManager.Instance;
    gm.ongameover.AddListener(ActivateGameOverUI);
}
public void PlayButtonHandler(){
    gm.StartGame();
}
public void ActivateGameOverUI(){
    gameoverUI.SetActive(true);
}
private void OnGUI(){
    scoreUI.text = gm.prettyscore();

}
}
