using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines; 
    [SerializeField] float textSpeed; 
    private int index; 
    public Button end;
    
    public string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        textComponent.text = string.Empty; 
        StartDialogue(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if (textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines(); 
                textComponent.text = lines[index]; 
            }
        }
    }

    void StartDialogue(){
        index = 0; 
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text+=c; 
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (index < lines.Length -1){
            index++; 
            textComponent.text = string.Empty; 
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
            if (sceneName == "begin_dialogue"){
            SceneManager.LoadScene(3); 
            }
            if (sceneName == "ending_cutscene"){
                end.gameObject.SetActive(true);
            }
        }
    }
}
