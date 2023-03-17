using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private Renderer cubeRenderer;
    private Color newCubeColor;

    //Vector3 screenBounds;
    float objectWidth = 12;
    float randomR, randomG, randomB, randomA;
    void Start()
    {
        Debug.Log("ModeTheCube");
        InvokeRepeating("SpawnTheCubeRandomly", 0.5f, 0.5f);
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        cubeRenderer = cube.GetComponent<Renderer>();
    }

    void Update()
    {
        float randomRotate = Random.Range(5, 255) * Time.deltaTime;
        transform.Rotate(randomRotate, randomRotate, randomRotate);
        ClampToTheScreen();
        
    }
    Vector3 ClampToTheScreen()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -objectWidth, objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, 4, 13);
        //transform.position = viewPos;
        return viewPos;
    }
    void SpawnTheCubeRandomly()
    {
        Vector3 randomPos = new Vector3(Random.Range(-objectWidth, objectWidth), Random.Range(4, 13), 0);
        transform.position = randomPos;

        randomR = Random.Range(0f, 1f);
        randomG = Random.Range(0f, 1f);
        randomB = Random.Range(0f, 1f);
        newCubeColor = new Color(randomR, randomG, randomB, 1f);
        cubeRenderer.material.SetColor("_Color", newCubeColor);

        float randomScale = Random.Range(0.5f, 2.5f);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
 
    }
}
