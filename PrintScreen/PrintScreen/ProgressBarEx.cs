using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System;

namespace FlexScreen
{
    public partial class ProgressBarEx : ProgressBar
    {
        public ProgressBarEx()
        {
            m_markers = new Dictionary<int, Color>();

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        readonly Dictionary<int, Color> m_markers;

        public void AddMarker(Color color)
        {
            m_markers.Add(Value, color);
        }

        public new int Value
        {
            get { return base.Value; }
            set
            {
                base.Value = value;
                if (value == 0)
                {
                    m_markers.Clear();
                    //m_markers.Add(0, Color.Red);
                    //m_markers.Add(2, Color.Red);
                    //m_markers.Add(3, Color.Red);
                    //m_markers.Add(4, Color.Red);
                    //m_markers.Add(6, Color.Red);
                    //m_markers.Add(7, Color.Red);
                    //m_markers.Add(8, Color.Red);
                    //m_markers.Add(9, Color.Red);
                    //m_markers.Add(26, Color.Green);
                    //m_markers.Add(34, Color.Navy);
                    //m_markers.Add(35, Color.Navy);
                    //m_markers.Add(45, Color.Yellow);
                    //m_markers.Add(50, Color.White);
                    //m_markers.Add(51, Color.Black);
                }
            }
        }

        int m_cycle;
        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                var rec = new Rectangle(0, 0, Width, Height);

                if (ProgressBarRenderer.IsSupported)
                {
                    ProgressBarRenderer.DrawHorizontalBar(pe.Graphics, rec);
                }

                rec.Height -= 2;
                using (
                    var bg = new LinearGradientBrush(rec, Utils.LightenColor(BackColor, 60),
                                                     Utils.DarkenColor(BackColor, 30), LinearGradientMode.Vertical))
                {
                    pe.Graphics.FillRectangle(bg, 1, 1, rec.Width - 2, rec.Height - 2);
                }

                var dx = rec.Width/((double) Maximum);
                //rec.Width = (int)(rec.Width * Value / ((double)Maximum)) - 2;
                rec.Width = (int) (dx*Value) - 2;

                using (
                    var brush = new LinearGradientBrush(rec, Utils.LightenColor(ForeColor, 60),
                                                        Utils.DarkenColor(ForeColor, 30), LinearGradientMode.Vertical))
                {
                    brush.SetSigmaBellShape(0.75f, 1.0f);

                    using (
                        var lgb = new LinearGradientBrush(rec, Color.Transparent,
                                                          Color.FromArgb(200, Utils.LightenColor(ForeColor, 60)), 0.0f,
                                                          false))
                    {
                        if (m_cycle++ >= 50) m_cycle = 0;
                        if (m_cycle < 25)
                        {
                            lgb.SetSigmaBellShape(m_cycle/25.0f, 1.0f);
                        }

                        var m = m_markers.Keys.Where(v => v <= Value).OrderBy(i => i);
                        var last = 0;
                        var x = 0;

                        if (m.Any())
                        {
                            var d = new Dictionary<int, int>(m.Count());
                            foreach (var v in m)
                            {
                                if (d.Count == 0 || v != d[last] + last || m_markers[v] != m_markers[d[last] + last])
                                {
                                    d.Add(v, 1);
                                    last = v;
                                }
                                else
                                {
                                    d[last] += 1;
                                }
                            }

                            last = 0;
                            foreach (var v in d.Keys)
                            {
                                int w;
                                if (v > last)
                                {
                                    w = (int) (dx*(v - last));
                                    pe.Graphics.FillRectangle(brush, 1 + x, 1, w, rec.Height);
                                    last += v;
                                    x += w;
                                }
                                w = (int) (dx*d[v]);
                                var r = new Rectangle(1 + x, 1, w, rec.Height);
                                last += d[v];
                                x += w;
                                var b = new LinearGradientBrush(r,
                                                                Color.FromArgb(200, Utils.LightenColor(m_markers[v], 60)),
                                                                Utils.DarkenColor(m_markers[v], 30),
                                                                LinearGradientMode.Vertical);
                                b.SetSigmaBellShape(0.75f, 1.0f);
                                pe.Graphics.FillRectangle(b, r);
                            }
                        }

                        if (last < Value)
                        {
                            pe.Graphics.FillRectangle(brush, 1 + x, 1, (int) (dx*Value), rec.Height);
                        }
                        //foreach (var v in m_markers.Keys.Where(v => v <= Value).OrderBy(i => i))
                        //{
                        //    var r = new Rectangle(1 + (int)(dx * v), 1, 1 + (int)dx, rec.Height);
                        //    var b = new LinearGradientBrush(r, Color.FromArgb(200, Utils.LightenColor(m_markers[v], 60)),
                        //                                    Utils.DarkenColor(m_markers[v], 30), LinearGradientMode.Vertical);
                        //    b.SetSigmaBellShape(0.75f, 1.0f);
                        //    pe.Graphics.FillRectangle(b, r);
                        //}

                        rec.Height -= 2;
                        if (m_cycle < 25)
                        {
                            pe.Graphics.FillRectangle(lgb, 1, 1, rec.Width, rec.Height);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.MyContext.SplashScreenForm.NotifyIcon1.ShowBalloonTip(2000, "PrintScreen", ex.Message, ToolTipIcon.Error); // ?
            }
        }
    }
}
