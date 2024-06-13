
using DocumentFormat.OpenXml.InkML;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRGA_GUIAS
{
    public partial class FrmDescarga : Form
    {

        
        public FrmDescarga()
        {
            InitializeComponent();
        }



    

        private void FrmDescarga_Load(object sender, EventArgs e)
        {
            long a = mistransacciones();
            //cargo el combodestinos
            Datosplanta ds = new();
            List<Destino> destinos = ds.DevDestinos();

            Combodonde.Items.AddRange(destinos.ToArray());


           // foreach (var item in destinos)
            
            //{
              //  Combodonde.Items.Add(item);
            //}



        }


        private void button1_Click(object sender, EventArgs e)
        {
            //descargo la transaccion y cargaid
            var fila = grillaTramsacciones.CurrentRow;    //fila seleccionada
                                                          //obtienes el valor de las columnas, arrancan en 0

            long tid = Convert.ToInt32(fila.Cells[0].Value.ToString());
            long tcd = Convert.ToInt32(fila.Cells[2].Value.ToString());
            listBox1.Items.Add(tid + " " + tcd);

            Datosplanta datosplanta = new Datosplanta();
          
            //ahora veré de tomar la lista de productos para misproductos
                        
            List<Producto> misproductos = datosplanta.DevArticulos1transaccion1carga(tid, tcd);
            //hacer la descarga
            Destino xdestino = (Destino)Combodonde.SelectedItem;
 
            long descargaid = datosplanta.DescargaenPlantaID(tid, tcd, misproductos, tfactura.Text, "", xdestino.Depositoid, xdestino.Rutreceptor);
            //finalizo descarga
            //datosplanta.FinalizarDescarga(descargaid);
            //finalizar la transaccion
            //datosplanta.FinalizarTransaccion(tid);

            //cerrar la carga en losrsinal
            if (datosplanta.CerrarCargaLorsinal(tid, tcd)) listBox1.Items.Add("cerrrada la carga en lorsinal");
                        
            MessageBox.Show("listo se ha descargado, el id es: "+descargaid);




        }

        public long mistransacciones()
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();

            var filtro = new wsVerTransaccionesFiltros { FechaCreacionDesde = DateTime.Today, FechaCreacionHasta = DateTime.Today, TipoTransaccion="VentaDirecta" };
            var respuesta = cliente.VERTRANSACCIONESAsync( new VERTRANSACCIONESRequest(214494550018, filtro));

            respuesta.Wait();
             
            wsTransaccionesSDT transascs = new wsTransaccionesSDT();
            transascs = respuesta.Result.Wstransaccionessdt;
                       
            listBox1.Items.Add(respuesta.Result.Resultado.Exito);

            List<TransaccionLor> Listadetransacciones=new List<TransaccionLor>();
           
            foreach (wsTransaccionSDT una  in transascs.wsTransaccionSDT)

            {

              
                listBox1.Items.Add("transaccionid"+una.TransaccionId);
                listBox1.Items.Add("transaccionestado" + una.TransaccionEstado);
                listBox1.Items.Add("transaccionFechacreacion" + una.TransaccionFechaCreacion);
                listBox1.Items.Add("vehiculomatricula " + una.TransaccionVehiculoMatricula);
                //ahora veo si puedo recorrer las cargas y luego los items dentro de la carga
                listBox1.Items.Add(" *** las cargas ***" );
                foreach (var unacarga in una.TransaccionCargas)
                {
                    TransaccionLor ob = new TransaccionLor();
                    ob.Transaccionid = una.TransaccionId;
                    ob.Matriculacamion = una.TransaccionVehiculoMatricula;
                    ob.Cargaid = unacarga.CargaID;


                    listBox1.Items.Add(" unacarga"+unacarga.CargaID);
                    listBox1.Items.Add(" horasalida "+unacarga.CargaHoraSalida);
                    listBox1.Items.Add(" *** ahora los benditos articulos ***");
                    listBox1.Items.Add("             ID       CODIGO       NOMBRE           KILOS  ***");
                    foreach (var unarticulo in unacarga.CargaProductos)
                    {
                        Producto producto = new Producto { Codigo = unarticulo.CargaProductoCodigo, Nombre = unarticulo.CargaProductoNombre, Peso= unarticulo.CargaProductoPeso,  Productoid=Convert.ToInt32(unarticulo.CargaProductoID) };
                        ob.Productos.Add(producto);
                        ob.Totalkilos +=unarticulo.CargaProductoPeso;
                        listBox1.Items.Add("             "+ unarticulo.CargaProductoID+"   " + unarticulo.CargaProductoCodigo+"  "+unarticulo.CargaProductoNombre+"    Kg "+unarticulo.CargaProductoPeso);
                    }
                    Listadetransacciones.Add(ob);


                }

            }


            
            grillaTramsacciones.DataSource = Listadetransacciones;
            grillaTramsacciones.Columns["Totalkilos"].DefaultCellStyle.Format =  "N";
            return 0;
        }





        private void actualizarDespositosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bajo de la web los deepositos y los meto en la base de datos y en el combo
            Actualizodepositos();
        }
        public void Actualizodepositos() 
        {
        var cliente= AuxiliarServicio.obtenerClienteWS();   


        }

        private void grillaTramsacciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //al hacer click saco la factura de esa transaccion
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }
    }

}
