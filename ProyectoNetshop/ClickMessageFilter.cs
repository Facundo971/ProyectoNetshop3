using System;
using System.Windows.Forms;

namespace ProyectoNetshop
{
    // Filtro de mensajes para detectar clics globales en la aplicación
    internal class ClickMessageFilter : IMessageFilter
    {
        // Evento que se dispara cuando se detecta un clic fuera de un control específico
        public event Action<Control> ClickFueraDetectado;

        // Método que intercepta mensajes del sistema antes de que lleguen a los controles
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_LBUTTONDOWN = 0x0201; // Código de mensaje para clic izquierdo del mouse

            // Si el mensaje es un clic izquierdo
            if (m.Msg == WM_LBUTTONDOWN)
            {
                // Obtiene el control que fue clickeado
                Control clickeado = Control.FromHandle(m.HWnd);

                // Dispara el evento pasando el control clickeado
                ClickFueraDetectado?.Invoke(clickeado);
            }

            return false;
        }
    }
}
