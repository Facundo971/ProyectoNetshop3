using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop
{
    internal class ComboItem
    {
        // Clase auxiliar para representar ítems en un ComboBox
        // Cada ítem tiene un texto visible y un valor asociado
        public string Text { get; set; } // Texto que se muestra en el ComboBox
        public int Value { get; set; } // Valor interno que representa el ítem

        // Al convertir el objeto a string, se muestra solo el texto
        public override string ToString()
        {
            return Text;
        }
    }
}
