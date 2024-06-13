using System.Net;
using System;
using System.Net.Http.Json;
using ServiceReference1;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Transactions;
using System.Drawing.Printing;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Text;
using System.Text;

namespace SRGA_GUIAS
{

    public partial class Form1 : Form
    {
        int CARGAIDAIMPRIMIR = 0;

        public void probarconexion()
        {
            Datosplanta datos = new Datosplanta();
            SqlConnection cn = new();

            try
            {
                cn = datos.conecatar();


            }
            catch (Exception j)
            {

                MessageBox.Show(j.Message);

            }

            SqlCommand cmd = new SqlCommand("select top 5 * from [10.0.0.1].lorsinalsa.dbo.tropas where fecha='2022-10-07'", cn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                listBox1.Items.Add(dr.GetString("clave") + " " + dr.GetInt64("productor"));

            }

            cn.Close();

        }


        //**********
        public async Task codiguera()
        {
            try
            {
                var cliente = AuxiliarServicio.obtenerClienteWS();

                //var input = new VerProductosCodigueraSDT { ProductoCodigo = "1" };
                var input = new VerProductosCodigueraSDT { IdEspecie = 1 };
                var respuesta = cliente.VERPRODUCTOSCODIGUERAAsync(new VERPRODUCTOSCODIGUERARequest(input));

                await respuesta;
                //label1.Text = ($"Exito de los codigos? {respuesta.Result.Resultado.Exito}");

                List<Producto> listaprod = new List<Producto>();
                foreach (var d in respuesta.Result.Wssdtinfoproductos)
                {
                    Producto uno = new Producto();
                    uno.Codigo = d.Codigo;
                    // uno.Idespecie = d.IdEspecie;
                    uno.Nombre = d.Nombre;
                    //uno.NombreCodigo = d.NombreCodigo;
                    //uno.NombreEspecie = d.NombreEspecie;

                    listaprod.Add(uno);
                    //                    listBox1.Items.Add("id_especie " + d.IdEspecie + " nombre " + d.Nombre + " nombreespecie " + d.NombreEspecie);

                }
                GRILLA.DataSource = listaprod;
            }
            catch (Exception e)
            {
                listBox1.Items.Add("Error " + e.Message);
            }
        }


        public async Task Aduanas()
        {
            try
            {
                var cliente = AuxiliarServicio.obtenerClienteWS();

                var respuesta = cliente.OBTENERADUANASAsync(new OBTENERADUANASRequest());
                listBox1.Items.Add($"Exito de los codigos? {respuesta.Result.Resultado.Exito}");

                foreach (var mensaje in respuesta.Result.Resultado.Mensajes)
                {
                    listBox1.Items.Add($"Mensaje: {mensaje.Description}");
                }



                GRILLA.DataSource = respuesta.Result.Lista_wsaduanasdt;

                List<Producto> listaprod = new List<Producto>();
                foreach (var d in respuesta.Result.Lista_wsaduanasdt)
                {
                    //wsAduanaSDT una

                }
                //GRILLA.DataSource = listaprod;
            }
            catch (Exception e)
            {
                listBox1.Items.Add("Error " + e.Message);
            }
        }



        //**********
        public Form1()
        {
            InitializeComponent();
        }



        private async void button2_Click(object sender, EventArgs e)
        {
            //  codiguera();
            Aduanas();

        }

        public long NuevaTransaccion(int vehiculo)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();

            var input = new CrearVentaDirectaSDT { VehiculoNroHabilitacion = vehiculo, EmpresaRut = 214494550018 };
            var respuesta = cliente.CREARTRANSACCIONVENTADIRECTAAsync(new CREARTRANSACCIONVENTADIRECTARequest(input));
            //en la respuesta tengo el id
            //y si fue exitosa la creascion

            respuesta.Wait();


            //MessageBox.Show("exito " + respuesta.Result.Resultado.Exito);
            listBox1.Items.Add("Nueva transaccion es " + respuesta.Result.Resultado.Exito);
            long transaccionid = respuesta.Result.Transaccionid;
            //MessageBox.Show("transaccionid " + transaccionid);
            listBox1.Items.Add("transaccionid " + transaccionid);
            return transaccionid;

        }

        //venta en planchada
        private long NuevaTransaccionPlanchada(long rutreceptor,string remito,List<Producto> misproductos)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var input = new CrearVentaPlanchadaSDT { MonedaCodigo="UYU", ReceptorEmpresaRut=rutreceptor, Remito=remito, PlantaDepositoNroHab="224"};

            var listaAuxiliar = new List<CargaProductosVentaPlanchadaSDTCargaProductosVentaPlanchadaSDTItem>();
            //agrego a la lista
            //listaAuxiliar.Add(uno);

            //agrego item que creaste al CrearCargaSDT

            //usando la lista parametro
            foreach (var producto in misproductos)
            {
                //agrego a la lista auxiliar
                listaAuxiliar.Add(
                    new CargaProductosVentaPlanchadaSDTCargaProductosVentaPlanchadaSDTItem
                    {
                        ProductoCodigo = producto.Codigo,
                        ProductoPeso = producto.Peso
                    }
                );
            }
            //cargo el array usando la lista auxiliar
            input.Productos = listaAuxiliar.ToArray();
            var respuesta = cliente.CREARTRANSACCIONVENTAPLANCHADAAsync(new CREARTRANSACCIONVENTAPLANCHADARequest(input));
            //en la respuesta tengo el id
            //y si fue exitosa la creascion

            respuesta.Wait();


            //MessageBox.Show("exito " + respuesta.Result.Resultado.Exito);
            listBox1.Items.Add("Nueva transaccion venta planchada es " + respuesta.Result.Resultado.Exito);
            long transaccionid = respuesta.Result.Transaccionid;
            //MessageBox.Show("transaccionid " + transaccionid);
            listBox1.Items.Add("transaccionid " + transaccionid);
            return transaccionid;

        }




        public long NuevaTransaccionADUANA(int aduana, string matricula)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var input = new CrearTrasladoHaciaAduanaSDT { AduanaCodigo = aduana, EmpresaRUT = 214494550018, Matricula = matricula };
            var respuesta = cliente.CREARTRANSACCIONTRASLADOHACIAADUANAAsync(new CREARTRANSACCIONTRASLADOHACIAADUANARequest(input));
            //en la respuesta tengo el id
            //y si fue exitosa la creascion

            respuesta.Wait();


            //MessageBox.Show("exito " + respuesta.Result.Resultado.Exito);
            listBox1.Items.Add("Nueva transaccion es " + respuesta.Result.Resultado.Exito);
            long transaccionid = respuesta.Result.Transaccionid;
            //MessageBox.Show("transaccionid " + transaccionid);
            listBox1.Items.Add("transaccionid " + transaccionid);
            return transaccionid;

        }



        


        private long Nuevacarga(long transaccionid, List<Producto> misproductos)
        {
            //genero una carga con la transaccion
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var datos = new CrearCargaSDT { PlantaDepositoNroHab = "224", TransaccionId = transaccionid, EmpresaRut = 214494550018 };
            //var uno = new CargaProductosSDTCargaProductosSDTItem { ProductoCodigo = "1121041", ProductoPeso = 100 };

            //usamos una lista auxiliar, mas facil de manejar
            var listaAuxiliar = new List<CargaProductosSDTCargaProductosSDTItem>();
            //agrego a la lista
            //listaAuxiliar.Add(uno);

            //agrego item que creaste al CrearCargaSDT

            //usando la lista parametro
            foreach (var producto in misproductos)
            {
                //agrego a la lista auxiliar
                listaAuxiliar.Add(
                    new CargaProductosSDTCargaProductosSDTItem
                    {
                        ProductoCodigo = producto.Codigo,
                        ProductoPeso = producto.Peso
                    }
                );
            }
            //cargo el array usando la lista auxiliar
            datos.Productos = listaAuxiliar.ToArray();

            var respuesta = cliente.CREARCARGAAsync(new CREARCARGARequest(datos));

            // await respuesta;

            foreach (var mensaje in respuesta.Result.Resultado.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }

            if (respuesta.Result.Resultado.Exito)
            {
                return respuesta.Result.Cargaid;
            }
            else
            {
                //no se de donde sacar el mensaje de error
                listBox1.Items.Add(new Exception($"Error") + " error al crear carga  ");
                return 0;
            }
        }



        public async Task otra()
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var respuesta = cliente.OBTENERDEPOSITOSAsync(new OBTENERDEPOSITOSRequest("1"));
            await respuesta;


            //label1.Text =($"Exito? {respuesta.Result.Resultado.Exito}");
            foreach (var d in respuesta.Result.Lista_wsplantadepositosdt)
            {
                // listBox1.Items.Add("rut "+d.LocalEmpresaRut);
                // listBox1.Items.Add(" nombre" + d.EmpresaDenominacion);
                //listBox1.Items.Add("departa " + d.LocalDepartamentoNombre);
                //listBox1.Items.Add("habit " + d.LocalNroHab);
                listBox1.Items.Add("denomina " + d.EmpresaDenominacion);
            }
        }

        public void mandaraxcel()
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in GRILLA.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in GRILLA.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel
            string folderPath = "C:\\Tmp\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");
                wb.SaveAs(folderPath + "DataGridViewExport.xlsx");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mandaraxcel();

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (combocargas.SelectedItem != null)
            {
                int CARGAID = int.Parse(combocargas.SelectedItem.ToString());
                //verifico si la carga fue enviada mirando la base de datos de las guias

                if (combodestino.Text == "VENTA PLANCHADA")
                {
                   // long vp = NuevaTransaccionPlanchada();
                }
                else

                Nueva(CARGAID);

            }
            else { MessageBox.Show("no se ha elegido carga para enviar"); }

        }


        //public async Task Nueva(int cargaid)
        public Boolean Nueva(int cargaid)
        {
            //primero levanto los productos de la carga, si está todo ok entonces envio la transaccion y la carga
            Datosplanta datos = new Datosplanta();
            if (datos.CargaYaEnviada(cargaid))
            {
                MessageBox.Show("esa carga ya fue enviada");
                return false;

            }


            List<Producto> misproductos = new List<Producto>();
            misproductos = datos.Devproductos1carga(cargaid);

            if (misproductos.Count > 0)
            {
                //si hay articulos entonces arranco la transaccion
                //tengo que sacar el nro de habilitacion del camion segun la matricula
                //levanto los datos de la carga
                Abasto carga = new();
                carga = datos.DevDatos1Carga(cargaid);

                int nHabilitacion = datos.DevCamion(carga.matricula);

                if (nHabilitacion == 0)
                {
                    List<Camion> camiones = datos.DevCamiones();
                    string opciones = "";

                    foreach (Camion uno in camiones)
                    {

                        opciones = opciones + uno.NroHabilitacion + " " + uno.Matricula + "\n";
                    }

                    string respuesta = Interaction.InputBox("no se encontró la matricula del camion, elija una de ellas \n" + opciones);

                    if (Convert.ToInt32(respuesta) == 0) { return false; }
                    else
                    {
                        nHabilitacion = Convert.ToInt32(respuesta);
                    }


                }
                //ver aquí si el nro de matricula está bien

                long nt = NuevaTransaccion(nHabilitacion);
                listBox1.Items.Add("transaccion " + nt);
                if (nt == 0)
                {
                    return false;
                }
                //si est'a todo ok

                //ahora voy a crear una carga con esa transacción
                // long nc = await Nuevacarga(nt, misproductos);
                long nc = Nuevacarga(nt, misproductos);
                //guardo en la base de datos la carga y la transaccion 
                if (nc == 0) {
                    listBox1.Items.Add("no se pudo crear la carga");
                    //deberia aca jesus eliminar la transaccion
                    return false;
                }
                listBox1.Items.Add("carga nro " + nc);

                CargaEnviada cargaEnviada = new CargaEnviada();

                cargaEnviada.cargaid = cargaid;
                cargaEnviada.transaccionid = (int)nt;
                cargaEnviada.nrocarga = (int)nc;

                try
                {
                    datos.GuardoCargaEnviada(cargaEnviada);
                }
                catch (Exception x)
                {

                    listBox1.Items.Add(x.Message);
                }
                //ahora habria que confirmat la carga
                Confirmocarga(nc);

                listBox1.Items.Add("carga enviada y confirmado ");


                return true;


            }
            else {
                MessageBox.Show("no hay articulos para mandar");
                return false;
            }


            //MessageBox.Show(nc+string.Empty);

        }



        public Boolean NuevaVentaPlanchada(int cargaid)
        {
            //primero levanto los productos de la carga, si está todo ok entonces envio la transaccion y la carga
            Datosplanta datos = new Datosplanta();
            if (datos.CargaYaEnviada(cargaid))
            {
                MessageBox.Show("esa carga ya fue enviada");
                return false;

            }


            List<Producto> misproductos = new List<Producto>();
            misproductos = datos.Devproductos1carga(cargaid);

            if (misproductos.Count > 0)
            {
                //si hay articulos entonces arranco la transaccion
                //tengo que sacar el nro de habilitacion del camion segun la matricula
                //levanto los datos de la carga
                Abasto carga = new();
                carga = datos.DevDatos1Carga(cargaid);


                //ver aquí si el nro de matricula está bien

                long nt = 9690; //NuevaTransaccionPlanchada(carga);
                listBox1.Items.Add("transaccion " + nt);
                if (nt == 0)
                {
                    return false;
                }
                //si est'a todo ok

                //ahora voy a crear una carga con esa transacción
                // long nc = await Nuevacarga(nt, misproductos);
                //long nc = Nuevacarga(nt, misproductos);
                //guardo en la base de datos la carga y la transaccion 
                if (nt == 0)
                {
                    listBox1.Items.Add("no se pudo crear la carga");
                    //deberia aca jesus eliminar la transaccion
                    return false;
                }
                listBox1.Items.Add("carga nro " + nt);

                CargaEnviada cargaEnviada = new CargaEnviada();

                cargaEnviada.cargaid = cargaid;
                cargaEnviada.transaccionid = (int)nt;
                cargaEnviada.nrocarga = (int)nt;

                try
                {
                    datos.GuardoCargaEnviada(cargaEnviada);
                }
                catch (Exception x)
                {

                    listBox1.Items.Add(x.Message);
                }
                //ahora habria que confirmat la carga
                Confirmocarga(nt);

                listBox1.Items.Add("carga enviada y confirmado ");


                return true;


            }
            else
            {
                MessageBox.Show("no hay articulos para mandar");
                return false;
            }


            //MessageBox.Show(nc+string.Empty);

        }




        public void Confirmocarga(long cargaid)
        {
            //voy a confirmar la carga
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var datos = new ConfirmarCargaSDT { CargaId = cargaid, EmpresaRut = 214494550018 };
            var respuesta = cliente.CONFIRMARCARGA(datos);
            foreach (var mensaje in respuesta.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }
            listBox1.Items.Add("exito" + respuesta.Exito);
        }



        private void button6_Click(object sender, EventArgs e)
        {

            //probarconexion();
            Datosplanta datos = new Datosplanta();

            CargaEnviada cargaEnviada = new CargaEnviada();
            cargaEnviada.cargaid = 6952;
            cargaEnviada.nrocarga = 0;
            cargaEnviada.transaccionid = 3045;

            try
            {
                datos.GuardoCargaEnviada(cargaEnviada);

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);

            }

            string cargaid = Interaction.InputBox("ing nro de carga");
            List<Producto> lista = datos.Devproductos1carga(int.Parse(cargaid));
            foreach (Producto uno in lista)
            {
                listBox1.Items.Add(uno.Nombre + " " + uno.Peso);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            codiguera();
            return;

            //al cargarse, levanto las cargas abiertas y sin mandar
            Datosplanta dato = new Datosplanta();
            List<int> cargas = dato.devcargas1estado();
            foreach (var item in cargas)
            {
                combocargas.Items.Add(item);
            }

            combodestino.Items.Add("VENTA DIRECTA");
            combodestino.Items.Add("VENTA PLANCHADA");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //cambiar la matricula del camion de una carga

            var cliente = AuxiliarServicio.obtenerClienteWS();
            //    var datos = new ModificarVentaDirectaSDT { EmpresaRut =214494550018, TransaccionId=4222, VehiculoNroHabilitacion = 6291 };
            //   var respuesta =cliente.MODIFICARTRANSACCIONVENTADIRECTA(datos);
            //  foreach (var mensaje in respuesta.Mensajes)
            // {
            //    listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            // }

            //listBox1.Items.Add(" valor de exito" +respuesta.Exito);

            //eliminar una carga   ok
            // var respuesta2 = cliente.ELIMINARCARGA(214494550018,63451);
            //foreach (var mensaje in respuesta2.Mensajes)
            //{
            //   listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            //}
            //listBox1.Items.Add(" valor de exito" + respuesta2.Exito);

            //*crear venta directa y eliminarla
            // long ne = NuevaTransaccion(0);
            //'borrarla'

            //var respuesta3 = cliente.ELIMINARTRANSACCION(214494550018, 4230);
            //listBox1.Items.Add(" valor de exito" + respuesta3.Exito);


            //*anular una transaccion
            //var respuesta4 = cliente.ANULARTRANSACCION(214494550018, 4232);
            //listBox1.Items.Add(" valor de exito" + respuesta4.Exito);
            //foreach (var mensaje in respuesta4.Mensajes)
            // {
            //   listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            //}

            //*modificar una carga iniciada
            //genero una carga con la transaccion
            //            var datos = new ModificarCargaSDT { PlantaDepositoNroHab = "224", CargaId=63459,  EmpresaRut = 214494550018 };
            //var uno = new CargaProductosSDTCargaProductosSDTItem { ProductoCodigo = "1121041", ProductoPeso = 100 };

            //usamos una lista auxiliar, mas facil de manejar
            var listaAuxiliar = new List<CargaProductosSDTCargaProductosSDTItem>();
            //agrego a la lista
            //CargaProductosSDTCargaProductosSDTItem uno = new();
            //uno.ProductoCodigo = "1124017";
            //uno.ProductoPeso = 666;
            //listaAuxiliar.Add(uno);
            //agrego item que creaste al CrearCargaSDT
            // listaAuxiliar.Add(
            //               new CargaProductosSDTCargaProductosSDTItem
            //             {
            //               ProductoCodigo = "1124017",
            //             ProductoPeso = 666
            //       }
            // );

            //cargo el array usando la lista auxiliar
            //datos.Productos = listaAuxiliar.ToArray();

            //var respuesta = cliente.MODIFICARCARGAINICIADA(datos);


            //se agregan productos a la carga iniciada

            // var datos = new AgregarProductoCargaSDT { CargaId = 63459, EmpresaRut = 214494550018 };

            //listaAuxiliar.Add(
            //      new CargaProductosSDTCargaProductosSDTItem
            //    {
            //      ProductoCodigo = "1128005",
            //    ProductoPeso = 44.32
            //}
            //);
            //listaAuxiliar.Add(
            //      new CargaProductosSDTCargaProductosSDTItem
            //    {
            //      ProductoCodigo = "2120021",
            //    ProductoPeso = 55.44
            //}
            //);

            //          

            //cargo el array usando la lista auxiliar
            //  datos.Productos = listaAuxiliar.ToArray();
            // var respuesta6 = cliente.AGREGARPRODUCTOCARGAINICIADAAsync(datos);
            //listBox1.Items.Add("se agregaron productos " + respuesta6.Result.Resultado.Mensajes);

            //* crear una descarga de productos

            var datos = new wsCrearDescargaSDT { EmpresaRUT = 214494550018, TransaccionId = 4235, Remito = "123", Observacion = "observ", MonedaCodigo = "UYU" };
            var listadescarga = new List<CrearDescargaProductosSDTCrearDescargaProductosSDTItem>();
            listadescarga.Add(new CrearDescargaProductosSDTCrearDescargaProductosSDTItem { CargaProductoID = 2, CargaId = 63459, ProductoCodigo = "1128005", ProductoPeso = 44.32 });
            listadescarga.Add(new CrearDescargaProductosSDTCrearDescargaProductosSDTItem { CargaProductoID = 3, CargaId = 63459, ProductoCodigo = "2120021", ProductoPeso = 55.44 });
            listadescarga.Add(new CrearDescargaProductosSDTCrearDescargaProductosSDTItem { CargaProductoID = 1, CargaId = 63459, ProductoCodigo = "1124017", ProductoPeso = 666 });

            datos.Descargas = listadescarga.ToArray();

            var respuesta = cliente.DESCARGAPLANTAAsync(new DESCARGAPLANTARequest(datos, 73, 216923760015));

            long descargaid = respuesta.Result.Descargaid;

            listBox1.Items.Add("resultado de la descarga " + respuesta.Result.Resultado.Exito);
            listBox1.Items.Add("descargaid " + descargaid);
            foreach (var mensaje in respuesta.Result.Resultado.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }





        }

        public void ModificoTransaccionAduana(int aduana, string matricula, long transaccion)
        {

            var cliente = AuxiliarServicio.obtenerClienteWS();
            //modifico la transaccion
            var datos = new ModificarTrasladoHaciaAduanaSDT { EmpresaRUT = 214494550018, AduanaCodigo = aduana, Matricula = matricula, TransaccionId = transaccion };
            var respuesta = cliente.MODIFICARTRANSACCIONTRASLADOHACIAADUANA(datos);
            
            foreach (var mensaje in respuesta.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }
        }
        public void eliminotransaccion(long transaccion)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            //elimino 

            var respuesta3 = cliente.ELIMINARTRANSACCION(214494550018, transaccion);
            listBox1.Items.Add(" valor de exito al eliminiar la transac" + respuesta3.Exito);

        }

        public void Finalizotransaccionaduana(long transaccion)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            //finalizo la transaccion
            var datos = new FinalizarTrasladoHaciaAduanaSDT { TransaccionId = transaccion, EmpresaRUT = 214494550018 };
            var respuesta = cliente.FINALIZARTRANSACCIONTRASLADOHACIAADUANA(datos);

            foreach (var mensaje in respuesta.Mensajes)
            {
                listBox1.Items.Add($"Mensaje: {mensaje.Description}");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {

            //para las aduanas
            //creo transacccion 
            //long transaccionidaduana = NuevaTransaccionADUANA(7,"jjj1234");
            //listBox1.Items.Add("transacion aduana " +transaccionidaduana);
            // ModificoTransaccionAduana(7, "jjj1234", 4277);
            // eliminotransaccion(4277);
            //List<Producto> productos = new List<Producto>();
            //productos.Add(new Producto { Codigo = "1127002", peso = 12000 });
            //long nc = Nuevacarga(4281, productos);
            //listBox1.Items.Add("nrocarga id"+nc);   

            //Confirmocarga(63519);
            Finalizotransaccionaduana(4281);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //imprimo informe de una cargaid.Para eso levanto los datos de planta de la carga
            //y bajo la información de inac

            //CARGAIDAIMPRIMIR = int.Parse(combocargas.SelectedItem.ToString());
            //ImprimoInforme();
            Datosplanta ds=new Datosplanta();   

            CargaEnviada carga = ds.devdatos1cargaenviada(CARGAIDAIMPRIMIR);

            //otiene la url de la transacción y genera el qr en el imbgenbox
            obtengoqr(carga.transaccionid);

            //despues de obtener el qr, lo imprimo
            ImprimoInforme();


        }

        public void obtengoqr(long trasaccionid)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            //
           // var datos = new FinalizarTrasladoHaciaAduanaSDT { TransaccionId = transaccion, EmpresaRUT = 214494550018 };
            //var respuesta = cliente.ob

        }


        public void ImprimoInforme()
        {
            List<Producto> productos = new List<Producto>();

            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += imprimirQR;
            printDocument1.Print();

        }
        private void imprimirQR(object sender, PrintPageEventArgs e)
        {
             e.Graphics.DrawImage(pictureBox1.Image, 0, 0,200,200);
        }



        private void imprimir(object sender, PrintPageEventArgs e)
        {


            Datosplanta ds = new Datosplanta();
            List<Producto> productos = ds.Devproductos1carga(CARGAIDAIMPRIMIR);
            //tengo la lista de productos, ahora imprimo el informe
            CargaEnviada carga = ds.devdatos1cargaenviada(CARGAIDAIMPRIMIR);
            // rptcargaabasto r;



            System.Drawing.Font fuente = new System.Drawing.Font("Arial", 12);
            int ancho = 550;
            int y = 20;
            e.Graphics.DrawString("ID de la Transacción: " + carga.transaccionid, fuente, Brushes.Black, new System.Drawing.RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("ID de la carga: " + carga.nrocarga, fuente, Brushes.Black, new System.Drawing.Rectangle(0, y += 20, ancho, 20));


            e.Graphics.DrawString("CODIGO   PRODUCTO ", fuente, Brushes.Black, new System.Drawing.RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("PESO", fuente, Brushes.Black, new System.Drawing.RectangleF(400, y, 200, 20));

            double total = 0;

            foreach (Producto producto in productos)
            {
                y += 30;
                e.Graphics.DrawString(producto.Codigo + " " + producto.Nombre, fuente, Brushes.Black, new System.Drawing.RectangleF(0, y, ancho, 20));
                e.Graphics.DrawString(String.Format("{0,10:N2}", producto.Peso), fuente, Brushes.Black, new System.Drawing.RectangleF(400, y, 200, 20));

                total += producto.Peso;

            };
            y += 30;

            e.Graphics.DrawString("Total de kilos ", fuente, Brushes.Black, new System.Drawing.RectangleF(0, y, ancho, 20));
            e.Graphics.DrawString(String.Format("{0,10:N2}", total), fuente, Brushes.Black, new System.Drawing.RectangleF(400, y, 200, 20));

            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);


        }

        private void button10_Click(object sender, EventArgs e)
        {

            var expo = new FrmDescarga();
            expo.ShowDialog();
        }

        private void combodestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var expo = new FrmExportacion();
            expo.ShowDialog();


        }

        private void combocargas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int carga = int.Parse(combocargas.SelectedItem.ToString());

            MostrarDatosCArga(carga);
        }



        public class xarticulo
        { 
            public string? codigo { get; set; }
        public string? nombre { get; set; }
            public double peso { get; set; }   


        }
        public void MostrarDatosCArga(int cargaid)
        {
 
            Datosplanta ds = new Datosplanta();
            List<Producto> productos=ds.Devproductos1carga(cargaid);
            List<xarticulo> xarticulos = new();
            foreach (Producto p in productos)
            {
                xarticulos.Add(new xarticulo { codigo = p.Codigo , nombre = p.Nombre, peso = p.Peso  });

            }

            grillacarga.DataSource=xarticulos;

        }
    }
     

    }
