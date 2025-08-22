using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PilaTextos : MonoBehaviour
{
    private Stack<string> pilaNombres = new Stack<string>();
    [SerializeField] private Text pilaTextUI; // Referencia al Text que muestra la pila
    [SerializeField] private InputField inputField; // Referencia al InputField para ingresar nombres

    void Start()
    {
        // Inicializar la visualizaci�n
        ActualizarVisualizacion();
    }

    // M�todo para agregar un elemento a la pila desde un bot�n
    public void PushString()
    {
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            pilaNombres.Push(inputField.text);
            Debug.Log($"Elemento agregado: {inputField.text}. Pila actual: {string.Join(", ", pilaNombres)}");
            inputField.text = ""; // Limpiar el InputField despu�s de agregar
            ActualizarVisualizacion();
        }
    }

    // M�todo para ver el elemento superior sin eliminarlo
    public void PeekString()
    {
        if (pilaNombres.Count > 0)
        {
            Debug.Log($"Elemento superior: {pilaNombres.Peek()}");
            ActualizarVisualizacion();
        }
        else
        {
            Debug.Log("La pila est� vac�a, no se puede usar Peek.");
            ActualizarVisualizacion();
        }
    }

    // M�todo para eliminar el elemento superior
    public void PopString()
    {
        if (pilaNombres.Count > 0)
        {
            string elemento = pilaNombres.Pop();
            Debug.Log($"Elemento eliminado: {elemento}. Pila actual: {string.Join(", ", pilaNombres)}");
            ActualizarVisualizacion();
        }
        else
        {
            Debug.Log("No se puede desapilar, la pila est� vac�a.");
            ActualizarVisualizacion();
        }
    }

    // M�todo para vaciar la pila
    public void ClearString()
    {
        pilaNombres.Clear();
        Debug.Log("Pila vaciada.");
        ActualizarVisualizacion();
    }

    // M�todo para actualizar la visualizaci�n en la UI
    private void ActualizarVisualizacion()
    {
        if (pilaTextUI != null)
        {
            if (pilaNombres.Count > 0)
            {
                pilaTextUI.text = "Pila:\n" + string.Join("\n", pilaNombres); // Mostrar cada elemento en una nueva l�nea
            }
            else
            {
                pilaTextUI.text = "Pila vac�a";
            }
        }
    }
}