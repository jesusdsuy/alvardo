using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2010.Word.DrawingShape;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic.ApplicationServices;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRGA_GUIAS
{
    public partial class FrmExportacion : Form
    {
        public FrmExportacion()
        {
            InitializeComponent();
        }

        private void btnMostrardatos_Click(object sender, EventArgs e)
        {
            MostrarRomaneod(tromaneo.Text);

        }

        public void MostrarRomaneod(string romaneo) 
        {
        List<Producto> productos=new Datosplanta().DevProductos1romaneo(romaneo);
            //agrupar x codigo la lista

            var totalesxcodigo =productos.GroupBy(grupo => grupo.Codigo);
            double tk = 0;
            List<Producto> list = new List<Producto>();

            foreach (var group in totalesxcodigo)
            {
               listBox1.Items.Add(group.Key + ":");
                foreach (var user in group)
                        tk=tk+user.Peso;
            Producto producto = new Producto();
                producto.Codigo = group.Key;
                producto.Peso = tk;
                
                listBox1.Items.Add("total " + tk);
                list.Add(producto);
            }

            

            grillaromaneo.DataSource=list;

            etitotal.Text =totalpeso().ToString("##,###,##0.00");
         }

        private double totalpeso()
        { 
        double total = 0;
            foreach (DataGridViewRow row in grillaromaneo.Rows)
            {
                try
                {
                    total = total + double.Parse(row.Cells["Peso"].Value.ToString());
                }
                catch (Exception)
                {

                    total = total + 0;
                }
                
                
            }
            return total;

        }

        private void FrmExportacion_Load(object sender, EventArgs e)
        {
            Datosplanta ds = new Datosplanta();
            List<Aduana> lista=ds.DevAduanas();

            comboaduanas.DataSource=lista;  

            

        }

        private void btnenviarcarga_Click(object sender, EventArgs e)
        {
            //mando la carga a la aduana correspondiente
          //  Aduana aduana = comboaduanas.SelectedItem();
           Aduana seleccionado = (Aduana)
           comboaduanas.SelectedItem;
            int codigoaduana  = seleccionado.Aduanacodigo;
            string matricula = tmatricula.Text.Trim();
            
            if (matricula == null)
            {
                MessageBox.Show("debe haber una matricula");

            }
            else
            {
                matricula = matricula.Trim();
            
                long transaccionid = NuevaTransaccionADUANA(codigoaduana,matricula);
                listBox1.Items.Add("transaccion " + transaccionid);
                //ahora la carga
                Datosplanta ds = new Datosplanta();
                List<Producto> productos=new List<Producto>();

                foreach (DataGridViewRow row in grillaromaneo.Rows)
                {
                    try
                    {
                        Producto producto = new Producto(); 
                        producto.Codigo=row.Cells["Codigo"].Value.ToString();
                        producto.Peso =double.Parse(row.Cells["Peso"].Value.ToString());
                        productos.Add(producto);
                    }
                    catch (Exception)
                    {
                                               
                    }
               
                }

                // a los productos los acumulo x codigo para que viaje el total de un mismo codigo
                if (productos.Count == 0)
                {
                    listBox1.Items.Add("no hay productos en la grilla");

                }
                else
                {

                    long cargaid = ds.Nuevacarga(transaccionid, productos);
                    listBox1.Items.Add("carga enviada " + cargaid);
                    //confirmocarga
                    listBox1.Items.Add("carga confirmada " + ds.Confirmocarga(cargaid));
                    //finalizo
                    listBox1.Items.Add("Transaccion finalizada " + ds.Finalizotransaccionaduana(transaccionid));

                    MessageBox.Show("Listo");
                }

            }

        }

        public long NuevaTransaccionADUANA(int aduana, string matricula)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            
            var input = new CrearTrasladoHaciaAduanaSDT { AduanaCodigo = aduana, EmpresaRUT = 214494550018, Matricula =matricula };
            var respuesta = cliente.CREARTRANSACCIONTRASLADOHACIAADUANAAsync(new CREARTRANSACCIONTRASLADOHACIAADUANARequest(input));
            //en la respuesta tengo el id
            //y si fue exitosa la creascion

            respuesta.Wait();


            //MessageBox.Show("exito " + respuesta.Result.Resultado.Exito);
            listBox1.Items.Add("Nueva transaccion es " + respuesta.Result.Resultado.Exito);


            foreach (var mensaje in respuesta.Result.Resultado.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }

            long transaccionid = respuesta.Result.Transaccionid;
            //MessageBox.Show("transaccionid " + transaccionid);
            listBox1.Items.Add("transaccionid " + transaccionid);
            return transaccionid;

        }

        private void grillaromaneo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
