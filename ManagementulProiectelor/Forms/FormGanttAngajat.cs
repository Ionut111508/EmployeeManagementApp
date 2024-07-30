using LiveCharts;
using LiveCharts.Wpf;
using ManagementulProiectelor.Java;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Task = ManagementulProiectelor.Java.Task;

namespace ManagementulProiectelor.Forms
{
    public partial class FormGanttAngajat : Form
    {
        private List<Proiect> listaProiecte = DBHelper.ExtrageProiecteWithDapper();
        private List<Task> listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
        private List<Angajat> listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
        private List<Participa> listaParticipari = DBHelper.ExtrageParticipariWithDapper();
        private ToolTip toolTip = new ToolTip();
        private Dictionary<Rectangle, string> taskRectangles = new Dictionary<Rectangle, string>();
        private Rectangle currentDateLineRectangle;
        private DateTime dataInceputFiltru;
        private DateTime dataSfarsitFiltru;

        public FormGanttAngajat()
        {
            InitializeComponent();
            PopulareComboboxAngajati();
            checkBoxFiltrare.CheckedChanged += new EventHandler(checkBoxFiltrare_CheckedChanged);
            buttonAplica.Click += new EventHandler(buttonAplica_Click);
            dateTimePickerDataInceput.Visible = false;
            dateTimePickerDataSfarsit.Visible = false;

            pieChartAngajati.Dock = DockStyle.Left;
            panelSub.Controls.Add(pieChartAngajati);

            AdaugaDatePieChart();

            innerPanel = new Panel();
            innerPanel.Paint += new PaintEventHandler(panelGantt_Paint);
            innerPanel.MouseMove += new MouseEventHandler(innerPanel_MouseMove);
            innerPanel.Location = new Point(0, 0);
            panelGantt.Controls.Add(innerPanel);
            panelGantt.AutoScroll = true;
            panelGantt.Scroll += new ScrollEventHandler(panelGantt_Scroll);

            this.Load += new EventHandler(FormGanttAngajat_Load);

            comboBoxAngajati.SelectedIndexChanged += new EventHandler(comboBoxAngajati_SelectedIndexChanged);
        }
        private void AdaugaDatePieChart()
        {
            Angajat angajatSelectat = (Angajat)comboBoxAngajati.SelectedItem;
            int numarTaskuriAngajat = (DBHelper.ReturneazaTaskuriAngajat(angajatSelectat.Id_Angajat)).Count;
            int numarTotalTaskuri = listaTaskuri.Count;

            SeriesCollection series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Taskuri angajat",
                    Values = new ChartValues<double> { numarTaskuriAngajat }
                },
                new PieSeries
                {
                    Title = "Alte taskuri",
                    Values = new ChartValues<double> { numarTotalTaskuri - numarTaskuriAngajat }
                }
            };

            pieChartPontari.Series = series;

            int numarPontariLunaCurenta = DBHelper.NumarPontariLunaCurenta(angajatSelectat.Id_Angajat);

            DateTime dataCurenta = DateTime.Today;
            DateTime primaZiLunaCurenta = new DateTime(dataCurenta.Year, dataCurenta.Month, 1);

            int numarZile = (dataCurenta - primaZiLunaCurenta).Days + 1;

            int numarPontariNeefectuate = numarZile - numarPontariLunaCurenta;
            SeriesCollection seriesPontari = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Pontari efectuate ",
                    Values = new ChartValues<double> { numarPontariLunaCurenta }
                },
                new PieSeries
                {
                    Title = "Pontari neefectuate",
                    Values = new ChartValues<double> { numarPontariNeefectuate }
                }
            };
            pieChartAngajati.Series = seriesPontari;
        }

        private void PopulareComboboxAngajati()
        {
            List<Participa> participariSelectate;

            if (checkBoxFiltrare.Checked)
            {
                participariSelectate = listaParticipari
                    .Where(p => p.dataParasireTask >= dataInceputFiltru && p.dataParticipareTask <= dataSfarsitFiltru)
                    .ToList();
            }
            else
            {
                participariSelectate = listaParticipari;
            }

            var angajatiCuParticipari = participariSelectate
                .Select(p => p.Id_Angajat)
                .Distinct()
                .ToList();

            List<Angajat> angajatiFiltrati = listaAngajati
                .Where(a => angajatiCuParticipari.Contains(a.Id_Angajat))
                .ToList();

            comboBoxAngajati.DataSource = null;
            comboBoxAngajati.DataSource = angajatiFiltrati;
            comboBoxAngajati.DisplayMember = "AngajatFullName";
            comboBoxAngajati.MaxDropDownItems = 4;
            comboBoxAngajati.Invalidate();
        }

        private void FormGanttAngajat_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            IncarcaDate();
            PopulareComboboxAngajati();
        }
        private void IncarcaDate()
        {
            listaProiecte = DBHelper.ExtrageProiecteWithDapper();
            listaTaskuri = DBHelper.ExtrageTaskuriWithDapper();
            listaAngajati = DBHelper.ExtrageAngajatiWithDapper();
            listaParticipari = DBHelper.ExtrageParticipariWithDapper();
        }

        private void comboBoxAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            innerPanel.Invalidate();
            panelGantt.Invalidate();
        }
        private void InvalidateInnerPanel()
        {
            innerPanel.Invalidate();
        }
        private void panelGantt_Paint(object sender, PaintEventArgs e)
        {
            RedeseneazaContinut(e.Graphics);
        }

        private Color GetTaskColor(int taskIndex)
        {
            Color[] colors = new Color[] { Color.Green, Color.Orange, Color.Blue, Color.Purple, Color.Brown, Color.Red };
            return colors[taskIndex % colors.Length];
        }

        private void RedeseneazaContinut(Graphics g)
        {
            g.Clear(innerPanel.BackColor);
            Pen pen = new Pen(Color.Black);
            Font font = new Font("Times New Roman", 16, FontStyle.Bold);
            taskRectangles.Clear();

            if (comboBoxAngajati.SelectedItem is Angajat angajatSelectat)
            {
                DateTime dataCurenta = DateTime.Now;
                DateTime dataInceput = dataInceputFiltru != DateTime.MinValue ? dataInceputFiltru : dataCurenta;
                DateTime dataSfarsit = dataSfarsitFiltru != DateTime.MinValue ? dataSfarsitFiltru : dataCurenta.AddMonths(12);

                var participariSelectate = listaParticipari
                    .Where(p => p.Id_Angajat == angajatSelectat.Id_Angajat &&
                                p.dataParticipareTask <= dataSfarsit &&
                                p.dataParasireTask >= dataInceput)
                    .OrderBy(p => p.dataParticipareTask)
                    .ToList();

                if (!participariSelectate.Any())
                {
                    MessageBox.Show("Nu există participări pentru acest angajat în perioada selectată.");
                    return;
                }

                int taskSpacing = 70;
                int startY = 70;
                int currentY = startY;

                float maxTaskTextWidth = participariSelectate
                    .Select(p => DBHelper.ExtrageDenumireTask(p.Id_Task))
                    .Select(taskName => g.MeasureString(taskName, font).Width)
                    .Max();

                int startX = (int)(maxTaskTextWidth + 20);
                int numarLuni = ((dataSfarsit.Year - dataInceput.Year) * 12) + dataSfarsit.Month - dataInceput.Month;
                int spacing = 90;
                int endX = startX + numarLuni * spacing;

                for (int i = 0; i < participariSelectate.Count; i++)
                {
                    Participa participare = participariSelectate[i];
                    Color taskColor = GetTaskColor(i);
                    Brush taskBrush = new SolidBrush(taskColor);

                    string denumireTask = DBHelper.ExtrageDenumireTask(participare.Id_Task);
                    g.DrawString(denumireTask, font, Brushes.Black, 10, currentY + 25);

                    int taskLineY = currentY + font.Height / 2;
                    g.DrawLine(pen, startX - 350, taskLineY - 10, endX + 100, taskLineY - 10);

                    // Calculăm poziția și dimensiunea dreptunghiului pentru task
                    DateTime startTaskDate = participare.dataParticipareTask < dataInceput ? dataInceput : participare.dataParticipareTask;
                    DateTime endTaskDate = participare.dataParasireTask > dataSfarsit ? dataSfarsit : participare.dataParasireTask;

                    int startTaskX = startX + ((startTaskDate.Year - dataInceput.Year) * 12 + startTaskDate.Month - dataInceput.Month) * spacing +
                                     (startTaskDate.Day - 1) * (spacing / DateTime.DaysInMonth(startTaskDate.Year, startTaskDate.Month));
                    int endTaskX = startX + ((endTaskDate.Year - dataInceput.Year) * 12 + endTaskDate.Month - dataInceput.Month) * spacing +
                                   (endTaskDate.Day - 1) * (spacing / DateTime.DaysInMonth(endTaskDate.Year, endTaskDate.Month));

                    if (endTaskX <= startTaskX) endTaskX = startTaskX + 1;

                    // Verificăm dacă dreptunghiul se află în limitele vizibile și îl desenăm doar dacă se află în aceste limite
                    if (startTaskX < endX && endTaskX > startX)
                    {
                        Rectangle taskRect = new Rectangle(startTaskX, taskLineY + 15, endTaskX - startTaskX, 25);
                        g.FillRectangle(taskBrush, taskRect);

                        string taskInfo = $"Task: {denumireTask}\nProiect: {DBHelper.ExtrageDenumireProiect(participare.Id_Proiect)}\nInceput: {participare.dataParticipareTask:dd MMM yyyy}\nSfarsit: {participare.dataParasireTask:dd MMM yyyy}\nNumar Ore: {participare.nrOre}";
                        taskRectangles[taskRect] = taskInfo;
                    }

                    currentY += taskSpacing;
                }

                g.DrawLine(pen, startX - 350, currentY + font.Height / 2 - 10, endX + 100, currentY + font.Height / 2 - 10);

                int currentDateX = startX + ((dataCurenta.Year - dataInceput.Year) * 12 + dataCurenta.Month - dataInceput.Month) * spacing +
                                   (dataCurenta.Day - 1) * (spacing / DateTime.DaysInMonth(dataCurenta.Year, dataCurenta.Month));

                if (currentDateX >= startX && currentDateX <= endX)
                {
                    pen.Color = Color.Red;
                    pen.Width = 2;
                    g.DrawLine(pen, currentDateX, startY, currentDateX, currentY); // zi curenta
                    currentDateLineRectangle = new Rectangle(currentDateX - 1, startY, 3, currentY - startY);
                }
                else
                {
                    currentDateLineRectangle = Rectangle.Empty;
                }

                int startYMonths = startY;
                pen.Color = Color.Black;

                for (int i = 0; i <= numarLuni; i++)
                {
                    DateTime dataLunaCurenta = dataInceput.AddMonths(i);
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
                        g.DrawLine(pen, lineX + 90, startYMonths - 30, lineX + 90, currentY);
                    }
                }

                g.DrawLine(pen, endX + spacing, startYMonths - 40, endX + spacing, currentY);

                int totalWidth = endX + spacing;
                int totalHeight = currentY;

                panelGantt.AutoScrollMinSize = new Size(totalWidth, totalHeight);
                innerPanel.Size = new Size(totalWidth, totalHeight);
            }
        }

        private void panelGantt_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
        private void panelGantt_Scroll(object sender, ScrollEventArgs e)
        {
            innerPanel.Invalidate();
            panelGantt.Invalidate();
        }
        private void checkBoxFiltrare_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDataInceput.Visible = checkBoxFiltrare.Checked;
            dateTimePickerDataSfarsit.Visible = checkBoxFiltrare.Checked;

            if (!checkBoxFiltrare.Checked)
            {
                dataInceputFiltru = DateTime.MinValue;
                dataSfarsitFiltru = DateTime.MinValue;
                //innerPanel.Invalidate();
            }
        }
        private void buttonAplica_Click(object sender, EventArgs e)
        {
            // Verifică dacă filtrul este activ și setează datele corespunzătoare
            if (checkBoxFiltrare.Checked)
            {
                dataInceputFiltru = dateTimePickerDataInceput.Value;
                dataSfarsitFiltru = dateTimePickerDataSfarsit.Value;
            }
            else
            {
                dataInceputFiltru = DateTime.MinValue;
                dataSfarsitFiltru = DateTime.MinValue;
            }

            // Încarcă datele
            IncarcaDate();

            comboBoxAngajati.DisplayMember = "AngajatFullName";

            Angajat angajatSelectat = (Angajat)comboBoxAngajati.SelectedItem;

            PopulareComboboxAngajati();

            foreach (Angajat angajat in comboBoxAngajati.Items)
            {
                if (angajat.Id_Angajat == angajatSelectat.Id_Angajat)
                {
                    comboBoxAngajati.SelectedItem = angajat;
                    break;
                }
            }
            panelGantt.Invalidate();
        }



        private void innerPanel_Paint(object sender, PaintEventArgs e)
        {
            RedeseneazaContinut(e.Graphics);
        }

        private void innerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool tooltipSet = false;

            foreach (var kvp in taskRectangles)
            {
                if (kvp.Key.Contains(e.Location))
                {
                    toolTip.SetToolTip(innerPanel, kvp.Value);
                    tooltipSet = true;
                    break;
                }
            }
            if (!tooltipSet)
            {
                if (currentDateLineRectangle.Contains(e.Location))
                {
                    DateTime currentDate = DateTime.Now;
                    toolTip.SetToolTip(innerPanel, $"Data curentă: {currentDate:dd MMM yyyy}");
                    tooltipSet = true;
                }
                else
                {
                    toolTip.SetToolTip(innerPanel, string.Empty);
                }
            }
        }
    }
}
