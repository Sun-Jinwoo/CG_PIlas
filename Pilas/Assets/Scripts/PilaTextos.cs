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
        // Inicializar la visualización
        ActualizarVisualizacion();
    }

    // Método para agregar un elemento a la pila desde un botón
    public void PushString()
    {
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            pilaNombres.Push(inputField.text);
            Debug.Log($"Elemento agregado: {inputField.text}. Pila actual: {string.Join(", ", pilaNombres)}");
            inputField.text = ""; // Limpiar el InputField después de agregar
            ActualizarVisualizacion();
        }
    }

    // Método para ver el elemento superior sin eliminarlo
    public void PeekString()
    {
        if (pilaNombres.Count > 0)
        {
            Debug.Log($"Elemento superior: {pilaNombres.Peek()}");
            ActualizarVisualizacion();
        }
        else
        {
            Debug.Log("La pila está vacía, no se puede usar Peek.");
            ActualizarVisualizacion();
        }
    }

    // Método para eliminar el elemento superior
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
            Debug.Log("No se puede desapilar, la pila está vacía.");
            ActualizarVisualizacion();
        }
    }

    // Método para vaciar la pila
    public void ClearString()
    {
        pilaNombres.Clear();
        Debug.Log("Pila vaciada.");
        ActualizarVisualizacion();
    }

    // Método para actualizar la visualización en la UI
    private void ActualizarVisualizacion()
    {
        if (pilaTextUI != null)
        {
            if (pilaNombres.Count > 0)
            {
                pilaTextUI.text = "Pila:\n" + string.Join("\n", pilaNombres); // Mostrar cada elemento en una nueva línea
            }
            else
            {
                pilaTextUI.text = "Pila vacía";
            }
        }
    }
}