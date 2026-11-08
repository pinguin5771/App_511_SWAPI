using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.ComponentModel;

namespace App_511_SWAPI;

public class RoundedPictureBox : PictureBox
{
    private int borderRadius = 30;

    [Category("Custom Properties")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderRadius
    {
        get => borderRadius;
        set { borderRadius = value; this.Invalidate(); }
    }

    public RoundedPictureBox()
    {
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        this.BackColor = Color.Transparent;
    }

    private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        float m = 0.5f;

        path.StartFigure();
        path.AddArc(rect.X + m, rect.Y + m, radius, radius, 180, 90);
        path.AddArc(rect.Width - radius - m, rect.Y + m, radius, radius, 270, 90);
        path.AddArc(rect.Width - radius - m, rect.Height - radius - m, radius, radius, 0, 90);
        path.AddArc(rect.X + m, rect.Height - radius - m, radius, radius, 90, 90);
        path.CloseAllFigures();

        return path;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;

        if (this.Image != null && rectSurface.Width > 0 && rectSurface.Height > 0)
        {
            int radius = Math.Min(borderRadius, Math.Min(rectSurface.Width, rectSurface.Height) / 2);
            if (radius <= 0) radius = 1;

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, radius))
            {
                using (Bitmap bitmapScaled = new Bitmap(this.Image, rectSurface.Width, rectSurface.Height))
                {
                    using (TextureBrush textureBrush = new TextureBrush(bitmapScaled))
                    {
                        graphics.FillPath(textureBrush, pathSurface);
                    }
                }
            }
        }
        else
        {
            base.OnPaint(e);
        }
    }
}
