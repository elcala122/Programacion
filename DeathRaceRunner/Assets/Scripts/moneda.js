#pragma strict

var score = 0;

function OnTriggerEnter( other : Collider ) {
    Debug.Log("OnTriggerEnter() was called");
    if (other.tag == "moneda") 
    {
        Debug.Log("Other object is a coin");
        score += 1;
        Debug.Log("Score is now " + score);
        Destroy(other.gameObject);
    }
}

function OnGUI() 
{
	GUILayout.Label( "Monedas = " + score );

}