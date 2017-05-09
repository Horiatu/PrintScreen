using System;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.ComponentModel;
using FlexScreen.Properties;

namespace FlexScreen
{
    public class ApplicationSettings
    {
        private bool m_appSettingsChanged;

        // Properties used to access the application settings variables.
        private string m_defaultDirectory;
        public string DefaultDirectory
        {
            get { return m_defaultDirectory; }
            set
            {
                if (value == m_defaultDirectory) return;
                m_defaultDirectory = value;
                m_appSettingsChanged = true;
            }
        }

        string m_imagesDirectory;
        public string ImagesDirectory
        {
            get { return m_imagesDirectory; }
            set
            {
                if (value == m_imagesDirectory) return;
                m_imagesDirectory = value;
                m_appSettingsChanged = true;
            }
        }

        string m_autoSaveProjectFile;
        public string AutoSaveProjectFile
        {
            get { return m_autoSaveProjectFile; }
            set
            {
                if (value == m_autoSaveProjectFile) return;
                m_autoSaveProjectFile = value;
                m_appSettingsChanged = true;
            }
        }

        Point m_optionFormLocation;
        public Point OptionFormLocation
        {
            get { return m_optionFormLocation; }
            set
            {
                if (value == m_optionFormLocation) return;
                m_optionFormLocation = value;
                m_appSettingsChanged = true;
            }
        }

        Rectangle m_splashScreenBounds;
        public Rectangle SplashScreenBounds
        {
            get { return m_splashScreenBounds; }
            set
            {
                if (value == m_splashScreenBounds) return;
                m_splashScreenBounds = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_suppressStartUpHelp;
        public bool SuppressStartUpHelp
        {
            get { return m_suppressStartUpHelp; }
            set
            {
                if (value == m_suppressStartUpHelp) return;
                m_suppressStartUpHelp = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_afterCaptureStayOnTop;
        public bool AfterCaptureStayOnTop
        {
            get { return m_afterCaptureStayOnTop; }
            set
            {
                if (value == m_afterCaptureStayOnTop) return;
                m_afterCaptureStayOnTop = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_transparentWhenNotFocussed;
        public bool TransparentWhenNotFocussed
        {
            get { return m_transparentWhenNotFocussed; }
            set
            {
                if (value == m_transparentWhenNotFocussed) return;
                m_transparentWhenNotFocussed = value;
                m_appSettingsChanged = true;
            }
        }

        int m_formTransparencyFactor;
        public int FormTransparencyFactor
        {
            get { return m_formTransparencyFactor; }
            set
            {
                if (value == m_formTransparencyFactor) return;
                m_formTransparencyFactor = value;
                m_appSettingsChanged = true;
            }
        }

        int m_shapeFillTransparencyFactor;
        public int ShapeFillTransparencyFactor
        {
            get { return m_shapeFillTransparencyFactor; }
            set
            {
                if (value == m_shapeFillTransparencyFactor) return;
                m_shapeFillTransparencyFactor = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_pasteImagesWithBorder;
        public bool PasteImagesWithBorder
        {
            get { return m_pasteImagesWithBorder; }
            set
            {
                if (value == m_pasteImagesWithBorder) return;
                m_pasteImagesWithBorder = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_textWithBorder;
        public bool TextWithBorder
        {
            get { return m_textWithBorder; }
            set
            {
                if (value == m_textWithBorder) return;
                m_textWithBorder = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_startImageEditorOnSave;
        public bool StartImageEditorOnSave
        {
            get { return m_startImageEditorOnSave; }
            set
            {
                if (value == m_startImageEditorOnSave) return;
                m_startImageEditorOnSave = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_autoHideMenu;
        public bool AutoHideMenu
        {
            get { return m_autoHideMenu; }
            set
            {
                if (value == m_autoHideMenu) return;
                m_autoHideMenu = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_captureFromTryIcon;
        public bool CaptureFromTryIcon
        {
            get { return m_captureFromTryIcon; }
            set
            {
                if (m_captureFromTryIcon == value) return;
                m_captureFromTryIcon = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_automaticallyCrop;
        public bool AutomaticallyCrop
        {
            get { return m_automaticallyCrop; }
            set
            {
                if (m_automaticallyCrop == value) return;
                m_automaticallyCrop = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_noToolTips;
        public bool NoToolTips
        {
            get { return m_noToolTips; }
            set
            {
                if (m_noToolTips == value) return;
                m_noToolTips = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_applyToAll;
        public bool ApplyToAll
        {
            get { return m_applyToAll; }
            set
            {
                if (m_applyToAll != value)
                {
                    m_applyToAll = value;
                    m_appSettingsChanged = true;
                }
            }
        }

        int m_lineWidth;
        public int LineWidth
        {
            get { return m_lineWidth; }
            set
            {
                if (m_lineWidth == value) return;
                m_lineWidth = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_autoSave;
        public bool AutoSave
        {
            get { return m_autoSave; }
            set
            {
                if (m_autoSave == value) return;
                m_autoSave = value;
                m_appSettingsChanged = true;
            }
        }

        bool m_autoSaveAsk;
        public bool AutoSaveAsk
        {
            get { return m_autoSaveAsk; }
            set
            {
                if (m_autoSaveAsk == value) return;
                m_autoSaveAsk = value;
                m_appSettingsChanged = true;
            }
        }

        private decimal m_fillTransparency;
        public decimal FillTransparency
        {
            get { return m_fillTransparency; }
            set
            {
                if (m_fillTransparency == value) return;
                m_fillTransparency = value;
                m_appSettingsChanged = true;
            }
        }

        //private decimal m_cursorOpacity;
        //public decimal CursorOpacity
        //{
        //    get { return m_cursorOpacity; }
        //    set
        //    {
        //        if (value == m_cursorOpacity) return;
        //        m_cursorOpacity = value;
        //        appSettingsChanged = true;
        //    }
        //}

        private decimal m_selectionOpacity;
        public decimal SelectionOpacity
        {
            get { return m_selectionOpacity; }
            set
            {
                if (value == m_selectionOpacity) return;
                m_selectionOpacity = value;
                m_appSettingsChanged = true;
            }
        }


        #region CursorColor
        Color m_cursorColor;

        [XmlIgnore]
        public Color CursorColor
        {
            get { return m_cursorColor; }
            set
            {
                if (m_cursorColor == value) return;
                m_cursorColor = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("CursorColor")]
        public string CursorColorXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(CursorColor); }
            set { CursorColor = (Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFrom(value) ?? "Black"); }
        }
        #endregion

        #region FillColor
        Color m_fillColor;

        [XmlIgnore]
        public Color FillColor
        {
            get { return m_fillColor; }
            set
            {
                if (m_fillColor == value) return;
                m_fillColor = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("FillColor")]
        public string FillColorXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(FillColor); }
            set { FillColor = (Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFrom(value) ?? "LightPink"); }
        }
        #endregion

        #region LineColor
        Color m_lineColor;

        [XmlIgnore]
        public Color LineColor
        {
            get { return m_lineColor; }
            set
            {
                if (m_lineColor == value) return;
                m_lineColor = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("LineColor")]
        public string LineColorXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(LineColor); }
            set { LineColor = (Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFrom(value) ?? "Red"); }
        }
        #endregion

        #region SelectionColor
        Color m_selectionColor;

        [XmlIgnore]
        public Color SelectionColor
        {
            get { return m_selectionColor; }
            set
            {
                if (value.A == 0 || m_selectionColor == value) return;
                m_selectionColor = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("SelectionColor")]
        public string SelectionColorXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(SelectionColor); }
            set { SelectionColor = (Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFrom(value) ?? "Red"); }
        }
        #endregion

        #region FontColor
        Color m_fontColor;

        [XmlIgnore]
        public Color FontColor
        {
            get { return m_fontColor; }
            set
            {
                if (m_fontColor == value) return;
                m_fontColor = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("FontColor")]
        public string FontColorXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(FontColor); }
            set { FontColor = (Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFrom(value) ?? "Navy"); }
        }
        #endregion

        #region TextFont
        Font m_textFont;

        [XmlIgnore]
        public Font TextFont
        {
            get
            {
                return m_textFont;// ?? (TextFont = new Font("Arial", 12));
            }
            set
            {
                if (m_textFont == value) return;
                m_textFont = value;
                m_appSettingsChanged = true;
            }
        }

        [XmlElement("TextFont")]
        public string TextFontXML
        {
            get { return TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(TextFont); }
            set { TextFont = (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFrom(value); }
        }
        #endregion

        // Serializes the class to the config file if any of the settings have changed.
        public bool Save()
        {
            if (m_appSettingsChanged)
            {
                StreamWriter myWriter = null;
                try
                {
                    var mySerializer = new XmlSerializer(typeof(ApplicationSettings));
                    // "C:\\Users\\htudosie.ESRI\\AppData\\Local\\HTCC\\PrintScreen\\2.0.1.1"
                    myWriter = new StreamWriter(Application.LocalUserAppDataPath + @"\app.config", false);

                    var sb = new StringBuilder();
                    mySerializer.Serialize(new StringWriter(sb), this);

                    mySerializer.Serialize(myWriter, this);
                }
                catch (Exception ex)
                {
                    Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
                }
                finally
                {
                    myWriter?.Close();
                }
            }
            return m_appSettingsChanged;
        }

        public bool ConfigurationFileExists { get; set; }

        // Deserializes the class from the config file.
        public bool Restore()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(ApplicationSettings));
                var fi = new FileInfo(Application.LocalUserAppDataPath + @"\app.config");
                if (fi.Exists)
                {
                    ConfigurationFileExists = true;
                    //ApplicationSettings Settings.Default;
                    //using (var myFileStream = fi.OpenRead())
                    //{
                    //    Settings.Default = (ApplicationSettings)mySerializer.Deserialize(myFileStream);
                    //}

                    m_optionFormLocation = Settings.Default.OptionFormLocation;
                    m_splashScreenBounds = Settings.Default.SplashScreenBounds;
                    m_defaultDirectory = Settings.Default.DefaultDirectory;
                    m_imagesDirectory = Settings.Default.ImagesDirectory;
                    m_autoSaveProjectFile = Settings.Default.AutoSaveProjectFile;
                    m_suppressStartUpHelp = Settings.Default.SuppressStartUpHelp;
                    m_pasteImagesWithBorder = Settings.Default.PasteImagesWithBorder;
                    m_textWithBorder = Settings.Default.TextWithBorder;
                    m_afterCaptureStayOnTop = Settings.Default.AfterCaptureStayOnTop;
                    m_transparentWhenNotFocussed = Settings.Default.TransparentWhenNotFocused;
                    m_formTransparencyFactor = Settings.Default.FormTransparencyFactor;
                    m_shapeFillTransparencyFactor = Settings.Default.FillTransparency;
                    m_captureFromTryIcon = Settings.Default.CaptureFromTryIcon;
                    m_autoHideMenu = Settings.Default.AutoHideMenu;
                    m_automaticallyCrop = Settings.Default.AutomaticallyCrop;
                    m_cursorColor = Settings.Default.CursorColor;
                    m_fillColor = Settings.Default.FillColor;
                    m_lineColor = Settings.Default.LineColor;
                    m_lineWidth = Settings.Default.LineWidth;
                    m_selectionColor = Settings.Default.SelectionColor;
                    m_textFont = Settings.Default.TextFont;
                    m_fontColor = Settings.Default.FontColor;
                    m_noToolTips = Settings.Default.NoToolTips;
                    m_applyToAll = Settings.Default.ApplyToAll;
                    m_autoSave = Settings.Default.AutoSave;
                    m_autoSaveAsk = Settings.Default.AutoSaveAsk;
                    m_fillTransparency = Settings.Default.FillTransparency;
                    //m_cursorOpacity = Settings.Default.CursorOpacity;
                    m_selectionOpacity = Settings.Default.SelectionOpacity;
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
            finally
            {
                if (string.IsNullOrEmpty(Settings.Default.DefaultDirectory))
                {
                    Settings.Default.DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
            }
            return ConfigurationFileExists;
        }

    }
}
