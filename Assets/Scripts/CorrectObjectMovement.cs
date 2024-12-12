using UnityEngine;

public class CorrectObjectMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    private bool isMovingX = false;
    private bool isMovingZ = false;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calcular a mudança de posição
        Vector3 delta = transform.position - lastPosition;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.z))
        {
            // Movimento predominante no eixo X
            isMovingX = true;
            isMovingZ = false;
            // Corrigir posição no eixo Z
            transform.position = new Vector3(transform.position.x, transform.position.y, lastPosition.z);
        }
        else if (Mathf.Abs(delta.z) > Mathf.Abs(delta.x))
        {
            // Movimento predominante no eixo Z
            isMovingX = false;
            isMovingZ = true;
            // Corrigir posição no eixo X
            transform.position = new Vector3(lastPosition.x, transform.position.y, transform.position.z);
        }
        else
        {
            // Se não houver movimento predominante, corrigir para o último eixo movido
            if (isMovingX)
                transform.position = new Vector3(transform.position.x, transform.position.y, lastPosition.z);
            if (isMovingZ)
                transform.position = new Vector3(lastPosition.x, transform.position.y, transform.position.z);
        }

        // Atualizar a última posição
        lastPosition = transform.position;
    }
}
