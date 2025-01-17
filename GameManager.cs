using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    #region singleton

    public static GameManager Instance;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
    #endregion

    public float currenctscore = 0f;
    public bool isplaying = false;
    public UnityEvent onplay = new UnityEvent();
    public UnityEvent ongameover = new UnityEvent();
    private void Update(){
        if(isplaying){
            currenctscore += Time.deltaTime;
        }
    }
    public void StartGame(){
        onplay.Invoke();
        isplaying = true;
    }
    public void GameOver(){
        ongameover.Invoke();
        currenctscore = 0 ;
        isplaying = false;
    }
    public string prettyscore (){
        return Mathf.RoundToInt(currenctscore).ToString();
    }
    
}
