using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SRGA_GUIAS
{
    internal class Datosplanta
    {
        public SqlConnection conecatar()

        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=10.0.0.1\sqlexpress;Database=loralmacen;User Id=sa;Password=Palindromo2;";
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return cn;


        }

        public List<Producto> Devproductos1carga(int cargaid)
        {
            SqlConnection cn = conecatar();
            string ordensql = @"select a.nombre,a.articuloid,a.codigoinac2,d.kilos,d.precio from [10.0.0.1].lorsinalsa.dbo.subpro_abastodetalle d inner join [10.0.0.1].lorsinalsa.dbo.subpro_articulos a on a.articuloid=d.articuloid          where d.cargaid=" + cargaid + " order by a.inacguias,a.nombre";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            List<Producto> lista = new List<Producto>();

            while (dr.Read())
            {
                Producto uno = new();
                uno.Nombre = dr.GetString("nombre");
                uno.Codigo = dr.GetString("codigoinac2");
                uno.Peso = Decimal.ToDouble(dr.GetDecimal("kilos"));
                lista.Add(uno);
            }

            cn.Close();


            return lista;

        }
        public Abasto DevDatos1Carga(int cargaid)
        {

            SqlConnection cn = conecatar();
            string ordensql = @"select * from [10.0.0.1].lorsinalsa.dbo.SUBPRO_abasto where cargaid=" + cargaid + ";";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            Abasto uno = new Abasto();
            while (dr.Read())
            {

                uno.fecha = dr.GetDateTime("fecha");
                uno.matricula = dr.GetString("matriculacamion");
                uno.cargaid = cargaid;


            }
            cn.Close();

            return uno;


        }

        public List<int> devcargas1estado()
        {
            List<int> lista = new List<int>();

            SqlConnection cn = conecatar();
            string ordensql = @"select cargaid from [10.0.0.1].lorsinalsa.dbo.SUBPRO_abasto where estado=0 order by cargaid";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                lista.Add(dr.GetInt32("cargaid"));

            }
            cn.Close();

            return lista;



        }
        public Boolean CargaYaEnviada(long cargaid)
        {
            
            SqlConnection cn = conecatar();
            string ordensql = @"select cargaid from [10.0.0.1].lorsinalsa.dbo.SUBPRO_guias_cargas_enviadas where cargaid=@cargaid";
            
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.Parameters.AddWithValue("@cargaid",cargaid);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            Boolean lista = false;
            while (dr.Read())
            {

                if (dr.GetInt32("cargaid") != 0) lista = true;

            }
            cn.Close();

            return lista;

        }

        public Boolean CerrarCargaLorsinal(long transaccionid, long nrocarga)
        {
            {

                SqlConnection cn = conecatar();
                string ordensql = @"select cargaid from [10.0.0.1].lorsinalsa.dbo.SUBPRO_guias_cargas_enviadas
 where transaccionid=@transaccionid and nrocarga=@nrocarga";

                SqlCommand cmd = new SqlCommand(ordensql, cn);
                cmd.Parameters.AddWithValue("@transaccionid", transaccionid);
                cmd.Parameters.AddWithValue("@nrocarga", nrocarga);
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                Boolean lista = false;
                string xcargaid="0";
                while (dr.Read())
                {

                    if (dr.GetInt32("cargaid") != 0)
                    {
                        lista = true;
                        xcargaid=dr.GetInt32("cargaid").ToString();
                        
                    }

                }
                dr.Close();
                ordensql = @"update  [10.0.0.1].lorsinalsa.dbo.subpro_abasto set estado=1 where cargaid=" + xcargaid;
                cmd.CommandText = ordensql;
                cmd.ExecuteNonQuery();
                cn.Close();

                return lista;

            }

        }
        public List<Aduana> DevAduanas()
        {
            List<Aduana> lista = new List<Aduana>();

            SqlConnection cn = conecatar();
            string ordensql = @"select aduanacodigo,aduananombre from [10.0.0.1].lorsinalsa.dbo.SRGA_Aduanas order by aduananombre";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Aduana uno = new Aduana();
                uno.Aduananombre = dr.GetString("aduananombre");
                uno.Aduanacodigo = dr.GetInt32("aduanacodigo");
                lista.Add(uno);



            }
            cn.Close();

            return lista;



        }

        public void GuardoCargaEnviada(CargaEnviada carga)
        {
            SqlConnection cn = conecatar();

            string commandString = "insert into [10.0.0.1].lorsinalsa.dbo.SUBPRO_GUIAS_CARGAS_ENVIADAS (CARGAID,TRANSACCIONID,NROCARGA)  values (@cargaid,@transaccionid,@nrocarga)";
            SqlCommand cmd = new SqlCommand(commandString, cn);

            cmd.Parameters.AddWithValue("@cargaid", carga.cargaid);
            cmd.Parameters.AddWithValue("@transaccionid", carga.transaccionid);
            cmd.Parameters.AddWithValue("@nrocarga", carga.nrocarga);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public CargaEnviada devdatos1cargaenviada(int cargaid)
        {
            SqlConnection cn = conecatar();

            string commandString = "select * from [10.0.0.1].lorsinalsa.dbo.SUBPRO_GUIAS_CARGAS_ENVIADAS where cargaid=@cargaid";
                SqlCommand cmd = new SqlCommand(commandString, cn);
            cmd.Parameters.AddWithValue("@cargaid",cargaid);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            CargaEnviada obj = new CargaEnviada();

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.cargaid = cargaid;
                    obj.transaccionid= dr.GetInt32("transaccionid");
                    obj.nrocarga = dr.GetInt32("nrocarga");
                }
                cn.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);

            }

            
            return obj; 
            

        }
       
        public int DevCamion(string matricula)
        {
            matricula = matricula.Replace(" ", "");

            SqlConnection cn = conecatar();
            string ordensql = @"select nrohabilitacion from [10.0.0.1].lorsinalsa.dbo.SUBPRO_GUIAS_CAMIONES where matricula='" + matricula + "';";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            int lista = 0;

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista = dr.GetInt32("nrohabilitacion");
                }
                cn.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);

            }



            return lista;


        }

        public List<Camion> DevCamiones()
        {
            
            SqlConnection cn = conecatar();
            string ordensql = @"select * from [10.0.0.1].lorsinalsa.dbo.SUBPRO_GUIAS_CAMIONES";
            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
            List<Camion> lista =new();


            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add( new Camion { Id=dr.GetInt32("id"), 
                        Matricula=dr.GetString("matricula"), 
                        NroHabilitacion=dr.GetInt32("nrohabilitacion") });
                }
                cn.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);

            }



            return lista;


        }




        public List<Destino> DevDestinos()
        {
           
            SqlConnection cn = conecatar();
        string ordensql = @"select C.COMPRADORRUC,D.compradorid,D.nombredestino,D.tipo,d.destinoid,C.nrohabilitacion  from [10.0.0.1].lorsinalsa.dbo.SUBPRO_GUIAS_destinos D INNER JOIN [10.0.0.1].lorsinalsa.dbo.SUBPRO_COMPRADORES C ON C.COMPRADORID=D.COMPRADORID";
        SqlCommand cmd = new SqlCommand(ordensql, cn);
        cmd.CommandType = CommandType.Text;
            SqlDataReader dr;
        List<Destino>lista = new List<Destino>();

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   

                    Destino obj =new Destino { Depositoid=dr.GetInt32("destinoid"), Rutreceptor=long.Parse(dr.GetString("compradorruc")), Compradorid = dr.GetInt32("compradorid"), Tipodestino = dr.GetInt32("tipo"), Nombredestino = dr.GetString("nombredestino"), Nrohabilitacion =dr.GetInt32("nrohabilitacion") };   

                 
                    
                    lista.Add(obj); 
                  
                }
    cn.Close();
            }
            catch (Exception x)
{

    MessageBox.Show(x.Message);

}



return lista;


        }

        public List<Producto> DevProductos1romaneo(string romaneo)
        {
            List<Producto> productos = new List<Producto>();

            SqlConnection cn = conecatar();
            string ordensql = @"select r.articulo as codigolor,p.nombre as nombrelor,i.nombre,i.codigoinac,sum(r.pesoneto) as peso 
from  [10.0.0.1].lorsinalsa.dbo.romaneodecarga r inner join  [10.0.0.1].lorsinalsa.dbo.prod_productos pr on pr.codigo=r.articulo
inner join  [10.0.0.1].lorsinalsa.dbo.productos p on p.codigo=r.articulo
inner join  [10.0.0.1].lorsinalsa.dbo.subpro_productosinac2 i on i.codigoinac=pr.codigoinac2 
where r.romaneo=" + romaneo + " group by r.articulo,p.nombre,i.nombre,i.codigoinac order by r.articulo,p.nombre,i.nombre,i.codigoinac";

            SqlCommand cmd = new SqlCommand(ordensql, cn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr;

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto uno = new();
                    uno.Codigo = dr.GetString("codigoinac");
                    uno.Nombre = dr.GetString("nombre");
                    uno.CodigoLor = dr.GetString("codigolor");
                    uno.Peso = decimal.ToDouble(dr.GetDecimal("peso"));
                    uno.Nombrelor = dr.GetString("nombrelor");
                    productos.Add(uno);

                }
                cn.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);

            }


            return productos;
        }

        public long Nuevacarga(long transaccionid, List<Producto> misproductos)
        {
            //genero una carga con la transaccion
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var datos = new CrearCargaSDT { PlantaDepositoNroHab = "224", TransaccionId = transaccionid, EmpresaRut = 214494550018 };
            //usamos una lista auxiliar, mas facil de manejar
            var listaAuxiliar = new List<CargaProductosSDTCargaProductosSDTItem>();
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

            if (respuesta.Result.Resultado.Exito)
            {
                return respuesta.Result.Cargaid;
            }
            else
            {
                //no se de donde sacar el mensaje de error
                //    listBox1.Items.Add(new Exception($"Error") + " error al crear carga  ");
                return 0;
            }
        }

        public Boolean Confirmocarga(long cargaid)
        {
            //voy a confirmar la carga
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var datos = new ConfirmarCargaSDT { CargaId = cargaid, EmpresaRut = 214494550018 };
            var respuesta = cliente.CONFIRMARCARGA(datos);
            return respuesta.Exito;
        }

        public Boolean Finalizotransaccionaduana(long transaccion)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            //finalizo la transaccion
            var datos = new FinalizarTrasladoHaciaAduanaSDT { TransaccionId = transaccion, EmpresaRUT = 214494550018 };
            var respuesta = cliente.FINALIZARTRANSACCIONTRASLADOHACIAADUANA(datos);
            return respuesta.Exito;
        }
        public Boolean FinalizarTransaccion(long transaccion)
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();
            //finalizo la transaccion
            var respuesta = cliente.FINALIZARTRANSACCION(214494550018, transaccion);
            return respuesta.Exito;
        }

        //***************
        public long DescargaenPlantaID(long transaccionid, long cargaid, List<Producto> misproductos, string remito, string observaciones, long destinoid, long rucreceptor)
        
        {
            var cliente = AuxiliarServicio.obtenerClienteWS();

            var datos = new wsCrearDescargaSDT { EmpresaRUT = 214494550018, TransaccionId = transaccionid, Remito = remito, Observacion = observaciones, MonedaCodigo = "UYU" };
            var listadescarga = new List<CrearDescargaProductosSDTCrearDescargaProductosSDTItem>();

            foreach (var producto in misproductos)
            {
                //agrego a la lista auxiliar
                listadescarga.Add(
                    new CrearDescargaProductosSDTCrearDescargaProductosSDTItem
                    {
                        CargaId = cargaid,
                        ProductoCodigo = producto.Codigo,
                        ProductoPeso = producto.Peso,
                        ProductoPrecio = 0,
                        CargaProductoID = producto.Productoid

                    }
                );
            }

            datos.Descargas = listadescarga.ToArray();

            var respuesta = cliente.DESCARGAPLANTAAsync(new DESCARGAPLANTARequest(datos, destinoid, rucreceptor));

            respuesta.Wait();


            long descargaid = respuesta.Result.Descargaid;

            if (respuesta.Result.Resultado.Exito)
            {
                return descargaid;
            }
            else
            {
                return 0;
            }

        }


        //**************


        public Boolean FinalizarDescarga(long descargaid)
        {
            //voy a confirmar la carga
            var cliente = AuxiliarServicio.obtenerClienteWS();
            var respuesta = cliente.FINALIZARDESCARGA(214494550018,descargaid,"","","");
            return respuesta.Exito;
        }


        public List<Producto> DevArticulos1transaccion1carga(long traID, long Carid)
        {
            
                var cliente = AuxiliarServicio.obtenerClienteWS();
                   
                 var respuesta = cliente.VERTRANSACCIONAsync(new VERTRANSACCIONRequest { Empresarut= 214494550018,  Transaccionid= traID });
            
            respuesta.Wait();

             wsTransaccionSDT transascs = respuesta.Result.Wstransaccionsdt;

            List<Producto> misproductos = new List<Producto>();
                //recorro, cuando encuentre la carga, traigo los articulos
                foreach (var unacarga in  transascs.TransaccionCargas)
                 {
                    //verifico si es la carga que estoy buscando
                    if (unacarga.CargaID == Carid)
                    {
                        foreach (var unarticulo in unacarga.CargaProductos)
                        {
                            Producto producto = new Producto { Codigo = unarticulo.CargaProductoCodigo, Nombre = unarticulo.CargaProductoNombre, Peso = unarticulo.CargaProductoPeso, Productoid = Convert.ToInt32(unarticulo.CargaProductoID) };
                            misproductos.Add(producto); 

                        }
                    }
                    
                 }
            return misproductos;

         }
              
            
    }
}
