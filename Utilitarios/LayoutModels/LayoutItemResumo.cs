using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.LayoutModels
{
    public class LayoutItemResumo
    {

        public string Title { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        public string NameLabel { get { return "lbl" + this.Title.Replace(" ",""); } }

    }
}
