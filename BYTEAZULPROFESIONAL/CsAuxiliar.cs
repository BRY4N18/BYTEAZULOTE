using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    internal class CsAuxiliar
    {

        public CsAuxiliar() 
        { }

        public void AgregarBoton(DataGridView dgv, Image img, string tipo)
        {
            // Crear una columna de imagen
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = tipo;
            imgColumn.HeaderText = tipo;
            imgColumn.Image = img;
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; // Ajustar la imagen
            imgColumn.FillWeight = 50; // Ajustar tamaño del botón
            dgv.Columns.Add(imgColumn);
        }
    }
}
