﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

using APIformbuilder.Models;
using APIformbuilder.Service.Interface;
using static System.Net.WebRequestMethods;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using Dapper;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Runtime.ConstrainedExecution;
using APIformbuilder.Service.Concrete;
using System.Xml.Linq;
using System.ServiceModel;
using static APIformbuilder.Controllers.ConsultarWsController;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;






namespace APIformbuilder.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]

    public class ConsultarWsController : ControllerBase
    //public class ConsultarWsController
    {
        private readonly string cadenaSQL;
        public ConsultarWsController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        /// <summary>
        /// *******AUditar
        /// </summary>
        /// <param name="pObra"></param>
        /// <param name="pCodigo"></param>
        /// <param name="pElemento"></param>
        /// <param name="pCaras"></param>
        /// <returns></returns>
        /// ***********
        //*******ValidaCara
        [HttpGet]
        [Route("Auditar")]
        public async Task<IActionResult> Auditar(string pMatricula, string pObra, string pDNI, string pElemento, string pCara, string pPractica, string pBarra, string pNombreAfi, string pUnico, string pCoseguro, string pUnicoCoseguro, string pFV)
        {
            WsColOdont.ArrayOfXElement respuesta = null;
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2000000;  // Ajusta el tamaño según lo que necesites
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxStringContentLength = 2000000,
                MaxArrayLength = 16384
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;  // No autenticación en este caso, ajusta si es necesario
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(1);

            var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com:3002/WsColOdon/service.asmx");

            WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);            
            string xmlString = await ws.Auditar_ColmedAsync(pMatricula, pObra, pDNI, pElemento, pCara, pPractica,  pBarra, pNombreAfi, pUnico,  pCoseguro, pUnicoCoseguro, pFV);
            var nomencladores = new List<res>();
            if (xmlString != null && xmlString != null)
            {
                nomencladores.Add(new res
                {

                    nombre = xmlString



                });
            }

                  

            return Ok(nomencladores);

        }

        public class res
        {
            public string nombre { get; set; }
        }
        //*******ValidaCara
        [HttpGet]
        [Route("ValidaCara")]
        public async Task<IActionResult> ValidaCara(string pObra, string pCodigo, string pElemento, string pCaras)
        {
            WsColOdont.ArrayOfXElement respuesta = null;
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2000000;  // Ajusta el tamaño según lo que necesites
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxStringContentLength = 2000000,
                MaxArrayLength = 16384
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;  // No autenticación en este caso, ajusta si es necesario
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(1);

            var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com:3002/WsColOdon/service.asmx");

            WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);
            respuesta = await ws.ValidaCarasAsync(pObra,  pCodigo,  pElemento,  pCaras);

            var nomencladores = new List<ValidaCaraVC>();
            XNamespace diffgramNamespace = "urn:schemas-microsoft-com:xml-diffgram-v1";

            foreach (var node in respuesta.Nodes)
            {
                // Verificar si el nodo es 'diffgram'
                if (node.Name.LocalName == "diffgram" && node.Name.NamespaceName == diffgramNamespace.NamespaceName)
                {
                    // Buscar el elemento 'NewDataSet' sin espacio de nombres
                    var newDataSet = node.Element("NewDataSet");

                    if (newDataSet != null)
                    {
                        // Buscar todos los elementos 'nomenclador.dbf'
                        foreach (var item in newDataSet.Elements("b_ordenes.dbf"))
                        {

                            var matriprofElement = item.Element("nombre");
                            


                            var nombre = matriprofElement?.Value.Trim();
                            

                            if (nombre != null && nombre != null)
                            {
                                nomencladores.Add(new ValidaCaraVC
                                {

                                    nombre = nombre



                                });
                            }
                        }
                    }
                }
            }

            return Ok(nomencladores);

        }

        public class ValidaCaraVC
        {
            public string nombre { get; set; }
        }
        //*******ConsultaAutorizados
        [HttpGet]
        [Route("ConsultaAutorizados")]
        public async Task<IActionResult> ConsultaAutorizados(string DniAfi, string CodObra, string Matri, string pCoseguro)
        {
            WsColOdont.ArrayOfXElement respuesta = null;
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2000000;  // Ajusta el tamaño según lo que necesites
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxStringContentLength = 2000000,
                MaxArrayLength = 16384
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;  // No autenticación en este caso, ajusta si es necesario
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(1);

            var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com:3002/WsColOdon/service.asmx");

            WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);
            respuesta = await ws.ConsultaAutorizadosAsync(DniAfi, CodObra, Matri, pCoseguro); 

            var nomencladores = new List<ListaConsultaAutorizados>();
            XNamespace diffgramNamespace = "urn:schemas-microsoft-com:xml-diffgram-v1";

            foreach (var node in respuesta.Nodes)
            {
                // Verificar si el nodo es 'diffgram'
                if (node.Name.LocalName == "diffgram" && node.Name.NamespaceName == diffgramNamespace.NamespaceName)
                {
                    // Buscar el elemento 'NewDataSet' sin espacio de nombres
                    var newDataSet = node.Element("NewDataSet");

                    if (newDataSet != null)
                    {
                        // Buscar todos los elementos 'nomenclador.dbf'
                        foreach (var item in newDataSet.Elements("b_ordenes.dbf"))
                        {
                            
                            var matriprofElement = item.Element("matriprof");
                            var dniafiElement = item.Element("dniafi");
                            var codobrElement = item.Element("codobr");
                            var autorizacionElement = item.Element("autorizacion");
                            var fecha_autoElement = item.Element("fecha_auto");
                            var practicaElement = item.Element("practica");
                            var nombre_practicaElement = item.Element("nombre_practica");
                            var dienteElement = item.Element("diente");
                            var caraElement = item.Element("cara");
                            

                            var matriprof = matriprofElement?.Value.Trim();
                            var dniafi = dniafiElement?.Value.Trim();
                            var codobr = codobrElement?.Value.Trim();
                            var autorizacion = autorizacionElement?.Value.Trim();
                            var fecha_auto = fecha_autoElement?.Value.Trim();
                            var practica = practicaElement?.Value.Trim();
                            var nombre_practica = nombre_practicaElement?.Value.Trim();
                            var diente = dienteElement?.Value.Trim();
                            var cara = caraElement?.Value.Trim();

                            if (dniafi != null && matriprof != null)
                            {
                                nomencladores.Add(new ListaConsultaAutorizados
                                {
                                    //matriprof = matriprof,
                                   // dniafi = dniafi,
                                    obra_social = codobr,
                                    autorizacion = autorizacion,
                                    fecha = fecha_auto.Substring(0, 10),
                                    practica = practica,
                                    nombre_practica= nombre_practica,
                                    elemento = diente,
                                    cara = cara



                                });
                            }
                        }
                    }
                }
            }

            return Ok(nomencladores);
        }
        public class ListaConsultaAutorizados
        {
            //public string matriprof { get; set; }
            
            public string obra_social { get; set; }
            public string autorizacion { get; set; }
            public string fecha { get; set; }
            public string practica { get; set; }
            public string nombre_practica { get; set; }
            public string elemento { get; set; }
            public string cara { get; set; }
        }
        ///******************************

        //*******Buscar Datos Afiliados
        [HttpGet]
        [Route("BuscarDatosAfiliado")]
        public async Task<IActionResult> BuscarDatosAfiliado(string pDni)
        {
            WsColOdont.ArrayOfXElement respuesta = null;
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2000000;  // Ajusta el tamaño según lo que necesites
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxStringContentLength = 2000000,
                MaxArrayLength = 16384
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;  // No autenticación en este caso, ajusta si es necesario
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(1);

            var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com:3002/WsColOdon/service.asmx");

            WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);
            respuesta = await ws.BuscarDatosAfiliadoAsync(pDni); //ws.NomencladorAsync();

            var nomencladores = new List<Datos>();
            XNamespace diffgramNamespace = "urn:schemas-microsoft-com:xml-diffgram-v1";

            foreach (var node in respuesta.Nodes)
            {
                // Verificar si el nodo es 'diffgram'
                if (node.Name.LocalName == "diffgram" && node.Name.NamespaceName == diffgramNamespace.NamespaceName)
                {
                    // Buscar el elemento 'NewDataSet' sin espacio de nombres
                    var newDataSet = node.Element("NewDataSet");

                    if (newDataSet != null)
                    {
                        // Buscar todos los elementos 'nomenclador.dbf'
                        foreach (var item in newDataSet.Elements("Afiliados.dbf"))
                        {
                            var nombreElement = item.Element("nombre");
                            var barraElement = item.Element("barra");
                            var coseguroElement = item.Element("coseguro");
                            var fechabajaElement = item.Element("fechabaja");

                            var nombre = nombreElement?.Value.Trim();
                            var barra = barraElement?.Value.Trim();
                            var coseguro = coseguroElement?.Value.Trim();
                            var fechabaja = fechabajaElement?.Value.Trim();

                            if (nombre != null && barra != null)
                            {
                                nomencladores.Add(new Datos
                                {
                                    Nombre = nombre,
                                    Codigo = barra,
                                    Coseguro = coseguro,
                                    Fechabaja = fechabaja

                                });
                            }
                        }
                    }
                }
            }

            return Ok(nomencladores);
        }
        public class Datos
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public string Coseguro { get; set; }
            public string Fechabaja { get; set; }
        }
        //******Llamada a un WS
        [HttpGet]
        [Route("ListaNomenclador")]
        public async Task<IActionResult> ListaNomenclador()
        {

            //var binding = new BasicHttpBinding();
            //var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com/WsColOdon/service.asmx");
            //WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);
            //var ver  = await ws.NomencladorAsync();
            //return Ok(ver);
            WsColOdont.ArrayOfXElement respuesta = null;
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2000000;  // Ajusta el tamaño según lo que necesites
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxStringContentLength = 2000000,
                MaxArrayLength = 16384
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;  // No autenticación en este caso, ajusta si es necesario
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(1);

            var endpoint = new EndpointAddress("http://excelencia.myqnapcloud.com:3002/WsColOdon/service.asmx");

            WsColOdont.ServiceSoapClient ws = new WsColOdont.ServiceSoapClient(binding, endpoint);
            respuesta = await ws.NomencladorAsync();

            var nomencladores = new List<Nomenclador>();
            XNamespace diffgramNamespace = "urn:schemas-microsoft-com:xml-diffgram-v1";

            foreach (var node in respuesta.Nodes)
            {
                // Verificar si el nodo es 'diffgram'
                if (node.Name.LocalName == "diffgram" && node.Name.NamespaceName == diffgramNamespace.NamespaceName)
                {
                    // Buscar el elemento 'NewDataSet' sin espacio de nombres
                    var newDataSet = node.Element("NewDataSet");

                    if (newDataSet != null)
                    {
                        // Buscar todos los elementos 'nomenclador.dbf'
                        foreach (var item in newDataSet.Elements("nomenclador.dbf"))
                        {
                            var nombreElement = item.Element("nombre");
                            var codigoElement = item.Element("codigo");

                            var nombre = nombreElement?.Value.Trim();
                            var codigo = codigoElement?.Value.Trim();

                            if (nombre != null && codigo != null)
                            {
                                nomencladores.Add(new Nomenclador
                                {
                                    Nombre = nombre,
                                    Codigo = codigo
                                });
                            }
                        }
                    }
                }
            }

            return Ok(nomencladores);
        }
        public class Nomenclador
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }
        }

        [HttpGet]
        [Route("VerWs")]
        public async Task VerWs()
        {
            // Crear una instancia de la API
            var miApi = new MiApi();
            string rutaWebService = "https://abws.alfabeta.net/alfabeta-webservice/abWsDescargas/7733/polivalente/<parametros><ultimologMF></ultimologMF><ofertas>N</ofertas><basecompleta>S</basecompleta></parametros>";

            // Llamar al servicio web
            string resultado = await miApi.LlamarWebServiceAsync(rutaWebService);
            //*****************************************
            //*****************************************
            //*****************************************
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string escritorio = Path.GetDirectoryName(assemblyLocation);
            // Ruta completa del archivo XML
            string xmlFilePath = @"C:\AddWeb\Creador\APIformbuilder-master\bin\Debug\net6.0\respuesta.xml";

            // Crear un nuevo objeto XmlDocument
            XmlDocument xmlDoc = new XmlDocument();

            // Cargar el archivo XML
            xmlDoc.Load(xmlFilePath);
            // Obtener el valor del tag ultimolog
            XmlNode ultimologNode = xmlDoc.SelectSingleNode("/respuesta/basecompleta/ultimolog");
            string ultimologValue = ultimologNode.InnerText;
            // Iterar a través de los elementos del XML
            // Iterar sobre cada nodo <articulo>
            XmlNodeList articuloNodes = xmlDoc.SelectNodes("//articulo");
            
            //***************** //*****************
            //*********Grabar Tabla************
            //***************** //*****************
            string resultado_graba = "01";
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //var insertConfigFormSql = "insert INTO AlfaBetaDescarga values (getdate()); SELECT SCOPE_IDENTITY();";
                        var insertConfigFormSql = "insert INTO AlfaBetaDescarga (ultimolog) values (@log); SELECT SCOPE_IDENTITY();";
                        int configFormId = conexion.QuerySingle<int>(insertConfigFormSql, new
                        {
                            log = ultimologValue
                        }, transaction);
                        
                        foreach (XmlNode articuloNode in articuloNodes)
                        {
                            // Obtener el valor de los tags <nom>, <tro> y <bar> para cada <articulo>
                            string regValue = articuloNode.SelectSingleNode("reg").InnerText;
                            string nomValue = articuloNode.SelectSingleNode("nom").InnerText;
                            string prcValue = articuloNode.SelectSingleNode("prc").InnerText;
                            string presValue = string.Empty;
                            string troValue = string.Empty;
                            string barValue = string.Empty;
                            string vigValue = string.Empty;
                            string estValue = string.Empty;
                            string impValue = string.Empty;
                            string helValue = string.Empty;
                            string ivaValue = string.Empty;
                            string laboValue = string.Empty;
                            string tipovValue = string.Empty;
                            string saludValue = string.Empty;
                            string tamValue = string.Empty;
                            string forValue = string.Empty;
                            string viaValue = string.Empty;
                            string droValue = string.Empty;
                            string accValue = string.Empty;
                            string upotValue = string.Empty;
                            string potValue = string.Empty;
                            string uunitValue = string.Empty;
                            string unitValue = string.Empty;
                            string gravValue = string.Empty;
                            string celValue = string.Empty;
                           



                            // Verificar si el tag <tro> existe para el artículo actual
                            XmlNode troNode = articuloNode.SelectSingleNode("tro");
                            if (troNode != null)
                            {
                                troValue = troNode.InnerText;
                            }

                            // Obtener el valor del tag <bar> para cada <articulo>
                            XmlNode barNode = articuloNode.SelectSingleNode("bars/bar");
                            if (barNode != null)
                            {
                                barValue = barNode.InnerText;
                            }
                            // Obtener el valor del tag <pres> para cada <articulo>
                            XmlNode presNode = articuloNode.SelectSingleNode("pres");
                            if (presNode != null)
                            {
                                presValue = presNode.InnerText;
                            }
                            // Obtener el valor del tag <vig> para cada <articulo>
                            XmlNode vigNode = articuloNode.SelectSingleNode("vig");
                            if (vigNode != null)
                            {
                                vigValue = vigNode.InnerText;
                            }
                            // Obtener el valor del tag <est> para cada <articulo>
                            XmlNode estNode = articuloNode.SelectSingleNode("est");
                            if (estNode != null)
                            {
                                estValue = estNode.InnerText;
                            }
                            // Obtener el valor del tag <imp> para cada <articulo>
                            XmlNode impNode = articuloNode.SelectSingleNode("imp");
                            if (impNode != null)
                            {
                                impValue = impNode.InnerText;
                            }
                            // Obtener el valor del tag <imp> para cada <articulo>
                            XmlNode helNode = articuloNode.SelectSingleNode("hel");
                            if (helNode != null)
                            {
                                helValue = helNode.InnerText;
                            }
                            // Obtener el valor del tag <iva> para cada <articulo>
                            XmlNode ivaNode = articuloNode.SelectSingleNode("iva");
                            if (ivaNode != null)
                            {
                                ivaValue = ivaNode.InnerText;
                            }
                            // Obtener el valor del tag <labo> para cada <articulo>
                            XmlNode laboNode = articuloNode.SelectSingleNode("labo");
                            if (laboNode != null)
                            {
                                laboValue = laboNode.InnerText;
                            }
                            // Obtener el valor del tag <tipov> para cada <articulo>
                            XmlNode tipovNode = articuloNode.SelectSingleNode("tipov");
                            if (tipovNode != null)
                            {
                                tipovValue = tipovNode.InnerText;
                            }
                            // Obtener el valor del tag <tipov> para cada <articulo>
                            XmlNode saludNode = articuloNode.SelectSingleNode("salud");
                            if (saludNode != null)
                            {
                                saludValue = saludNode.InnerText;
                            }
                            // Obtener el valor del tag <tam> para cada <articulo>
                            XmlNode tamNode = articuloNode.SelectSingleNode("tam");
                            if (tamNode != null)
                            {
                                tamValue = tamNode.InnerText;
                            }
                            // Obtener el valor del tag <for> para cada <articulo>
                            XmlNode forNode = articuloNode.SelectSingleNode("for");
                            if (tamNode != null)
                            {
                                forValue = forNode.InnerText;
                            }
                            // Obtener el valor del tag <via> para cada <articulo>
                            XmlNode viaNode = articuloNode.SelectSingleNode("via");
                            if (viaNode != null)
                            {
                                viaValue = viaNode.InnerText;
                            }
                            // Obtener el valor del tag <dro> para cada <articulo>
                            XmlNode droNode = articuloNode.SelectSingleNode("dro");
                            if (droNode != null)
                            {
                                droValue = droNode.InnerText;
                            }
                            // Obtener el valor del tag <acc> para cada <articulo>
                            XmlNode accNode = articuloNode.SelectSingleNode("acc");
                            if (accNode != null)
                            {
                                accValue = accNode.InnerText;
                            }
                            // Obtener el valor del tag <upot> para cada <articulo>
                            XmlNode upotNode = articuloNode.SelectSingleNode("upot");
                            if (upotNode != null)
                            {
                                upotValue = upotNode.InnerText;
                            }
                            // Obtener el valor del tag <pot> para cada <articulo>
                            XmlNode potNode = articuloNode.SelectSingleNode("pot");
                            if (potNode != null)
                            {
                                potValue = potNode.InnerText;
                            }
                            // Obtener el valor del tag <uunit> para cada <articulo>
                            XmlNode uunitNode = articuloNode.SelectSingleNode("uunit");
                            if (uunitNode != null)
                            {
                                uunitValue = uunitNode.InnerText;
                            }
                            // Obtener el valor del tag <unit> para cada <articulo>
                            XmlNode unitNode = articuloNode.SelectSingleNode("uni");
                            if (unitNode != null)
                            {
                                unitValue = unitNode.InnerText;
                            }
                            // Obtener el valor del tag <grav> para cada <articulo>
                            XmlNode gravNode = articuloNode.SelectSingleNode("grav");
                            if (gravNode != null)
                            {
                                gravValue = gravNode.InnerText;
                            }
                            // Obtener el valor del tag <cel> para cada <articulo>
                            XmlNode celNode = articuloNode.SelectSingleNode("cel");
                            if (celNode != null)
                            {
                                celValue = celNode.InnerText;
                            }

                           

                            var insertFieldSql = "INSERT INTO AlfaBeta (Vigencia,Precio,Estado,Nombre,Presentacion,Importado,Heladera,Troquel,CodBarras,Iva,CodLab,TipoVenta,Tamano,NroRegistro,Unidades,Gravamen,Prospecto,IdMonodroga,via,forma,acc,gtin,cel, sno,c1, c2,c3,c4,descargaid) VALUES (@Vigencia,@Precio,@Estado,@Nombre,@Presentacion,@Importado,@Heladera,@Troquel,@CodBarras,@Iva,@CodLab,@TipoVenta,@Tamano,@NroRegistro,@Unidades,@Gravamen,@Prospecto,@IdMonodroga,@Via,@forma,@Acc,@Gtin,@Cel,@Sno,@C1,@C2,@C3,@C4,@descargaid)";
                            conexion.Execute(insertFieldSql, new
                            {

                                Nombre = nomValue,
                                Vigencia = vigValue,
                                Precio = prcValue,
                                Estado = estValue,
                               Presentacion = presValue,
                                Importado = impValue,
                                Heladera = helValue,
                                Troquel = troValue,
                                CodBarras = barValue,
                                Iva = ivaValue,
                                CodLab = laboValue,
                                TipoVenta = tipovValue,
                                Tamano = tamValue,
                                NroRegistro = regValue,
                                Unidades = unitValue,
                                Gravamen = gravValue,
                                Prospecto = "",
                                IdMonodroga = droValue,
                                Via = ivaValue,
                                forma = forValue,
                                Acc= accValue,
                                Gtin = "",
                                Cel = celValue,
                                Sno = "",
                                C1 = "",
                                C2 = "",
                                C3 ="",
                                C4 = "",
                                descargaid = configFormId
                                
                            }, transaction);
                        }

                        transaction.Commit();

                        // Devuelve el ID generado como respuesta HTTP 200 (éxito)
                        //return resultado =  "00";
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            //***************** //*****************
            //*****************FIN*************** 
            //***************** //*****************


        }
    }
    public class MiApi
    {
        private readonly HttpClient clienteHttp;
        private string projectDirectory;

        public MiApi()
        {
            clienteHttp = new HttpClient();
           clienteHttp.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/todos/1");
            string rutaWebService = "https://abws.alfabeta.net/alfabeta-webservice/abWsDescargas/7733/polivalente/<parametros><ultimologMF>XXXXXX</ultimologMF><basecompleta>S</basecompleta><solotablas>N</solotablas></parametros>";

        }

        
        
        
        public async Task<string> LlamarWebServiceAsync(string ruta)
        {
            string a1 = "";
            //string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //******************
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string escritorio = Path.Combine(desktopPath, "xml");
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string escritorio = Path.GetDirectoryName(assemblyLocation);
            //C:\AddWeb\Creador\APIformbuilder-master\bin\Debug\net6.0
            //escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            escritorio = @"C:\AddWeb\Creador\APIformbuilder-master\bin\Debug\net6.0\";

            //********

            string archivo = Path.Combine(escritorio, "respuesta.xml");
            string template =
           "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
           "xmlns:des=\"http://descargas.ws.webservice.alfabeta.net/\">" +
           "<soapenv:Header/>" +
           "<soapenv:Body>" +
           "<des:actualizar>" +
           "<id>:ID</id>" +
           "<clave>:CLAVE</clave>" +
           "<xml><![CDATA[:XML]]></xml>" +
           "</des:actualizar>" +
           "</soapenv:Body>" +
           "</soapenv:Envelope>";
            try
            {
                //************************ 

                string url = "https://abws.alfabeta.net/alfabeta-webservice/abWsDescargas";
                string id = "7733";
                string clave = "polivalente";
                //string xml = "<parametros><ultimologMF>"+ DateTime.Now.Year.ToString()+ DateTime.Now.Month.ToString().PadLeft(2,'0') +"</ultimologMF><basecompleta>S</basecompleta><solotablas>S</solotablas></parametros>";
                //string xml = "<parametros><ultimologMF>1234</ultimologMF><basecompleta>S</basecompleta><solotablas>S</solotablas></parametros>";
                string xml = "<parametros><ultimologMF></ultimologMF><ofertas>N</ofertas><basecompleta>S</basecompleta></parametros>";
                string body = template.Replace(":ID", id).Replace(":CLAVE", clave).Replace(":XML", xml);

                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Content = new StringContent(body, Encoding.UTF8, "text/xml");
                    request.Headers.Add("SOAPAction", "");
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            String respuestanueva = await response.Content.ReadAsStringAsync();
                           
                            int startIndex = respuestanueva.IndexOf("<return>") + "<return>".Length;
                            int endIndex = respuestanueva.IndexOf("</return>", startIndex);
                            string base64 = respuestanueva.Substring(startIndex, endIndex - startIndex);
                            
                            byte[] responseBytes = Convert.FromBase64String(base64);
                            byte[] datosTxt = new byte[0];
                            //************
                            using (MemoryStream zipStream = new MemoryStream(responseBytes))
                            {
                                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                                {
                                    ZipArchiveEntry? entry = archive.GetEntry("datos.txt");
                                    if (entry != null)
                                    {
                                        using (MemoryStream extractedFileStream = new MemoryStream())
                                        {
                                            using (Stream entryStream = entry.Open())
                                            {
                                                entryStream.CopyTo(extractedFileStream);
                                            }
                                            datosTxt = extractedFileStream.ToArray();
                                        }
                                    }
                                    else
                                    {
                                        a1="Error: datos.txt no se encuentra en el ZIP";
                                    }
                                }
                            }

                            await System.IO.File.WriteAllBytesAsync(archivo, datosTxt);
                            a1 = "Archivo descargado en ";
                            //************************




                            if (datosTxt.Length == 0)
                            {
                                 a1="Error: datos.txt no se encuentra en el ZIP";
                            }
                            using (var fileStream = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                            {
                                await fileStream.WriteAsync(datosTxt, 0, datosTxt.Length);
                            }
                             a1 = "Archivo descargado en " + respuestanueva;
                        }
                        else
                        {
                             a1 = "Error: " + response.StatusCode;
                        }
                    }
                    catch (Exception ex)
                    { }
                 }
                //***************************
              
    
                //***Estos sirve
                // Realizar la solicitud GET al servicio web
                HttpResponseMessage respuesta = await clienteHttp.GetAsync(ruta);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer y devolver la respuesta en formato JSON
                    return await respuesta.Content.ReadAsStringAsync();
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanzar una excepción o devolver un mensaje de error
                    return $"Error en la solicitud. Código de estado: {respuesta.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones en caso de errores
                return $"Error: {ex.Message}";
            }
        }

        //Novedades
      
        [HttpGet]
        [Route("VerWsNovedades")]
        public async Task VerWsNovedades()
        {
            // Crear una instancia de la API
            var miApi = new MiApi();
            string rutaWebService = "https://abws.alfabeta.net/alfabeta-webservice/abWsDescargas/7733/polivalente/<parametros><ultimologMF></ultimologMF><ofertas>N</ofertas><basecompleta>S</basecompleta></parametros>";

            // Llamar al servicio web
            string resultado = await miApi.LlamarWebServiceNovedadesAsync(rutaWebService);
        }

            public async Task<string> LlamarWebServiceNovedadesAsync(string ruta)
        {
            string a1 = "";
            //string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //******************
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string escritorio = Path.Combine(desktopPath, "xml");
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string escritorio = Path.GetDirectoryName(assemblyLocation);
            //C:\AddWeb\Creador\APIformbuilder-master\bin\Debug\net6.0
            //escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //********

            string archivo = Path.Combine(escritorio, "novedades.xml");
            string template =
           "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" " +
           "xmlns:des=\"http://descargas.ws.webservice.alfabeta.net/\">" +
           "<soapenv:Header/>" +
           "<soapenv:Body>" +
           "<des:actualizar>" +
           "<id>:ID</id>" +
           "<clave>:CLAVE</clave>" +
           "<xml><![CDATA[:XML]]></xml>" +
           "</des:actualizar>" +
           "</soapenv:Body>" +
           "</soapenv:Envelope>";
            try
            {
                //************************ 

                string url = "https://abws.alfabeta.net/alfabeta-webservice/abWsDescargas";
                string id = "7733";
                string clave = "polivalente";
                //string xml = "<parametros><ultimologMF>"+ DateTime.Now.Year.ToString()+ DateTime.Now.Month.ToString().PadLeft(2,'0') +"</ultimologMF><basecompleta>S</basecompleta><solotablas>S</solotablas></parametros>";
                //string xml = "<parametros><ultimologMF>1234</ultimologMF><basecompleta>S</basecompleta><solotablas>S</solotablas></parametros>";
                string xml = "<parametros><ultimologMF></ultimologMF><ofertas>N</ofertas><basecompleta>S</basecompleta></parametros>";
                string body = template.Replace(":ID", id).Replace(":CLAVE", clave).Replace(":XML", xml);

                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Content = new StringContent(body, Encoding.UTF8, "text/xml");
                    request.Headers.Add("SOAPAction", "");
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            String respuestanueva = await response.Content.ReadAsStringAsync();

                            int startIndex = respuestanueva.IndexOf("<return>") + "<return>".Length;
                            int endIndex = respuestanueva.IndexOf("</return>", startIndex);
                            string base64 = respuestanueva.Substring(startIndex, endIndex - startIndex);

                            byte[] responseBytes = Convert.FromBase64String(base64);
                            byte[] datosTxt = new byte[0];
                            //************
                            using (MemoryStream zipStream = new MemoryStream(responseBytes))
                            {
                                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                                {
                                    ZipArchiveEntry? entry = archive.GetEntry("datos.txt");
                                    if (entry != null)
                                    {
                                        using (MemoryStream extractedFileStream = new MemoryStream())
                                        {
                                            using (Stream entryStream = entry.Open())
                                            {
                                                entryStream.CopyTo(extractedFileStream);
                                            }
                                            datosTxt = extractedFileStream.ToArray();
                                        }
                                    }
                                    else
                                    {
                                        a1 = "Error: datos.txt no se encuentra en el ZIP";
                                    }
                                }
                            }

                            await System.IO.File.WriteAllBytesAsync(archivo, datosTxt);
                            a1 = "Archivo descargado en ";
                            //************************




                            if (datosTxt.Length == 0)
                            {
                                a1 = "Error: datos.txt no se encuentra en el ZIP";
                            }
                            using (var fileStream = new FileStream(archivo, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                            {
                                await fileStream.WriteAsync(datosTxt, 0, datosTxt.Length);
                            }
                            a1 = "Archivo descargado en " + respuestanueva;
                        }
                        else
                        {
                            a1 = "Error: " + response.StatusCode;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
                //***************************


                //***Estos sirve
                // Realizar la solicitud GET al servicio web
                HttpResponseMessage respuesta = await clienteHttp.GetAsync(ruta);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer y devolver la respuesta en formato JSON
                    return await respuesta.Content.ReadAsStringAsync();
                }
                else
                {
                    // Si la solicitud no fue exitosa, lanzar una excepción o devolver un mensaje de error
                    return $"Error en la solicitud. Código de estado: {respuesta.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones en caso de errores
                return $"Error: {ex.Message}";
            }
        }
    }
}
