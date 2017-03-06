using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Handles just the inital story
*/
public class InitialStory : MonoBehaviour {

    public GameObject doc;
    public float speed;
    public Transform movePosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Dialouge here
        print("Dialouge Here");

        //Move Dr.Evian out the door 
        moveDoc();
        //Play sounds
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Collider2D>().enabled = false;
    }

    void moveDoc()
    {
        //doc.transform.position = Vector3.MoveTowards(doc.transform.position, movePosition.position, Time.deltaTime * speed);

        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSpeed()
    {
        while (doc.transform.position != movePosition.position)
        {
            doc.transform.position = Vector3.MoveTowards(doc.transform.position, movePosition.position, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveOverSeconds()
    {
        float elapsedTime = 0;
        Vector3 startingPos = doc.transform.position;
        while (elapsedTime < speed)
        {
            doc.transform.position = Vector3.Lerp(startingPos, movePosition.position, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        doc.transform.position = movePosition.position;
    }
}
