using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing.Imaging;



namespace botones
{


    public class MaterialBotones: Button
    {
        public MaterialBotones()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0; // Elimina borde predeterminado
            Text = ""; // No mostrar texto
            Size = new Size(50, 50); // Tamaño inicial
  
        }

    }

    public class Botones : Button
    {


        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del borde del botón.")]
        public Color ColorBorde { get; set; } = Color.Transparent;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de fondo del botón.")]
        public Color ColorFondo { get; set; } = Color.Green;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del icono de 'Play'.")]
        public Color ColorIcono { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor del borde del botón.")]
        public int GrosorBorde { get; set; } = 2;
        public Botones()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0; // Elimina borde predeterminado
            Text = ""; // No mostrar texto
            Size = new Size(50, 50); // Tamaño inicial
            ResizeRedibujar();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar fondo circular
            using (SolidBrush brushFondo = new SolidBrush(ColorFondo))
            {
                pevent.Graphics.FillEllipse(brushFondo, 0, 0, Width, Height);
            }

            // Dibujar borde circular si tiene grosor
            if (GrosorBorde > 0)
            {
                using (Pen penBorde = new Pen(ColorBorde, GrosorBorde))
                {
                    pevent.Graphics.DrawEllipse(penBorde, GrosorBorde / 2, GrosorBorde / 2, Width - GrosorBorde, Height - GrosorBorde);
                }
            }

            // Dibujar el icono "Play"
            DibujarIconoPlay(pevent.Graphics);
        }

        public void DibujarIconoPlay(Graphics g)
        {
            int iconSize = Width / 3; // Tamaño del icono relativo al botón
            Point[] puntosTriangulo = {
                new Point(Width / 2 + iconSize / 2, Height / 2), // Punta del triángulo
                new Point(Width / 2 - iconSize / 2, Height / 2 - iconSize / 2),
                new Point(Width / 2 - iconSize / 2, Height / 2 + iconSize / 2)
            };

            using (SolidBrush brushIcono = new SolidBrush(ColorIcono))
            {
                g.FillPolygon(brushIcono, puntosTriangulo);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }



    public class Adelantar : Button
    {
        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del borde del botón.")]
        public Color ColorBorde { get; set; } = Color.Transparent;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de fondo del botón.")]
        public Color ColorFondo { get; set; } = Color.Red;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del icono.")]
        public Color ColorIcono { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor del borde del botón.")]
        public int GrosorBorde { get; set; } = 2;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Dirección del icono (true: derecha, false: izquierda).")]
        public bool DireccionIcono { get; set; } = true; // true = derecha, false = izquierda

        public Adelantar()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0; // Elimina borde predeterminado
            Text = ""; // No mostrar texto
            Size = new Size(50, 50); // Tamaño inicial
            ResizeRedibujar();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar fondo circular
            using (SolidBrush brushFondo = new SolidBrush(ColorFondo))
            {
                pevent.Graphics.FillEllipse(brushFondo, 0, 0, Width, Height);
            }

            // Dibujar borde circular si tiene grosor
            if (GrosorBorde > 0)
            {
                using (Pen penBorde = new Pen(ColorBorde, GrosorBorde))
                {
                    pevent.Graphics.DrawEllipse(penBorde, GrosorBorde / 2, GrosorBorde / 2, Width - GrosorBorde, Height - GrosorBorde);
                }
            }

            // Dibujar el icono de avance rápido
            DibujarIconoFastForward(pevent.Graphics);
        }

        public void DibujarIconoFastForward(Graphics g)
        {
            int iconSize = Width / 4; // Tamaño del triángulo
            int espacio = iconSize / 4; // Espacio entre triángulos

            int direccion = DireccionIcono ? 1 : -1; // Define la dirección del icono

            // Primer triángulo
            Point[] puntosTriangulo1 = {
                new Point(Width / 2 + (iconSize / 2) * direccion, Height / 2),
                new Point(Width / 2 - (iconSize / 2) * direccion, Height / 2 - iconSize),
                new Point(Width / 2 - (iconSize / 2) * direccion, Height / 2 + iconSize)
            };

            // Segundo triángulo (desplazado hacia la derecha)
            Point[] puntosTriangulo2 = {
                new Point(Width / 2 + (iconSize + espacio) * direccion, Height / 2),
                new Point(Width / 2 + (espacio) * direccion, Height / 2 - iconSize),
                new Point(Width / 2 + (espacio) * direccion, Height / 2 + iconSize)
            };

            using (SolidBrush brushIcono = new SolidBrush(ColorIcono))
            {
                g.FillPolygon(brushIcono, puntosTriangulo1);
                g.FillPolygon(brushIcono, puntosTriangulo2);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }


    public class Atrasar : Button
    {
        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del borde del botón.")]
        public Color ColorBorde { get; set; } = Color.Transparent;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de fondo del botón.")]
        public Color ColorFondo { get; set; } = Color.Red;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del icono.")]
        public Color ColorIcono { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor del borde del botón.")]
        public int GrosorBorde { get; set; } = 2;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Dirección del icono (true: derecha, false: izquierda).")]
        public bool DireccionIcono { get; set; } = false; // true = derecha, false = izquierda

        public Atrasar()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0; // Elimina borde predeterminado
            Text = ""; // No mostrar texto
            Size = new Size(50, 50); // Tamaño inicial
            ResizeRedibujar();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar fondo circular
            using (SolidBrush brushFondo = new SolidBrush(ColorFondo))
            {
                pevent.Graphics.FillEllipse(brushFondo, 0, 0, Width, Height);
            }

            // Dibujar borde circular si tiene grosor
            if (GrosorBorde > 0)
            {
                using (Pen penBorde = new Pen(ColorBorde, GrosorBorde))
                {
                    pevent.Graphics.DrawEllipse(penBorde, GrosorBorde / 2, GrosorBorde / 2, Width - GrosorBorde, Height - GrosorBorde);
                }
            }

            // Dibujar el icono de avance rápido
            DibujarIconoFastForward(pevent.Graphics);
        }

        public void DibujarIconoFastForward(Graphics g)
        {
            int iconSize = Width / 4; // Tamaño del triángulo
            int espacio = iconSize / 4; // Espacio entre triángulos

            int direccion = DireccionIcono ? 1 : -1; // Define la dirección del icono

            // Primer triángulo
            Point[] puntosTriangulo1 = {
                new Point(Width / 2 + (iconSize / 2) * direccion, Height / 2),
                new Point(Width / 2 - (iconSize / 2) * direccion, Height / 2 - iconSize),
                new Point(Width / 2 - (iconSize / 2) * direccion, Height / 2 + iconSize)
            };

            // Segundo triángulo (desplazado hacia la derecha)
            Point[] puntosTriangulo2 = {
                new Point(Width / 2 + (iconSize + espacio) * direccion, Height / 2),
                new Point(Width / 2 + (espacio) * direccion, Height / 2 - iconSize),
                new Point(Width / 2 + (espacio) * direccion, Height / 2 + iconSize)
            };

            using (SolidBrush brushIcono = new SolidBrush(ColorIcono))
            {
                g.FillPolygon(brushIcono, puntosTriangulo1);
                g.FillPolygon(brushIcono, puntosTriangulo2);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }

    public class BarraProgreso : Control
    {
        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de la barra de progreso.")]
        public Color ColorBarra { get; set; } = Color.OrangeRed;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del deslizador.")]
        public Color ColorDeslizador { get; set; } = Color.OrangeRed;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del texto del tiempo.")]
        public Color ColorTexto { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Valores")]
        [Description("Valor mínimo de la barra.")]
        public int Minimo { get; set; } = 0;

        [Browsable(true)]
        [Category("Valores")]
        [Description("Valor máximo de la barra.")]
        public int Maximo { get; set; } = 100;

        [Browsable(true)]
        [Category("Valores")]
        [Description("Valor actual de la barra.")]
        public int Valor { get; set; } = 0;

        public bool arrastrando = false;

        public BarraProgreso()
        {
            this.Size = new Size(250, 30);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int anchoBarra = Width - 40;
            int alturaBarra = 5;
            int xInicio = 20;
            int yCentro = Height / 2;

            // Dibujar la barra de fondo
            using (Pen penBarra = new Pen(ColorBarra, alturaBarra))
            {
                penBarra.StartCap = LineCap.Round;
                penBarra.EndCap = LineCap.Round;
                e.Graphics.DrawLine(penBarra, xInicio, yCentro, xInicio + anchoBarra, yCentro);
            }

            // Calcular posición del deslizador
            float porcentaje = (float)(Valor - Minimo) / (Maximo - Minimo);
            int xDeslizador = xInicio + (int)(porcentaje * anchoBarra);

            // Dibujar deslizador (círculo)
            int radioDeslizador = 10;
            using (SolidBrush brushDeslizador = new SolidBrush(ColorDeslizador))
            {
                e.Graphics.FillEllipse(brushDeslizador, xDeslizador - radioDeslizador / 2, yCentro - radioDeslizador / 2, radioDeslizador, radioDeslizador);
            }

            // Dibujar tiempos (inicio y fin)
            string tiempoInicio = FormatearTiempo(Minimo);
            string tiempoFin = FormatearTiempo(Maximo);
            using (SolidBrush brushTexto = new SolidBrush(ColorTexto))
            {
                e.Graphics.DrawString(tiempoInicio, Font, brushTexto, 0, yCentro - 20);
                e.Graphics.DrawString(tiempoFin, Font, brushTexto, Width - 30, yCentro - 20);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            arrastrando = true;
            ActualizarValor(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (arrastrando)
            {
                ActualizarValor(e.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            arrastrando = false;
        }

        public void ActualizarValor(int x)
        {
            int xInicio = 20;
            int anchoBarra = Width - 40;
            float porcentaje = (float)(x - xInicio) / anchoBarra;
            porcentaje = Math.Max(0, Math.Min(1, porcentaje));
            Valor = Minimo + (int)(porcentaje * (Maximo - Minimo));
            Invalidate();
        }

        public string FormatearTiempo(int segundos)
        {
            int minutos = segundos / 60;
            int seg = segundos % 60;
            return $"{minutos}:{seg:D2}";
        }
    }

    public class BotonCarpeta : Button

    {
        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del borde del botón.")]
        public Color ColorBorde { get; set; } = Color.Transparent;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de fondo del botón.")]
        public Color ColorFondo { get; set; } = Color.OrangeRed;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del icono.")]
        public Color ColorIcono { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor del borde del botón.")]
        public int GrosorBorde { get; set; } = 2;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Dirección del icono (true: derecha, false: izquierda).")]
        public bool DireccionIcono { get; set; } = true; // true = normal, false = invertido

        public BotonCarpeta()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = "";
            Size = new Size(50, 50);
            ResizeRedibujar();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar fondo circular
            using (SolidBrush brushFondo = new SolidBrush(ColorFondo))
            {
                pevent.Graphics.FillEllipse(brushFondo, 0, 0, Width, Height);
            }

            // Dibujar borde si tiene grosor
            if (GrosorBorde > 0)
            {
                using (Pen penBorde = new Pen(ColorBorde, GrosorBorde))
                {
                    pevent.Graphics.DrawEllipse(penBorde, GrosorBorde / 2, GrosorBorde / 2, Width - GrosorBorde, Height - GrosorBorde);
                }
            }

            // Dibujar icono de carpeta
            DibujarIconoCarpeta(pevent.Graphics);
        }

        public void DibujarIconoCarpeta(Graphics g)
        {
            int ancho = Width / 2;
            int alto = Height / 3;

            int xOffset = (Width - ancho) / 2;
            int yOffset = (Height - alto) / 2;

            int direccion = DireccionIcono ? 1 : -1; // Define si se invierte

            // Base de la carpeta
            Rectangle baseCarpeta = new Rectangle(xOffset, yOffset + alto / 4, ancho, alto);

            // Tapa superior (ligeramente inclinada)
            Point[] tapaCarpeta = {
                new Point(xOffset + (ancho / 4) * direccion, yOffset),
                new Point(xOffset + (ancho * 3 / 4) * direccion, yOffset),
                new Point(xOffset + ancho * direccion, yOffset + alto / 4),
                new Point(xOffset, yOffset + alto / 4)
            };

            using (SolidBrush brushIcono = new SolidBrush(ColorIcono))
            {
                g.FillRectangle(brushIcono, baseCarpeta);
                g.FillPolygon(brushIcono, tapaCarpeta);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }


    public class BotonCerrar : Button
    {
        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del borde del botón.")]
        public Color ColorBorde { get; set; } = Color.Transparent;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color de fondo del botón.")]
        public Color ColorFondo { get; set; } = Color.Red;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Color del icono.")]
        public Color ColorIcono { get; set; } = Color.White;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor del borde del botón.")]
        public int GrosorBorde { get; set; } = 2;

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Grosor de la 'X'.")]
        public int GrosorX { get; set; } = 4;

        public BotonCerrar()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = "";
            Size = new Size(50, 50);
            ResizeRedibujar();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Dibujar fondo circular
            using (SolidBrush brushFondo = new SolidBrush(ColorFondo))
            {
                pevent.Graphics.FillEllipse(brushFondo, 0, 0, Width, Height);
            }

            // Dibujar borde si tiene grosor
            if (GrosorBorde > 0)
            {
                using (Pen penBorde = new Pen(ColorBorde, GrosorBorde))
                {
                    pevent.Graphics.DrawEllipse(penBorde, GrosorBorde / 2, GrosorBorde / 2, Width - GrosorBorde, Height - GrosorBorde);
                }
            }

            // Dibujar la "X"
            DibujarIconoX(pevent.Graphics);
        }

        public void DibujarIconoX(Graphics g)
        {
            int margen = Width / 4; // Espacio entre la X y el borde
            int tamaño = Width - (2 * margen); // Tamaño de la X

            using (Pen penX = new Pen(ColorIcono, GrosorX))
            {
                g.DrawLine(penX, margen, margen, margen + tamaño, margen + tamaño);
                g.DrawLine(penX, margen + tamaño, margen, margen, margen + tamaño);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }


    public class BotonImagenCancion : Control
    {
       

        [Browsable(true)]
        [Category("Apariencia")]
        [Description("Imagen de la canción.")]
        public Image ImagenCancion { get; set; }

        public Image notaMusicalImagen;

        // URL de la imagen de la nota musical
        public string urlNotaMusical = "https://m.media-amazon.com/images/I/81wKjsr0rLL._UF894,1000_QL80_.jpg";

        public BotonImagenCancion()
        {
            // Cargar la imagen de la nota musical desde la URL
            DescargarImagenNotaMusical();

            Size = new Size(100, 100); // Tamaño por defecto
            ResizeRedibujar();
        }

        public void DescargarImagenNotaMusical()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    // Descarga la imagen desde la URL
                    byte[] imagenBytes = wc.DownloadData(urlNotaMusical);
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        notaMusicalImagen = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception)
            {
                // Si no se puede descargar la imagen, podemos mantener una imagen por defecto o manejar el error.
                notaMusicalImagen = null;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            

            

            // Dibujar la imagen de la canción o la nota musical
            if (ImagenCancion != null)
            {
                DibujarImagen(pevent.Graphics, ImagenCancion);
            }
            else
            {
                DibujarNotaMusical(pevent.Graphics);
            }
        }

        public void DibujarImagen(Graphics g, Image imagen)
        {
            int margen = Width / 8; // Márgenes para la imagen
            Rectangle destRect = new Rectangle(margen, margen, Width - 2 * margen, Height - 2 * margen);
            g.DrawImage(imagen, destRect);
        }

        public void DibujarNotaMusical(Graphics g)
        {
            if (notaMusicalImagen != null)
            {
                int margen = Width / 6;
                Rectangle destRect = new Rectangle(margen, margen, Width - 2 * margen, Height - 2 * margen);
                g.DrawImage(notaMusicalImagen, destRect);
            }
            else
            {
                // Si no se ha podido cargar la imagen, podemos dibujar algo por defecto o dejarlo vacío
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeRedibujar();
        }

        public void ResizeRedibujar()
        {
            if (Width > 0 && Height > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Width, Height);
                Region = new Region(path);
            }
        }
    }


    public class SongNameLabel : Label
    {
        public SongNameLabel()
        {
            Text = "Song name"; // Texto por defecto
            Font = new Font("Arial", 18, FontStyle.Bold);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        // Puedes agregar métodos o propiedades si deseas personalizar más
        public void SetSongName(string name)
        {
            Text = name; // Cambiar el nombre de la canción
        }
    }


    public class SongLabelDescrip : Label
    {
        public SongLabelDescrip()
        {
            Text = "Music player"; // Texto por defecto
            Font = new Font("Arial", 12, FontStyle.Regular);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        // Puedes agregar métodos o propiedades si deseas personalizar más
        public void SetDescription(string description)
        {
            Text = description; // Cambiar la descripción del reproductor
        }
    }

    public class PanelFondo : Panel
    {
        public PanelFondo()
        {
            BackColor = Color.Black;
        }
    }
}
    



      
