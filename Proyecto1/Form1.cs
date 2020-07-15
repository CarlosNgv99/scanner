using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        String fileDirectoryFocus;
        private OpenFileDialog fileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        AcercaDe ad = new AcercaDe();
        static RichTextBox txtAux = new RichTextBox();
        String richTxt = txtAux.Text;
        String ruta;
        StringBuilder grafo;
        static int contadorClick = 0;
        /* Listas para Graph */
        LinkedList<Token> listaTokens;
        LinkedList<Continente> listaContinente;
        LinkedList<Pais> listaPais;
        String agregarNombrePais;
        String agregarPoblacion;
        String agregarRuta;
        String agregarSaturacion;
        String agregarNombreContinente;
        String agregarContinentePais;
        String agregarSaturacionContinente;
        String agregarSaturacionContinentePais;

        String agregarNumPaisesContinente;
        int[] saturacionBurbuja;
        Pais[] saturacionBurbuja2;
        int[] saturacionBurbuja3;

        public Form1()
        {
            ruta = Path.Combine(Application.StartupPath, "graph");
            InitializeComponent();
            btnGenerarPdf.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tpage = new TabPage("Nueva Pestaña");
            txtAux = new RichTextBox();
            txtAux.Dock = DockStyle.Fill;
            richTxt = txtAux.Text;
            tpage.Controls.Add(txtAux);
            tabControl1.TabPages.Add(tpage);
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ad.Show();
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documento de texto|*.ORG";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                TabPage tpage = new TabPage(abrir.SafeFileName);
                txtAux = new RichTextBox();
                txtAux.Dock = DockStyle.Fill;
                txtAux.Text = leer.ReadToEnd();
                richTxt = txtAux.Text;
                tpage.Controls.Add(txtAux);
                tabControl1.TabPages.Add(tpage);
                leer.Close();
            //    fileDirectoryFocus = fileDialog.FileName;
               // this.Text = "Form1 - " + Path.GetFileNameWithoutExtension(fileDirectoryFocus);
            }
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Documento de texto|*.ORG";
            guardar.Title = "Guardar doc.";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in txtAux.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }

        }

        private void BtnAnalizar_Click(object sender, EventArgs e)
        {
            int contadorPaises = 0;
            Analizador analizador = new Analizador();
            listaTokens = analizador.escanear(richTxt);
            analizador.imprimirTokens(listaTokens);
            int r = 1;
            int n = 1;
            String auxiliarStr;
            analizador.imprimirTokens(listaTokens);

           
            /*****************Contar Paises*********************************/
            Boolean bandera2 = false;
            Boolean poblacion2 = false;
            Boolean pais2 = false;
            Boolean nombre2 = false;
            Boolean saturacion2 = false;
            Boolean continente2 = false;
            Boolean cierre2 = false;
            int contadorContinentes = 0;
            foreach (Token item in listaTokens)
            {
                if (item.getTipo().Equals("Reservada Bandera"))
                {
                    continente2 = false;
                    poblacion2 = false;
                    bandera2 = true;
                    nombre2 = false;
                    saturacion2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Grafica"))
                {
                    bandera2 = false;
                    pais2 = false;
                    poblacion2 = false;
                    nombre2 = false;
                    continente2= false;
                    saturacion2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Poblacion"))
                {
                    continente2 = false;
                    bandera2 = false;
                    poblacion2 = true;
                    nombre2 = false;
                    saturacion2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Pais"))
                {
                    continente2 = false;
                    nombre2 = false;
                    poblacion2= false;
                    pais2 = true;
                    bandera2 = false;
                    saturacion2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Saturacion"))
                {
                    nombre2 = false;
                    bandera2 = false;
                    poblacion2 = false;
                    saturacion2 = true;
                    continente2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Continente"))
                {
                    continente2 = true;
                    pais2 = false;
                    bandera2 = false;
                    poblacion2 = false;
                    nombre2 = false;
                    saturacion2 = false;
                    cierre2 = false;
                }
                else if (item.getTipo().Equals("Reservada Nombre"))
                {

                    nombre2 = true;
                }
                else if (item.getTipo().Equals("Llave derecha"))
                {
                    cierre2 = true;
                }

                if (pais2 == true)
                {
                    if (nombre2 == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            contadorPaises++;

                        }
                    }

                }
                if(continente2 == true)
                {
                    if(nombre2 == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            contadorContinentes++;
                        }
                    }
                }
                if (pais2 == true)
                {
                    if (cierre2 == true)
                    {
                    }
                }



            }


            /*********************** INFORMACIÖN *************************/
            label1.Visible = true;
            label2.Visible = true;
            Boolean bandera = false;
            Boolean poblacion = false;
            Boolean pais = false;
            Boolean nombre = false;
            Boolean saturacion = false;
            Boolean continente = false;
            Boolean cierre = false;
            int saturacionAux = 0;
            int contadorBurbuja=0;
            int contadorBurbuja2 = 0;
            int sumaSaturacion = 0;
            int saturacionContinente = 0;
            int contadorPaisesContinente = 0;
            listaPais = new LinkedList<Pais>();
            saturacionBurbuja = new int[contadorPaises];
            saturacionBurbuja2 = new Pais[contadorPaises];
            saturacionBurbuja3 = new int[contadorContinentes];
            listaContinente = new LinkedList<Continente>();

            

            /**************************************************************/
            foreach (Token item in listaTokens)
            {
                if (item.getTipo().Equals("Reservada Bandera"))
                {
                    continente = false;
                    poblacion = false;
                    bandera = true;
                    nombre = false;
                    saturacion = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Grafica"))
                {
                    bandera = false;
                    pais = false;
                    poblacion = false;
                    nombre = false;
                    continente = false;
                    saturacion = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Poblacion"))
                {
                    continente = false;
                    bandera = false;
                    poblacion = true;
                    nombre = false;
                    saturacion = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Pais"))
                {
                    continente = false;
                    nombre = false;
                    poblacion = false;
                    pais = true;
                    bandera = false;
                    saturacion = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Saturacion"))
                {
                    nombre = false;
                    bandera = false;
                    poblacion = false;
                    saturacion = true;
                    continente = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Continente"))
                {
                    continente = true;
                    pais = false;
                    bandera = false;
                    poblacion = false;
                    nombre = false;
                    saturacion = false;
                    cierre = false;
                }
                else if (item.getTipo().Equals("Reservada Nombre"))
                {

                    nombre = true;
                }
                else if(item.getTipo().Equals("Llave derecha"))
                {
                    cierre = true;
                }

                if (bandera == true)
                {
                    if (item.getTipo().Equals("Cadena"))
                    {
                        agregarRuta = item.getValor();
                        bandera = false;

                    }
                }
                if (pais == true)
                {
                    if (nombre == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            contadorPaisesContinente++;
                            agregarNombrePais = item.getValor();
                        }
                    }

                }
                if (pais == true)
                {
                    agregarSaturacionContinentePais = saturacionContinente.ToString();

                    if (cierre == true)
                    {
                        agregarPais();
                        pais = false;
                        cierre = false;
                        continente = true;
                    }
                }
                if(continente == true)
                {
                    if(cierre== true)
                    {
                        agregarNumPaisesContinente = contadorPaisesContinente.ToString();
                        saturacionContinente = (sumaSaturacion / contadorPaisesContinente);
                        agregarSaturacionContinente = saturacionContinente.ToString();
                        Console.WriteLine(agregarSaturacionContinente);
                        agregarContinente();
                        saturacionBurbuja3[contadorBurbuja2] = saturacionContinente;
                        contadorBurbuja2++;
                        saturacionContinente = 0;
                        sumaSaturacion = 0;
                        saturacionAux = 0;
                        contadorPaisesContinente = 0;
                        continente = false;

                    }
                }
                if (saturacion == true)
                {
                    if (item.getTipo().Equals("Numero porcentaje"))
                    {
                        agregarSaturacion = item.getValor();
                        saturacionAux = Convert.ToInt32(item.getValor());
                        sumaSaturacion = sumaSaturacion + saturacionAux;
                        saturacionBurbuja[contadorBurbuja] = saturacionAux;
                        contadorBurbuja++;
                        
                    }
                }

                if (continente == true)
                {
                    if (nombre == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {

                            agregarNombreContinente = item.getValor();

                              continente = false;
                        }
                    }
                }
                if (poblacion == true)
                {
                    if (item.getTipo().Equals("Numero entero"))
                    {
                        agregarPoblacion = item.getValor();
                    }
                }

            }

            /*******************************************************************/
            /***Saturacion de Paises ordenado***/
            bubbleSort(saturacionBurbuja);
            /***Saturacion de continente ordenado***/

            bubbleSort(saturacionBurbuja3);

            for (int i = 0; i < saturacionBurbuja.Length; i++)
            {
                foreach (Pais Pais in listaPais)
                {
                    if (Convert.ToInt32(Pais.getSaturacion()) == saturacionBurbuja[0])
                    {
                        for (int f = 0; f < saturacionBurbuja3.Length; f++)
                        {
                            foreach (Continente Continente in listaContinente)
                            {
                                if (Convert.ToInt32(Continente.getSaturacion()) == saturacionBurbuja3[0])
                                {
                                    if (Pais.getContinente().Equals(Continente.getContinente()))
                                    {
                                        lblNumHab.Text = Pais.getPoblacion();
                                        lblNumHab.Visible = true;
                                        lblPaisSelec.Text = Pais.getNombrePais();
                                        lblPaisSelec.Visible = true;
                                        try
                                        {
                                            pictureBox1.Image = Image.FromFile("../debug/" + Pais.getRutaBandera());
                                        }
                                        catch (Exception ex)
                                        { }
                                    }
                                }
                            }
                        }
                    }
                }
            }

       

            foreach (Continente Continente in listaContinente)
            {
                Console.WriteLine("Continente: " + Continente.getContinente() + " | SaturacionTotal: " + Continente.getSaturacion()+ " | NumPaises: "+ Continente.getNumPais());
            }
            foreach (Pais Pais in listaPais)
            {
                Console.WriteLine("Pais: " + Pais.getNombrePais() + " | Poblacion: " + Pais.getPoblacion() + " | RutaBandera: " + Pais.getRutaBandera() + " | Saturacion: " + Pais.getSaturacion() + "% " +"| Continente: "+ Pais.getContinente());
            }
            /***************** Texto Graphviz***************************/
            Boolean pais1 = false;
            Boolean bandera1 = false;
            Boolean poblacion1 = false;
            Boolean nombre1 = false;
            Boolean continente1 = false;
            Boolean saturacion1 = false;
            Boolean grafica1 = true;
            int numSaturacion = 0;
            int resultadoSaturacion = 0;
            String continenteAux2 = "";

            List<string> grapho = new List<string>();
            grapho.Add("digraph G {");
            foreach (Token item in listaTokens)
            {
                String porcentajeAux = " ";
                String continenteAux = " ";
                String paisAux = " ";
                if (item.getTipo().Equals("Reservada Grafica"))
                {
                    pais1 = false;
                    nombre1 = false;
                    continente1 = false;
                    bandera1 = false;
                    poblacion1 = false;
                    saturacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Pais"))
                {
                    saturacion1 = false;
                    continente1 = false;
                    nombre1 = false;
                    pais1 = true;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Saturacion"))
                {
                    saturacion1 = true;
                    nombre1 = false;
                    continente1 = false;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Continente"))
                {
                    saturacion1 = false;
                    continente1 = true;
                    pais1 = false;
                    nombre1 = false;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Poblacion"))
                {
                    saturacion1 = false;
                    continente1 = false;
                    bandera1 = false;
                    poblacion1 = true;
                    nombre1 = false;
                }
                else if (item.getTipo().Equals("Reservada Nombre"))
                {
                    nombre1 = true;
                }
                if (continente1 == true)
                {
                    if (nombre1 == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            continenteAux = item.getValor();
                            grapho.Add("start -> " + continenteAux + ";");
                            continenteAux2 = continenteAux + " -> ";
                            nombre1 = false;
                        }
                    }
                }
                if (pais1 == true)
                {
                    if (nombre1 == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            paisAux = item.getValor();
                            grapho.Add(continenteAux2 + paisAux + ";");
                            nombre1 = false;
                        }
                    }
                }
            }
            foreach(Token item in listaTokens)
            {
                if (item.getTipo().Equals("Reservada Grafica"))
                {
                    pais1 = false;
                    nombre1 = true;
                    continente1 = false;
                    bandera1 = false;
                    grafica1 = true;
                    poblacion1 = false;
                    saturacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Pais"))
                {
                    grafica1 = false;
                    saturacion1 = false;
                    continente1 = false;
                    nombre1 = false;
                    pais1 = true;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Saturacion"))
                {
                    grafica1 = false;
                    saturacion1 = true;
                    nombre1 = false;
                    continente1 = false;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Continente"))
                {
                    grafica1 = false;
                    saturacion1 = false;
                    continente1 = true;
                    pais1 = false;
                    nombre1 = false;
                    bandera1 = false;
                    poblacion1 = false;
                }
                else if (item.getTipo().Equals("Reservada Poblacion"))
                {
                    grafica1 = false;
                    saturacion1 = false;
                    continente1 = false;
                    bandera1 = false;
                    poblacion1 = true;
                    nombre1 = false;
                }
                else if (item.getTipo().Equals("Reservada Nombre"))
                {
                    nombre1 = true;
                }
                if( grafica1 == true)
                {
                    if(nombre1 == true)
                    {
                        if (item.getTipo().Equals("Cadena"))
                        {
                            grapho.Add("start[shape =Mdiamond label=\""+ item.getValor() + "\"];");
                            nombre1 = false;

                        }
                    }
                }

            }

            foreach(Continente Continente in listaContinente)
            {
                grapho.Add(Continente.getContinente() + "[shape=record label=\"{" + Continente.getContinente() + "|"+Continente.getSaturacion() + "}\"style=filled fillcolor=");
                if (Convert.ToInt32(Continente.getSaturacion()) >= 0 && Convert.ToInt32(Continente.getSaturacion()) <= 15)
                {
                    grapho.Add("white];");
                }
                else if (Convert.ToInt32(Continente.getSaturacion()) >= 16 && Convert.ToInt32(Continente.getSaturacion()) <= 30)
                {
                    grapho.Add("blue];");

                }
                else if (Convert.ToInt32(Continente.getSaturacion()) >= 31 && Convert.ToInt32(Continente.getSaturacion()) <= 45)
                {
                    grapho.Add("green];");

                }
                else if (Convert.ToInt32(Continente.getSaturacion()) >= 46 && Convert.ToInt32(Continente.getSaturacion()) <= 60)
                {
                    grapho.Add("yellow];");

                }
                else if (Convert.ToInt32(Continente.getSaturacion()) >= 61 && Convert.ToInt32(Continente.getSaturacion()) <= 75)
                {
                    grapho.Add("orange];");

                }
                else if (Convert.ToInt32(Continente.getSaturacion()) >= 76 && Convert.ToInt32(Continente.getSaturacion()) <= 100)
                {
                    grapho.Add("red];");

                }
            }

            /*******************************************************************/
            foreach (Pais Pais in listaPais)
            {
                grapho.Add(Pais.getNombrePais() + "[shape=record label=\"{" + Pais.getNombrePais() + "|" + Pais.getSaturacion() + "}\"style=filled fillcolor=");
                if (Convert.ToInt32(Pais.getSaturacion()) >= 0 && Convert.ToInt32(Pais.getSaturacion()) <= 15)
                {
                    grapho.Add("white];");
                }
                else if (Convert.ToInt32(Pais.getSaturacion()) >= 16 && Convert.ToInt32(Pais.getSaturacion()) <= 30)
                {
                    grapho.Add("blue];");

                }
                else if (Convert.ToInt32(Pais.getSaturacion()) >= 31 && Convert.ToInt32(Pais.getSaturacion()) <= 45)
                {
                    grapho.Add("green];");

                }
                else if (Convert.ToInt32(Pais.getSaturacion()) >= 46 && Convert.ToInt32(Pais.getSaturacion()) <= 60)
                {
                    grapho.Add("yellow];");

                }
                else if (Convert.ToInt32(Pais.getSaturacion()) >= 61 && Convert.ToInt32(Pais.getSaturacion()) <= 75)
                {
                    grapho.Add("orange];");

                }
                else if (Convert.ToInt32(Pais.getSaturacion()) >= 76 && Convert.ToInt32(Pais.getSaturacion()) <= 100)
                {
                    grapho.Add("red];");
                }
            }
            grapho.Add("}");
            File.WriteAllLines("grafica.txt", grapho);
            var result = string.Join(" ", grapho);

            /****************** Actualizar Gráfica ********************/
            contadorClick++;
            int posicion = 0;
            int columna = 0;
            int fila = 0;
            foreach(Token item in listaTokens)
            {
                if (item.getTipo().Equals("Desconocido"))
                {
                    lblNumHab.Visible = false;
                    lblPaisSelec.Visible = false;
                    pbGrafica.Visible = false;
                    pictureBox1.Visible = false;
                    btnGenerarPdf.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    MessageBox.Show("Error en generar información. Caracter desconocido encontrado en el archivo. Por favor, intente con otro archivo.","Error");
                    break;
                }
                else
                {
                    btnGenerarPdf.Visible = true;
                    lblNumHab.Visible = true;
                    lblPaisSelec.Visible = true;
                    try
                    {
                        pbGrafica.Visible = true;
                    }catch(Exception ex)
                    {}
                    pictureBox1.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    /******************Pintar texto*****************************/

                    this.changeColor("Pais", Color.Blue, 0);
                    this.changeColor("{", Color.Red, 0);
                    this.changeColor("}", Color.Red, 0);
                    this.changeColor("Nombre", Color.Blue, 0);
                    this.changeColor("Poblacion", Color.Blue, 0);
                    this.changeColor("Saturacion", Color.Blue, 0);
                    this.changeColor("Bandera", Color.Blue, 0);
                    this.changeColor("Continente", Color.Blue, 0);
                    this.changeColor("Grafica", Color.Blue, 0);

                    foreach (Token item2 in listaTokens)
                    {
                        if (item2.getTipo().Equals("Cadena"))
                        {
                            auxiliarStr = item2.getValor();
                            changeColor(auxiliarStr, Color.Yellow, 0);
                        }
                        if (item2.getTipo().Equals("Numero entero"))
                        {
                            auxiliarStr = item2.getValor();
                            changeColor(auxiliarStr, Color.Green, 0);
                        }
                        if (item2.getTipo().Equals("Numero porcentaje"))
                        {
                            auxiliarStr = item2.getValor();

                            if (Convert.ToInt32(auxiliarStr) >= 0 && Convert.ToInt32(auxiliarStr) <= 15)
                            {
                                changeColor(auxiliarStr, Color.White, 0);
                            }
                            else if (Convert.ToInt32(auxiliarStr) >= 16 && Convert.ToInt32(auxiliarStr) <= 30)
                            {
                                changeColor(auxiliarStr, Color.Blue, 0);

                            }
                            else if (Convert.ToInt32(auxiliarStr) >= 31 && Convert.ToInt32(auxiliarStr) <= 45)
                            {
                                changeColor(auxiliarStr, Color.Green, 0);

                            }
                            else if (Convert.ToInt32(auxiliarStr) >= 46 && Convert.ToInt32(auxiliarStr) <= 60)
                            {
                                changeColor(auxiliarStr, Color.Yellow, 0);

                            }
                            else if (Convert.ToInt32(auxiliarStr) >= 61 && Convert.ToInt32(auxiliarStr) <= 75)
                            {
                                changeColor(auxiliarStr, Color.Orange, 0);

                            }
                            else if (Convert.ToInt32(auxiliarStr) >= 76 && Convert.ToInt32(auxiliarStr) <= 100)
                            {
                                changeColor(auxiliarStr, Color.Red, 0);
                            }
                        }
                    }
                    /********************** Graficar ***************************/
                    graficar(result);
                    graficarPdf(result);
                    if (contadorClick > 0)
                    {
                        pbGrafica.Image.Dispose();

                    }
                    break;
                }
            }
        }
        private void changeColor(string word, Color color, int startIndex)
        {
            if (txtAux.Text.Contains(word))
            {
                int index = -1;
                int selectStart = txtAux.SelectionStart;
                while ((index = txtAux.Text.IndexOf(word, (index + 1))) != -1)
                {
                    txtAux.Select((index + startIndex), word.Length);
                    txtAux.SelectionColor = color;
                    txtAux.Select(selectStart, 0);
                    txtAux.SelectionColor = Color.Black;
                }
            }
        }

        private void generardot(String rdot, String rpng)
        {
            try
            {
                System.IO.File.WriteAllText(rdot, grafo.ToString());
                String comandoDot = "dot.exe -Tpng " + rdot + " -o " + rpng + " ";
                var comando = string.Format(comandoDot);
                var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStart;
                proc.Start();
                proc.WaitForExit();
            }catch(Exception ex) { }
        }
        private void generarPdf(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, grafo.ToString());
            String comandoDot = "dot.exe -Tpdf " + rdot + " -o " + rpng + " ";
            var comando = string.Format(comandoDot);
            var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStart;
            proc.Start();
            proc.WaitForExit();
        }
        public void graficarPdf(String texto)
        {
            grafo = new StringBuilder();
            String rdot = ruta + "\\imagen.dot";
            String rpng = ruta + "\\imagen.pdf";
            grafo.Append(texto);
            this.generarPdf(rdot, rpng);
            try
            {
                pbGrafica.Image = Image.FromFile("../debug/graph/imagen.pdf");
                pbGrafica.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
            }
        }
        public void graficar(String texto)
        {
            grafo = new StringBuilder();
            String rdot = ruta + "\\imagen.dot";
            String rpng = ruta + "\\imagen.png";
            grafo.Append(texto);
            this.generardot(rdot, rpng);

            try
            {
                pbGrafica.Image = Image.FromFile("../debug/graph/imagen.png");
                pbGrafica.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
            }
        }

        public void abrirGrafo()
        {
            if (File.Exists(ruta + "\\imagen.pdf"))
            {
                try
                {
                    MessageBox.Show("Archivo PDF creado.","PDF");
                    System.Diagnostics.Process.Start(ruta + "\\imagen.pdf");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex);
                }
            }
            else
            {
                MessageBox.Show("Error en la creación de PDF.");

                Console.WriteLine("Error, no existe.");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            abrirGrafo();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
        public void agregarPais()
        {
            listaPais.AddLast(new Pais(agregarNombrePais, agregarPoblacion, agregarRuta, agregarSaturacion, agregarNombreContinente));
            agregarNombrePais = "";
            agregarPoblacion = "";
            agregarRuta = "";
            agregarSaturacion = " ";
        }
        public void agregarContinente()
        {
                listaContinente.AddLast(new Continente(agregarNombreContinente, agregarSaturacionContinente, agregarNumPaisesContinente));
                agregarNombreContinente = "";
                agregarSaturacionContinente = "";
                agregarNombrePais = "";
            
        }
        public void bubbleSort(int[] arr)
        {
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted:");
            foreach (int p in arr)
                Console.WriteLine(p + " ");
            Console.Read();
        }
        public void bubbleSort2(int[] arr)
        {
           // arr = saturacionBurbuja3;
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            Console.WriteLine("Continentes ordenados:");
            foreach (int p in arr)
                Console.WriteLine(p + " ");
            Console.Read();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
