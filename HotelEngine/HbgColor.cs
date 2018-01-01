using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEngine
{
    public class HbgColor
    {
        public int Id { get; set; }
        [NotMapped]
        public Color CustomColor { get; set; }
        public string Code
        {
            get { return ColorTranslator.ToHtml(CustomColor); }
            set { CustomColor = ColorTranslator.FromHtml(value); }
        }

    }
}
