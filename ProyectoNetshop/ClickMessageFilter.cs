using System;
using System.Windows.Forms;

namespace ProyectoNetshop
{
    internal class ClickMessageFilter : IMessageFilter
    {
        public event Action<Control> ClickFueraDetectado;

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_LBUTTONDOWN = 0x0201;

            if (m.Msg == WM_LBUTTONDOWN)
            {
                Control clickeado = Control.FromHandle(m.HWnd);
                ClickFueraDetectado?.Invoke(clickeado);
            }

            return false;
        }
    }
}
