/*

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    //Vairables
    public TextAsset textFile;
    public string[] lines;
    public Text actualText;
    public int currentLine;
    public int endLine;

    //Initialization
    void Start () {       
        //Get lines with newline as delimiter
		if(textFile != null) {
            lines = (textFile.text.Split('\n'));
        }

        //When no specified end line, read all lines
        if (endLine == 0) {
            endLine = lines.Length - 1;
        }
	}

    //Display text onto screen
    void Update() {
        actualText.text = lines[currentLine];
    }

}
