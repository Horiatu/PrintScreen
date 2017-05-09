using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.ComponentModel;

namespace FlexScreen
{
    public class ApplicationSettings
    {
        private bool appSettingsChanged;

        // Properties used to access the application settings variables.
        private string m_defaultDirectory;
        public string DefaultDirectory
        {
            get { return m_defaultDirectory; }
            set
            {
                if (value == m_defaultDirectory) return;
                m_defaultDirectory = value;
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                    appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
            }
        }

        private decimal m_cursorOpacity;
        public decimal CursorOpacity
        {
            get { return m_cursorOpacity; }
            set
            {
                if (value == m_cursorOpacity) return;
                m_cursorOpacity = value;
                appSettingsChanged = true;
            }
        }

        private decimal m_selectionOpacity;
        public decimal SelectionOpacity
        {
            get { return m_selectionOpacity; }
            set
            {
                if (value == m_selectionOpacity) return;
                m_selectionOpacity = value;
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
                appSettingsChanged = true;
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
            if (appSettingsChanged)
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
            return appSettingsChanged;
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
                    ApplicationSettings myAppSettings;
                    using (var myFileStream = fi.OpenRead())
                    {
                        myAppSettings = (ApplicationSettings)mySerializer.Deserialize(myFileStream);
                    }

                    m_optionFormLocation = myAppSettings.OptionFormLocation;
                    m_splashScreenBounds = myAppSettings.SplashScreenBounds;
                    m_defaultDirectory = myAppSettings.DefaultDirectory;
                    m_imagesDirectory = myAppSettings.ImagesDirectory;
                    m_autoSaveProjectFile = myAppSettings.AutoSaveProjectFile;
                    m_suppressStartUpHelp = myAppSettings.SuppressStartUpHelp;
                    m_pasteImagesWithBorder = myAppSettings.PasteImagesWithBorder;
                    m_textWithBorder = myAppSettings.TextWithBorder;
                    m_afterCaptureStayOnTop = myAppSettings.AfterCaptureStayOnTop;
                    m_transparentWhenNotFocussed = myAppSettings.TransparentWhenNotFocussed;
                    m_formTransparencyFactor = myAppSettings.FormTransparencyFactor;
                    m_shapeFillTransparencyFactor = myAppSettings.ShapeFillTransparencyFactor;
                    m_captureFromTryIcon = myAppSettings.CaptureFromTryIcon;
                    m_autoHideMenu = myAppSettings.AutoHideMenu;
                    m_automaticallyCrop = myAppSettings.AutomaticallyCrop;
                    m_cursorColor = myAppSettings.CursorColor;
                    m_fillColor = myAppSettings.FillColor;
                    m_lineColor = myAppSettings.LineColor;
                    m_lineWidth = myAppSettings.LineWidth;
                    m_selectionColor = myAppSettings.SelectionColor;
                    m_textFont = myAppSettings.TextFont;
                    m_fontColor = myAppSettings.FontColor;
                    m_noToolTips = myAppSettings.NoToolTips;
                    m_applyToAll = myAppSettings.ApplyToAll;
                    m_autoSave = myAppSettings.AutoSave;
                    m_autoSaveAsk = myAppSettings.AutoSaveAsk;
                    m_fillTransparency = myAppSettings.FillTransparency;
                    m_cursorOpacity = myAppSettings.CursorOpacity;
                    m_selectionOpacity = myAppSettings.SelectionOpacity;
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
            finally
            {
                if (m_defaultDirectory == null)
                {
                    DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
            }
            return ConfigurationFileExists;
        }

    }
}
