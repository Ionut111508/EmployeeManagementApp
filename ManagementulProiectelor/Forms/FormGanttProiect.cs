using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor
{
    public partial class FormGanttProiect : Form
    {
        static List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        static List<Task> listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
        private ToolTip toolTip = new ToolTip();
        private Dictionary<Rectangle, string> taskRectangles = new Dictionary<Rectangle, string>();
        private Rectangle currentDateLineRectangle;

        public FormGanttProiect()
        {
            InitializeComponent();
            PopularecomboBoxProiecte();
        }

        private void PopularecomboBoxProiecte()
        {
            List<Proiect> listaProiecteFiltrate = new List<Proiect>();

            foreach (Proiect proiect in listaProiecte)
            {
                var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiect.Id_Proiect);
                if (detaliiProiect.dataFinalizareProiect > DateTime.Now)
                {
                    bool areTaskuri = listaTaskuri.Any(t => t.Id_Proiect == proiect.Id_Proiect);
                    if (areTaskuri)
                    {
                        listaProiecteFiltrate.Add(proiect);
                    }
                }
            }
            listaProiecteFiltrate = listaProiecteFiltrate.OrderBy(p => p.denumireProiect).ToList();

            comboBoxProiecte.DataSource = null;
            comboBoxProiecte.DataSource = listaProiecteFiltrate;
            comboBoxProiecte.DisplayMember = "denumireProiect";

            if (listaProiecteFiltrate.Count > 0)
            {
                comboBoxProiecte.SelectedIndex = 0;
            }
        }

        private void FormGanttProiect_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            panelGrafic.MouseMove += new MouseEventHandler(panelGrafic_MouseMove);
        }

        private void comboBoxProiecte_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelGrafic.Invalidate();
        }

        private void panelGrafic_Paint(object sender, PaintEventArgs e)
        {
            RedeseneazaContinut(e.Graphics);
        }

        private Color GetTaskColor(int taskIndex)
        {
            Color[] colors = new Color[] {Color.Green, Color.Orange, Color.Blue, Color.Purple, Color.Brown, Color.Red };
            return colors[taskIndex % colors.Length];
        }

        private void RedeseneazaContinut(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Font font = new Font("Times New Roman", 16, FontStyle.Bold);
            taskRectangles.Clear(); 

            if (comboBoxProiecte.SelectedItem != null)
            {
                Proiect proiectSelectat = (Proiect)comboBoxProiecte.SelectedItem;
                var detaliiProiect = DBHelper.ExtrageDetaliiProiect(proiectSelectat.Id_Proiect);

                List<Task> listaTaskuriProiect = DBHelper.ExtrageTaskuriByProiect(proiectSelectat.Id_Proiect);
                List<PerioadeTaskGantt> listaPerioadeTaskuri = new List<PerioadeTaskGantt>();

                foreach (Task t in listaTaskuriProiect)
                {
                    listaPerioadeTaskuri.Add(DBHelper.ExtrageDetaliiTaskGantt(t.Id_Task));
                }

                listaPerioadeTaskuri = listaPerioadeTaskuri.OrderBy(pt => pt.DataIncepereTask).ToList();

                int taskSpacing = 70; 
                int startY = 70; 
                int currentY = startY; 


                float maxTaskTextWidth = 0;
                foreach (PerioadeTaskGantt perioadaTask in listaPerioadeTaskuri)
                {
                    SizeF textSize = g.MeasureString(perioadaTask.DenumireTask, font);
                    if (textSize.Width > maxTaskTextWidth)
                    {
                        maxTaskTextWidth = textSize.Width;
                    }
                }

                int startX = (int)(maxTaskTextWidth + 20);

                int numarLuni = ((detaliiProiect.dataFinalizareProiect.Year - detaliiProiect.dataIncepereProiect.Year) * 12) +
                                detaliiProiect.dataFinalizareProiect.Month - detaliiProiect.dataIncepereProiect.Month;
                int spacing = 100; 
                int endX = startX + numarLuni * spacing;

                for (int i = 0; i < listaPerioadeTaskuri.Count; i++)
                {
                    PerioadeTaskGantt perioadaTask = listaPerioadeTaskuri[i];
                    Color taskColor = GetTaskColor(i);
                    Brush taskBrush = new SolidBrush(taskColor);

                    g.DrawString(perioadaTask.DenumireTask, font, Brushes.Black, 10, currentY + 25);

                    int taskLineY = currentY + font.Height / 2;

                    g.DrawLine(pen, startX - 350, taskLineY - 10, endX + 100, taskLineY - 10);

                    int startTaskX = startX + ((perioadaTask.DataIncepereTask.Year - detaliiProiect.dataIncepereProiect.Year) * 12 +
                        perioadaTask.DataIncepereTask.Month - detaliiProiect.dataIncepereProiect.Month) * spacing +
                        (perioadaTask.DataIncepereTask.Day - 1) * (spacing / DateTime.DaysInMonth(perioadaTask.DataIncepereTask.Year, perioadaTask.DataIncepereTask.Month));
                    int endTaskX = startX + ((perioadaTask.DataFinalizareTask.Year - detaliiProiect.dataIncepereProiect.Year) * 12 +
                        perioadaTask.DataFinalizareTask.Month - detaliiProiect.dataIncepereProiect.Month) * spacing +
                        (perioadaTask.DataFinalizareTask.Day - 1) * (spacing / DateTime.DaysInMonth(perioadaTask.DataFinalizareTask.Year, perioadaTask.DataFinalizareTask.Month));

                    Rectangle taskRect = new Rectangle(startTaskX, taskLineY + 15, endTaskX - startTaskX, 25);
                    g.FillRectangle(taskBrush, taskRect);

                    string taskInfo = $"Proiect: {proiectSelectat.denumireProiect }\nInceput: {perioadaTask.DataIncepereTask:dd MMM yyyy}\nSfarsit: {perioadaTask.DataFinalizareTask:dd MMM yyyy}\nNumar ore nealocat: {perioadaTask.NumarOreMaxim - perioadaTask.NumarOreAlocate}";
                    taskRectangles[taskRect] = taskInfo;

                    currentY += taskSpacing;
                }

                g.DrawLine(pen, startX - 350, currentY + font.Height / 2 - 10, endX + 100, currentY + font.Height / 2 - 10);

                DateTime currentDate = DateTime.Now;
                if (currentDate >= detaliiProiect.dataIncepereProiect && currentDate <= detaliiProiect.dataFinalizareProiect)
                {
                    int currentDateX = startX + ((currentDate.Year - detaliiProiect.dataIncepereProiect.Year) * 12 +
                        currentDate.Month - detaliiProiect.dataIncepereProiect.Month) * spacing +
                        (currentDate.Day - 1) * (spacing / DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

                    pen.Color = Color.Red;
                    pen.Width = 2;
                    g.DrawLine(pen, currentDateX, startY, currentDateX, currentY);
                    currentDateLineRectangle = new Rectangle(currentDateX - 1, startY, 3, currentY - startY);
                }

                int startYMonths = startY; 
                pen.Color = Color.Black;

                g.DrawLine(pen, endX + spacing, startYMonths - 40, endX + spacing, currentY);

                for (int i = 0; i <= numarLuni; i++)
                {
                    DateTime dataLunaCurenta = detaliiProiect.dataIncepereProiect.AddMonths(i);
                    string numeLuna = dataLunaCurenta.ToString("MMM yyyy");
                    SizeF textSize = g.MeasureString(numeLuna, font);

                    int textX = startX + i * spacing - (int)(textSize.Width / 2);
                    int textY = startYMonths - 30; 

                    g.DrawString(numeLuna, font, Brushes.Black, textX + 45, textY);

                    int lineX = textX + (int)textSize.Width / 2;
                    if (i == 0)
                    {
                        g.DrawLine(pen, textX + 40, startYMonths - 40, textX + 40, currentY);
                    }
                    if (i < numarLuni)
                    {
                        g.DrawLine(pen, lineX + 95, startYMonths - 30, lineX + 95, currentY);
                    }
                }

                int totalWidth = endX + spacing;
                int totalHeight = currentY; 

                panelGrafic.AutoScrollMinSize = new Size(totalWidth, totalHeight);
            }
        }

        private void panelGrafic_MouseMove(object sender, MouseEventArgs e)
        {
            bool tooltipSet = false;

            foreach (var i in taskRectangles)
            {
                if (i.Key.Contains(e.Location))
                {
                    toolTip.SetToolTip(panelGrafic, i.Value);
                    tooltipSet = true;
                    break;
                }
            }

            if (!tooltipSet)
            {
                if (currentDateLineRectangle.Contains(e.Location))
                {
                    DateTime currentDate = DateTime.Now;
                    toolTip.SetToolTip(panelGrafic, $"Data curentă: {currentDate:dd MMM yyyy}");
                    tooltipSet = true;
                }
                else
                {
                    toolTip.SetToolTip(panelGrafic, string.Empty);
                }
            }
        }
        private void panelGrafic_Scroll(object sender, ScrollEventArgs e)
        {
            panelGrafic.Invalidate();
        }
    }
}
