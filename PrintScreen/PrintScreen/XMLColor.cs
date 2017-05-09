using System;
using System.Drawing;
using System.Xml.Serialization;

namespace FlexScreen
{
    public enum ColorFormat
    {
        NamedColor,
        ARGBColor
    }

    public class XMLColor
    {
        public XMLColor()
        {
        }

        Color m_defaultColor = Color.Transparent;
        
        public event EventHandler ColorChanged;

        public XMLColor(Color defaultColor)
        {
            m_defaultColor = defaultColor;
        }

        public XMLColor(Color defaultColor, EventHandler colorChanged) :this (defaultColor)
        {
            ColorChanged = colorChanged;   
        }

        public string XmlColor { get; set; }

        [XmlIgnore]
        public Color Color
        {
            get
            {
                return DeserializeColor(XmlColor);
            }
            set
            {
                if (Color != value)
                {
                    XmlColor = SerializeColor(value);
                    if (ColorChanged != null)
                    {
                        ColorChanged(this, null);
                    }
                }
            }
        }

        private string SerializeColor(Color color)
        {
            if (color.IsNamedColor)
                return string.Format("{0}:{1}",
                    ColorFormat.NamedColor, color.Name);
            else
                return string.Format("{0}:{1}:{2}:{3}:{4}",
                    ColorFormat.ARGBColor,
                    color.A, color.R, color.G, color.B);
        }

        private Color DeserializeColor(string color)
        {
            byte a, r, g, b;

            if (!string.IsNullOrEmpty(color))
            {
                var pieces = color.Split(new char[] { ':' });

                var colorType = (ColorFormat)
                    Enum.Parse(typeof(ColorFormat), pieces[0], true);

                switch (colorType)
                {
                    case ColorFormat.NamedColor:
                        return Color.FromName(pieces[1]);

                    case ColorFormat.ARGBColor:
                        a = byte.Parse(pieces[1]);
                        r = byte.Parse(pieces[2]);
                        g = byte.Parse(pieces[3]);
                        b = byte.Parse(pieces[4]);

                        return Color.FromArgb(a, r, g, b);
                }
            }
            return m_defaultColor;
        }
    }
}
