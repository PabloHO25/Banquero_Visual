namespace Banquero_Visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int x;
        }

    private  char[] Tipo = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'U', 'X', 'Y', 'Z' };
        private int n=-1, m=-1;
        private string secuencia;
        private string[] sec;
        private int[,] respaldoAsignacion;
       
        int[] secuenciaInt;

        bool band=false;
        int cg = 0;
        bool bandSec=false;
        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.Text = "1,2,3,...,n";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (esNum(textBox1.Text))
            {
                n = int.Parse(textBox1.Text);
                secuenciaInt = new int[n];
                //llenando el arreglo
                for (int i = 0; i < n; i++)
                    secuenciaInt[i] = i;
            }
            else
            {
                if(!(textBox1.Text==""|| textBox1.Text==null))
                     MessageBox.Show("No es numero valido");
            }
        }

     

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "1,2,3,...,n")
            {
                textBox2.Text = null;
                textBox2.ForeColor = Color.Black;
            }


            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            secuencia = textBox2.Text; //falta analizarlo
            secuencia.Replace(" ", "");
            sec = secuencia.Split(',');
            


          
                foreach (string s in sec)
                {

                
                if(s!="" || s != null)
                {
                    int x;
                    if (int.TryParse(s, out x))
                    {
                        if(!(x>=0 && x < n))
                        {
                            MessageBox.Show("Proceso no valido");
                            textBox2.Text = "";
                        }
                    }
                }

                }
            
        }


       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (esNum(textBox3.Text))
            {

                m = int.Parse(textBox3.Text);
                AjustaProcesos();
                AjustaMaximos();
                AjustaAsignacion();
                //   AjustaNecesidades();
            }
            else
            {
                if(!(textBox3.Text == null || textBox3.Text == ""))
                    MessageBox.Show(" Entrada no valida ");
                textBox3.Text = null;
            }
        }

        private void AjustaProcesos()
        {
            dataGridView5.ColumnCount = 1;
            dataGridView5.RowCount = m;
            dataGridView5.RowHeadersWidth = 45;
            dataGridView5.Columns[0].HeaderText = "Recursos";
            dataGridView5.Columns[0].Width = (dataGridView5.Width - dataGridView5.RowHeadersWidth);

            for (int i = 0; i < m; i++)
            {
                dataGridView5.Rows[i].Height = (dataGridView5.Height - dataGridView5.ColumnHeadersHeight-17) / m;

            }


            for (int i = 0; i < m; i++)
            {
                dataGridView5.Rows[i].HeaderCell.Value = "" + Tipo[i];

            }
        }
        private void AjustaMaximos()
        {
            
            dataGridView2.ColumnCount = m;
            dataGridView2.RowCount = n;
            dataGridView2.RowHeadersWidth = 60;

            for (int i = 0; i < m; i++)
            {
                dataGridView2.Columns[i].HeaderText = "" + Tipo[i];
                dataGridView2.Columns[i].Width = (dataGridView2.Width - dataGridView2.RowHeadersWidth) / m;
            }
            for (int i = 0; i < n; i++) {
                dataGridView2.Rows[i].HeaderCell.Value = "P" + "" + i;
                dataGridView2.Rows[i].Height = (dataGridView2.Height - dataGridView2.ColumnHeadersHeight) / n;

            }
            //for (int i = 0; i < m; i++)
           // for (int i = 0; i < n; i++)
            
            

        }
        private void AjustaAsignacion()
        {
            dataGridView3.ColumnCount = m;
            dataGridView3.RowCount = n;
            for (int i = 0; i < m; i++)
                dataGridView3.Columns[i].HeaderText = "" + Tipo[i];
            for (int i = 0; i < n; i++)
                dataGridView3.Rows[i].HeaderCell.Value = "P" + "" + i;
            dataGridView3.RowHeadersWidth = 60;
            for (int i = 0; i < m; i++)
                dataGridView3.Columns[i].Width = (dataGridView3.Width - dataGridView3.RowHeadersWidth) / m;
            for (int i = 0; i < n; i++)
                dataGridView3.Rows[i].Height = (dataGridView3.Height - dataGridView3.ColumnHeadersHeight) / n;
        }
        private void AjustaNecesidades()
        {
            dataGridView4.ColumnCount = m;
            dataGridView4.RowCount = n;
            for (int i = 0; i < m; i++)
                dataGridView4.Columns[i].HeaderText = "" + Tipo[i];
            for (int i = 0; i < n; i++)
                dataGridView4.Rows[i].HeaderCell.Value = "P" + "" + i;
            dataGridView4.RowHeadersWidth = 60;
            for (int i = 0; i < m; i++)
                dataGridView4.Columns[i].Width = (dataGridView4.Width - dataGridView4.RowHeadersWidth) / m;
            for (int i = 0; i < n; i++)
                dataGridView4.Rows[i].Height = (dataGridView4.Height - dataGridView4.ColumnHeadersHeight) / n;
        }




        private void LlenaNecesidades()
        {
            // aqui se llenara la matriz de necesidades con la resta de matrices

            if (Lleno(dataGridView2) && Lleno(dataGridView3))
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView4.Rows[i].Cells[j].Value = int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString()) - int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString());

                    }


            }
        }

        private bool esNum(string valor)
        {
            int x;
            if (int.TryParse(valor, out x))
                if (int.Parse(valor) > 0)
                    return true;
            return false;

                
        }

        private bool LLenoSec()
        {
            if ( textBox2.Text!= "1,2,3,...,n")
            {
                foreach (string a in sec)
                {
                    if (a == null || a.Length == 0! || a == "")
                        return false;
                }

                return true;

            }
            return false;
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Lleno(dataGridView5))
            {

            }
            else
            {
                if (band)
                     MessageBox.Show("LLena los recursos primero");
                
            }
            band = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            AjustaNecesidades();
            LlenaNecesidades();
            Iniciales();
            respaldoAsignacion = new int[n, m];
            
            //respaldando asignacion
            for(int i = 0; i < dataGridView3.Rows.Count; i++)
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    respaldoAsignacion[i,j]=int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString());
                }


        }

        private bool valido()
        {

            return !(dataGridView2.ColumnCount == -1 || dataGridView3.ColumnCount == -1 || dataGridView4.ColumnCount == -1 || dataGridView5.ColumnCount == -1);
        }

        private void Iniciales()
        {

            dataGridView6.ColumnCount = m;
            dataGridView6.RowCount = 1;



            int[] sum = SumAsignacion();


            for (int i = 0; i < sum.Length; i++)
            {
                if ( int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString()) - sum[i] < 0)
                {
                    MessageBox.Show("Valores para asignacion no validos");
                    clearAsignacion();
                    return;

                }
            }

            for (int i = 0; i < m; i++)
            {
                dataGridView6.Columns[i].Width = (dataGridView6.Width) / m;
                dataGridView6.Columns[i].HeaderText = ""+Tipo[i];

            }
            dataGridView6.Rows[0].Height = (dataGridView6.Height - dataGridView6.ColumnHeadersHeight);



            for (int i = 0; i < m; i++)
            {
                dataGridView6.Rows[0].Cells[i].Value = ( int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString())- sum[i]);

            }

        }
        private int[] SumAsignacion()
        {
            int[] sum=new int[m];

            for (int j = 0; j < m; j++)
                for(int i = 0; i < n; i++)
                {
                    sum[j] += int.Parse( dataGridView3.Rows[i].Cells[j].Value.ToString());
                }
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            bool ban = false;
            //    MessageBox.Show("99999999999999993");




            if (cg == n)
            {
                MessageBox.Show("Limpie el tablero");
            }
            else
            {

                

                if (LLenoSec())
                {
                    for (int j = 0; j <n ; j++)
                    {
                        dataGridView4.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        dataGridView3.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        dataGridView2.Rows[j].DefaultCellStyle.BackColor = Color.White;


                    }


                    dataGridView4.Rows[int.Parse(sec[cg])].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView3.Rows[int.Parse(sec[cg])].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView2.Rows[int.Parse(sec[cg])].DefaultCellStyle.BackColor = Color.Yellow;

                 

                        for (int j = 0; j < m; j++)
                    {
                        if (int.Parse(dataGridView3.Rows[int.Parse(sec[cg])].Cells[j].Value.ToString()) + int.Parse(dataGridView6.Rows[0].Cells[j].Value.ToString()) >= int.Parse(dataGridView4.Rows[int.Parse(sec[cg])].Cells[j].Value.ToString()))
                        {

                            dataGridView6.Rows[0].Cells[j].Value = int.Parse(dataGridView6.Rows[0].Cells[j].Value.ToString()) + int.Parse(dataGridView3.Rows[int.Parse(sec[cg])].Cells[j].Value.ToString());



                            dataGridView3.Rows[int.Parse(sec[cg])].Cells[j].Value = dataGridView2.Rows[int.Parse(sec[cg])].Cells[j].Value.ToString();
                            dataGridView4.Rows[int.Parse(sec[cg])].Cells[j].Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("SE HA ALCANZADO UN ESTADO INSEGURO\n Cambia la secuencia de procesos ");
                          
                            return;
                        }

                        //} 
                    }

                    cg++;
                    if (cg == n)
                    {


                      if(Seguro())
                            MessageBox.Show("SE HA ALCANCAZADO UN ESTADO SEGURO");

                      else
                            MessageBox.Show("SE HA ALCANZADO UN ESTADO INSEGURO\n Cambia la secuencia de procesos ");


                    }



                }
                else
                {
                    MessageBox.Show("Da la secuencia primero");
                }
            }

        }

        private void clearAsignacion()
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = 0;
                    dataGridView4.Rows[i].Cells[j].Value = 0;


                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (valido())
            {
                //respaldando asignacion
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        dataGridView3.Rows[i].Cells[j].Value = respaldoAsignacion[i, j];
                    }

                LlenaNecesidades();
                Iniciales();
                //    textBox2 = null;


                // secuencia=null;
                // sec=null;

                //secuenciaInt=null;

                //band = false;
                cg = 0;



            }
    }

       private void Estado()
        {

        }

      private bool Seguro()
        {
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                {

                    if (int.Parse(dataGridView4.Rows[i].Cells[j].Value.ToString())!=0)
                    {
                        return false;
                    }


                }
            }
            return true;
        }







        //private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{

        //        dataGridView2.Rows[e.RowIndex].ErrorText = "";
        //        int newInteger;

        //        // Don't try to validate the 'new row' until finished 
        //        // editing since there
        //        // is not any point in validating its initial value.
        //        if (dataGridView2.Rows[e.RowIndex].IsNewRow) { return; }

        //        if (!int.TryParse(e.FormattedValue.ToString(),
        //            out newInteger) || newInteger < 0)
        //        {
        //            e.Cancel = true;
        //            dataGridView2.Rows[e.RowIndex].ErrorText = "El valor de ser mayor o igual a cero";
        //        }
        //    e.Cancel = true;


        //}

        //    private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //    {
        //        dataGridView2.Rows[e.RowIndex].ErrorText = String.Empty;

        //}

        private bool Lleno(DataGridView D)
        {
            for (int i = 0; i < D.RowCount; i++)
            {
                for (int j = 0; j < D.ColumnCount; j++)
                {

                    if (D.Rows[i].Cells[j].Value == null)
                    {
                        return false;
                    }
                   

                }
            }
            return true;
            
        }
      
    }
}