using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using APIformbuilder.Models;
using Microsoft.AspNetCore.Cors;
using Dapper;
using System.Text;




namespace APIformbuilder.Controllers
{
    [EnableCors("ReglasCorse")]
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]


   

    public class ConfigFormController : ControllerBase
    {
        private readonly string cadenaSQL;
        public ConfigFormController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        //***************************************
        //***************************************
        //*********LLAMADA A WS******************




        //***************************************
        //***************************************
        //***************************************

        //***************LISTAR FORMULARIOS MENU**************
        [HttpGet]
        [Route("ListaFormulariosMenu")]
        public IActionResult ListaFormMenu()
        {
            List<ConfigFormMenu> lista = new List<ConfigFormMenu>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ObtenerFormulariosMenu", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ConfigFormMenu()
                            {
                                IdConfigForm = Convert.ToInt32(rd["ID"]),
                                Titulo = rd["Titulo_Formulario"].ToString(),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************Buscar  Articulos**************
        [HttpGet]
        [Route("BuscarArticulos")]
        public IActionResult BuscarArticulos(int pTipo, string pNombre)
        {
            List<ListarArticulosTodos> lista = new List<ListarArticulosTodos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("BuscaArticulosNombre", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pNombre", pNombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarArticulosTodos()
                            {
                                articulosid = Convert.ToInt32(rd["articulosid"]),
                                codigo = rd["codigo"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                precio = Convert.ToDecimal(rd["precio"]),
                                nroregistro = rd["nroregistro"].ToString(),
                                tipomedicamentos = rd["tipomedicamentos"].ToString(),
                                sector = rd["sector"].ToString(),
                                stockminimo = rd["stockminimo"].ToString(),
                                stockmedio = rd["stockmedio"].ToString(),
                                stockmaximo = rd["stockmaximo"].ToString(),
                                troquel = rd["troquel"].ToString(),
                                codbarra = rd["codbarra"].ToString()

                            }); ; ;
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR Consumo**************
        [HttpGet]
        [Route("ListarConsumo")]
        public IActionResult ListarConsumo(int pTipo)
        {
            List<ListarConsumo> lista = new List<ListarConsumo>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarConsumo", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarConsumo()
                            {
                                consumoid = Convert.ToInt32(rd["consumoid"]),
                                codigoarticulo = rd["codigoarticulo"].ToString(),
                                nomarticulo = rd["nomarticulo"].ToString(),
                                NInternado = rd["NInternado"].ToString(),
                                fecha = rd["fecha"].ToString(),
                                dosis = rd["dosis"].ToString(),
                                detalleInternado = rd["detalleInternado"].ToString(),
                                cantidad = rd["cantidad"].ToString(),
                                precio = rd["precio"].ToString(),
                                receta = rd["receta"].ToString()
                                

                            }); ; ;
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        //***************LISTAR ArticulosTODOS**************
        [HttpGet]
        [Route("ListarArticulosTodos")]
        public IActionResult ListarArticulosTodos(int pTipo)
        {
            List<ListarArticulosTodos> lista = new List<ListarArticulosTodos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarArticulosTodos", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarArticulosTodos()
                            {
                                articulosid = Convert.ToInt32(rd["articulosid"]),
                                codigo = rd["codigo"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                precio = Convert.ToDecimal(rd["precio"]),
                                nroregistro = rd["nroregistro"].ToString(),
                                tipomedicamentos = rd["tipomedicamentos"].ToString(),
                                sector = rd["sector"].ToString(),
                                stockminimo = rd["stockminimo"].ToString(),
                                stockmedio = rd["stockmedio"].ToString(),
                                stockmaximo = rd["sockmedio"].ToString(),
                                troquel = rd["troquel"].ToString(),
                                codbarra = rd["codbarra"].ToString()

                            }); ; ;
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************
        //***************LISTAR Articulos**************
        [HttpGet]
        [Route("ListarArticulos")]
        public IActionResult ListarArticulos(int pTipo)
        {
            List<ListarArticulos> lista = new List<ListarArticulos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarArticulos", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarArticulos()
                            {
                                articulosid = Convert.ToInt32(rd["articulosid"]),
                                codigo = rd["codigo"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                precio = Convert.ToDecimal(rd["precio"]),
                                 nroregistro = rd["nroregistro"].ToString()
                               // institucionid = Convert.ToInt32(rd["institucionid"])

                            }); ; ;
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        //*****************************************************************************************************
        //***************LISTAR AlfaBeta**************
        [HttpGet]
        [Route("ListaAlfaBeta")]
        public IActionResult ListaAlfaBeta(int pTipo)
        {
            List<ListaAlfaBeta> lista = new List<ListaAlfaBeta>();
            try
            {
              

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListaAlfaBeta", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaAlfaBeta()
                            {
                                troquel = rd["troquel"].ToString(),
                                CodBarras = rd["CodBarras"].ToString(),
                                NroRegistro = rd["NroRegistro"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                presentacion = rd["presentacion"].ToString(),
                                Unidades = rd["Unidades"].ToString(),
                                IdMonodroga = rd["IdMonodroga"].ToString(),
                                CodLab = rd["CodLab"].ToString(),
                                Laboratorio = rd["Laboratorio"].ToString(),
                                Monodroga = rd["Monodroga"].ToString(),
                                precio = rd["precio"].ToString()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //---------------------------Lista Alfa Beta por nombre -------------------------------------
        //-----------------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("BuscaAlfaBetaNombre")]
        public IActionResult BuscaAlfaBetaNombre(string pNombre)
        {
            List<ListaAlfaBeta> lista = new List<ListaAlfaBeta>();
            try
            {


                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("BuscaAlfaBetaNombre", conexion);
                    cmd.Parameters.AddWithValue("@pNombre", pNombre.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaAlfaBeta()
                            {
                                troquel = rd["troquel"].ToString(),
                                CodBarras = rd["CodBarras"].ToString(),
                                NroRegistro = rd["NroRegistro"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                presentacion = rd["presentacion"].ToString(),
                                Unidades = rd["Unidades"].ToString(),
                                IdMonodroga = rd["IdMonodroga"].ToString(),
                                CodLab = rd["CodLab"].ToString(),
                                Laboratorio = rd["Laboratorio"].ToString(),
                                Monodroga = rd["Monodroga"].ToString(),
                                precio = rd["precio"].ToString()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        //***************LISTAR ListaMedicamentos Clinicas**************
        [HttpGet]
        [Route("ListarMedicamentosClinicas")]
        public IActionResult ListarMedicamentosClinicas(int pIdClinica)
        {
            List<Listarmedicamentosclinicas> lista = new List<Listarmedicamentosclinicas>();
            try
            {



                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarMedicamentosClinicas", conexion);
                    cmd.Parameters.AddWithValue("@pIdClinica", pIdClinica);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Listarmedicamentosclinicas()
                            {
                                // IdArticulo = rd["IdArticulo"].ToString(),
                                // Nombre = rd["Nombre"].ToString(),
                                // Codigo = rd["Codigo"].ToString(),
                                //Tipo_Articulo = rd["Tipo_Articulo"].ToString(),
                                //Precio_Venta = rd["Precio_Venta"].ToString(),
                                //Precio_Costo = rd["Precio_Costo"].ToString(),
                                //Modifica_Manual = rd["Modifica_Manual"].ToString(),
                                //Stock_Maximo = rd["Stock_Maximo"].ToString(),
                                //Stock_Medio = rd["Stock_Medio"].ToString(),
                                //Stock_Minimo = rd["Stock_Minimo"].ToString(),
                                //Troquel = rd["Troquel"].ToString(),
                                //Barra = rd["Barra"].ToString(),
                                //Descartable_art = rd["Descartable_art"].ToString(),
                                //Urgencia = rd["Urgencia"].ToString(),
                                //Gastosnn = rd["Gastosnn"].ToString(),
                                //SinCargo = rd["SinCargo"].ToString(),
                                //Afacturar = rd["Afacturar"].ToString(),
                                //SinCargoIn = rd["SinCargoIn"].ToString(),
                                //AfacturarIn  = rd["AfacturarIn"].ToString(),
                                //Anulado = rd["Anulado"].ToString(),
                                //IdInstitucion = rd["IdInstitucion"].ToString(),
                                 
                                Id_ConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
                                Id_Field = Convert.ToInt32(rd["Id_Field"]),
                                Id_Answer = Convert.ToInt32(rd["Id_Answer"]),
                                nombre = rd["nombre"].ToString(),
                                valor = rd["valor"].ToString(),
                                identificador_fila = Convert.ToInt32(rd["identificador_fila"]),




                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        //***************LISTAR ListaMedicamentos**************
        [HttpGet]
        [Route("ListaMedicamentos")]
        public IActionResult ListaMedicamentos(int pIdClinica, string pIdUsuario, string pIdPass)
        {
            List<ListaAlfaBeta> lista = new List<ListaAlfaBeta>();
            try
            {
                


                    using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarMedicamentos", conexion);
                    cmd.Parameters.AddWithValue("@pIdClinica", pIdClinica);
                    cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                    cmd.Parameters.AddWithValue("@pIdPass", pIdPass);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaAlfaBeta()
                            {
                                troquel = rd["troquel"].ToString(),
                                CodBarras = rd["CodBarras"].ToString(),
                                NroRegistro = rd["NroRegistro"].ToString(),
                                nombre = rd["nombre"].ToString(),
                                presentacion = rd["presentacion"].ToString(),
                                Unidades = rd["Unidades"].ToString(),
                                IdMonodroga = rd["IdMonodroga"].ToString(),
                                CodLab = rd["CodLab"].ToString(),
                                precio = rd["precio"].ToString()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************
        //***************LISTAR CAMPOS STRING**************
        [HttpGet]
        [Route("ListaCamposString")]
        public IActionResult ListaCamposString(int pTipo)
        {
            List<ListaCamposString> lista = new List<ListaCamposString>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCampos", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposString()
                            {
                                string_id = Convert.ToInt32(rd["string_id"]),
                                default_value = rd["default_value"].ToString(),
                                value_list = rd["value_list"].ToString(),
                                mask_library=  rd["mask_library"].ToString(),
                                assumed_value = rd["assumed_value"].ToString(),
                                length = Convert.ToInt32(rd["length"])
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR CAMPOS Combo**************
        [HttpGet]
        [Route("ListaField")]
        public IActionResult ListaField(int pTipo)
        {
            List<ListaField> lista = new List<ListaField>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListaField", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaField()
                            {
                                Id_Field = Convert.ToInt32(rd["Id_Field"]),
                                nombre = rd["nombre"].ToString(),
                                opciones = rd["opciones"].ToString(),
                                posi = rd["posi"].ToString(),
                                ver = rd["ver"].ToString(),
                                urlapi = rd["urlapi"].ToString(),
                                orden = rd["orden"].ToString()

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR Combo**************
        [HttpGet]
        [Route("ListaCombo")]
        public IActionResult ListaCombo(int pTipo, int pId)
        {
            List<ListarCombo> lista = new List<ListarCombo>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCombo", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarCombo()
                            {
                                codigo = Convert.ToInt32(rd["codigo"]),
                                nombre = rd["nombre"].ToString(),
                                campo = rd["urlapi"].ToString().Trim()

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************
        //***************LISTAR CAMPOS STRING**************
        [HttpGet]
        [Route("ListaCamposText")]
        public IActionResult ListaCamposText(int pTipo)
        {
            List<ListaCamposText> lista = new List<ListaCamposText>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarText", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposText()
                            {
                                text_id = Convert.ToInt32(rd["text_id"]),
                                text_value = rd["text_value"].ToString(),
                                default_value = rd["default_value"].ToString(),
                                value_list = rd["value_list"].ToString(),
                                assumed_value = rd["assumed_value"].ToString(),
                                editable = Convert.ToInt32(rd["editable"])
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR CAMPOS Date**************
        [HttpGet]
        [Route("ListaCamposDate")]
        public IActionResult ListaCamposDate(int pTipo)
        {
            List<ListaCamposDate> lista = new List<ListaCamposDate>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarDate", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposDate()
                            {
                                date_id = Convert.ToInt32(rd["date_id"]),
                                enable_format = Convert.ToInt32(rd["enable_format"]),
                                use_date_format = Convert.ToInt32(rd["use_date_format"]),
                                date_format = rd["date_format"].ToString(),
                                value_list = rd["value_list"].ToString(),
                                use_range = Convert.ToInt32(rd["use_range"]),
                                upper_bound = Convert.ToInt32(rd["upper_bound"]),
                                upper_date = Convert.ToDateTime(rd["upper_date"]),
                                lower_bound = Convert.ToInt32(rd["lower_bound"]),
                                lower_date = Convert.ToDateTime(rd["lower_date"]),
                                assume_value = Convert.ToDateTime(rd["assume_value"])
                                
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR CAMPOS Date**************
        [HttpGet]
        [Route("ListaCamposDateTime")]
        public IActionResult ListaCamposDateTime(int pTipo)
        {
            List<ListaCamposDateTime> lista = new List<ListaCamposDateTime>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarDateTime", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposDateTime()
                            {
                                datetime_id = Convert.ToInt32(rd["datetime_id"]),
                                enable_format = Convert.ToInt32(rd["enable_format"]),
                                date_format = rd["date_format"].ToString(),
                                use_date_format = Convert.ToInt32(rd["use_date_format"]),
                                time_format = rd["time_format"].ToString(),
                                value_list = Convert.ToDateTime(rd["value_list"]),
                                use_range = Convert.ToInt32(rd["use_range"]),
                                upper_bound = Convert.ToInt32(rd["upper_bound"]),
                                upper_date = Convert.ToDateTime(rd["upper_date"]),
                                upper_time = rd["upper_time"].ToString(),
                                lower_bound = Convert.ToInt32(rd["lower_bound"]),
                                lower_date = Convert.ToDateTime(rd["lower_date"]),
                                lower_time = rd["lower_time"].ToString(),
                                assume_value = rd["assume_value"].ToString(),
                                use_time_format = Convert.ToInt32(rd["use_time_format"]),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************
        //***************LISTAR CAMPOS Integer**************
        [HttpGet]
        [Route("ListaCamposInteger")]
        public IActionResult ListaCamposInteger(int pTipo)
        {
            List<ListaCamposInteger> lista = new List<ListaCamposInteger>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCamposInteger", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposInteger()
                            {
                                integer_id = Convert.ToInt32(rd["integer_id"]),
                                default_value = Convert.ToInt32(rd["default_value"]),
                                value_list = rd["value_list"].ToString(),
                                min_configuration = rd["min_configuration"].ToString(),
                                min_value = Convert.ToInt32(rd["min_value"]),
                                max_configuration = rd["max_configuration"].ToString(),
                                max_value = Convert.ToInt32(rd["max_value"]),
                                assumed_value = Convert.ToInt32(rd["assumed_value"])

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************
        //***************LISTAR CAMPOS Double**************
        [HttpGet]
        [Route("ListaCamposDoble")]
        public IActionResult ListaCamposDouble(int pTipo)
        {
            List<ListaCamposDouble> lista = new List<ListaCamposDouble>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCamposDouble", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposDouble()
                            {
                                double_id = Convert.ToInt32(rd["double_id"]),
                                default_value = Convert.ToInt32(rd["default_value"]),
                                value_list = rd["value_list"].ToString(),
                                min_configuration = rd["min_configuration"].ToString(),
                                min_value = Convert.ToInt32(rd["min_value"]),
                                max_configuration = rd["max_configuration"].ToString(),
                                max_value = Convert.ToInt32(rd["max_value"]),
                                assumed_value = Convert.ToInt32(rd["assumed_value"])

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR CAMPOS Double**************
        [HttpGet]
        [Route("ListaCamposBoolean")]
        public IActionResult ListaCamposBoolean(int pTipo)
        {
            List<ListaCamposBoolean> lista = new List<ListaCamposBoolean>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCamposBoolean", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposBoolean()
                            {
                                boolean_id = Convert.ToInt32(rd["boolean_id"]),
                                true_value = Convert.ToInt32(rd["true_value"]),
                                false_value = Convert.ToInt32(rd["false_value"]),
                                assumed_value = rd["assumed_value"].ToString()
                                

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR CAMPOS Double**************
        [HttpGet]
        [Route("ListaCamposLabel")]
        public IActionResult ListaCamposLabel(int pTipo)
        {
            List<ListaCamposLabel> lista = new List<ListaCamposLabel>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarCamposLabel", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposLabel()
                            {
                                label_id = Convert.ToInt32(rd["label_id"]),
                                text_value = rd["text_value"].ToString(),
                                default_value = rd["default_value"].ToString(),
                                assumed_value = rd["assumed_value"].ToString()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR GRILLAS**************
        [HttpGet]
        [Route("ListaGrillas")]
        public IActionResult ListaGrillas(int pTipo)
        {
            List<ListaGrillas> lista = new List<ListaGrillas>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarGrillas", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaGrillas()
                            {
                                idConfigForm = Convert.ToInt32(rd["grillaid"]),
                                urlmodi = rd["urlmodi"].ToString().Trim(),                               
                                metodo = rd["metodo"].ToString().Trim()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR BOTONES**************
        [HttpGet]
        [Route("ListaBotones")]
        public IActionResult ListaBotones(int pTipo)
        {
            List<ListaBotones> lista = new List<ListaBotones>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarBotones", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaBotones()
                            {
                                idConfigForm = Convert.ToInt32(rd["botonesid"]),
                                metodo = rd["metodo"].ToString().Trim(),
                                texto = rd["texto"].ToString().Trim(),
                                color = rd["color"].ToString().Trim(),
                                icono = rd["icono"].ToString().Trim()


                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //-----------------------------------------------------
        //------------------------------------------------------
        //-------Agregar Tablas---------------------------
        [HttpPost]
        [Route("AgregarTablas/{formulario}/{Parametros}/{valores}")]
        public IActionResult AgregarTablas(string formulario, string Parametros, string valores)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("GrabarTablas", conexion);
                    cmd.Parameters.AddWithValue("@formulario", formulario);
                    cmd.Parameters.AddWithValue("@Parametros", Parametros);
                    cmd.Parameters.AddWithValue("@valores", valores);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Grabaron Exitosamente lod datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************LISTAR CAMPOS Double**************
        [HttpGet]
        [Route("ListaCamposTime")]
        public IActionResult ListaTime(int pTipo)
        {
            List<ListaCamposTime> lista = new List<ListaCamposTime>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListaCamposTime", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListaCamposTime()
                            {
                                time_id = Convert.ToInt32(rd["time_id"]),
                                enable_format = Convert.ToInt32(rd["enable_format"]),
                                use_time_format = Convert.ToInt32(rd["use_time_format"]),
                                 time_format = rd["time_format"].ToString(),
                                value_list = rd["value_list"].ToString(),
                                use_range = Convert.ToInt32(rd["use_range"]),
                                upper_bound = Convert.ToInt32(rd["upper_bound"]),
                                 upper_time = rd["upper_time"].ToString(),
                                lower_bound = Convert.ToInt32(rd["lower_bound"]),
                                lower_time = rd["lower_time"].ToString(),
                                assume_value = rd["assume_value"].ToString()
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR Tipos**************
        [HttpGet]
        [Route("ListaTipos")]
        public IActionResult ListaTipos(int pTipo, int @pId)
        {
            List<ListarTipos> lista = new List<ListarTipos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarTipos", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarTipos()
                            {
                                identificador = Convert.ToInt32(rd["identificador"]),
                                nombre = rd["nombre"].ToString()
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************LISTAR Tipos Registro**************
        [HttpGet]
        [Route("ListaTiposRegistro")]
        public IActionResult ListaTiposRegistro(int pTipo, int @pId)
        {
            List<ListarTipos> lista = new List<ListarTipos>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarTipos_Registro", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ListarTipos()
                            {
                                identificador = Convert.ToInt32(rd["identificador"]),
                                nombre = rd["nombre"].ToString()
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //***************Modifica Tbala**************
        [HttpPut]
        [Route("ModificarTabla/{formulario:int}/{Parametros}/{valores}")]
        public IActionResult ModificarTabla(int formulario, string Parametros, string valores)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificarTablas", conexion);
                    cmd.Parameters.AddWithValue("@formulario", formulario);
                    cmd.Parameters.AddWithValue("@Parametros", Parametros);
                    cmd.Parameters.AddWithValue("@valores", valores);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Modificado" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************ELIMINA  CAMPOS**************
        [HttpPut]
        [Route("EliminaCampos/{pTipo:int}/{pId:int}")]
        public IActionResult EliminaCampos(int pTipo, int pId)//
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("EliminaCampos", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "eliminado" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************
        //***************MODIFICA  CAMPOS Integer**************
        [HttpPut]
        [Route("ModificaCamposInteger/{pTipo:int}/{pId:int}/{pdefault_value}/{pvalue_list}/{pmin_configuration}/{pmin_value:int}/{pmax_configuration}/{pmax_value:int}/{passumed_value:int}")]
        public IActionResult ModificaCamposInteger(int pTipo, int pId, int pdefault_value, string pvalue_list, string pmin_configuration, int pmin_value, string pmax_configuration, int pmax_value, int passumed_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificaCamposInteger", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.Parameters.AddWithValue("@pdefault_value", pdefault_value);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@pmin_configuration", pmin_configuration);
                    cmd.Parameters.AddWithValue("@pmin_value", pmin_value);
                    cmd.Parameters.AddWithValue("@pmax_configuration", pmax_configuration);
                    cmd.Parameters.AddWithValue("@pmax_value", pmax_value);
                    cmd.Parameters.AddWithValue("@passumed_value", passumed_value);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Modificacion Exitosa" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************MODIFICA  Gield**************
        [HttpPut]
        [Route("ModificaField/{pTipo:int}/{pId_Field:int}/{pId_ConfigForm:int}/{pNombre}/{pOpcion}/{pOrden}/{pselectedItem}/{pselectedItemPosi}")]
        public IActionResult ModificaField(int pTipo, int pId_Field, int pId_ConfigForm, string pNombre, string pOpcion, string pOrden, string pselectedItem, string pselectedItemPosi)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificarField", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId_Field", pId_Field);
                    cmd.Parameters.AddWithValue("@pId_ConfigForm", pId_ConfigForm);
                    cmd.Parameters.AddWithValue("@pNombre", pNombre);
                    cmd.Parameters.AddWithValue("@pOpcion", pOpcion);
                    cmd.Parameters.AddWithValue("@pOrden", pOrden);
                    cmd.Parameters.AddWithValue("@pselectedItem", pselectedItem);
                    cmd.Parameters.AddWithValue("@pselectedItemPosi", pselectedItemPosi);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Modificacion Exitosa" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************
        //***************AGREGAR  CAMPOS Integer**************
        [HttpPost]
        [Route("AgregarCamposInteger/{pTipo:int}/{pId:int}/{pdefault_value:int}/{pvalue_list}/{pmin_configuration}/{pmin_value:int}/{pmax_configuration}/{pmax_value:int}/{passumed_value:int}")]
        public IActionResult AgregarCamposInteger(int pTipo, int pId, int pdefault_value, string pvalue_list, string pmin_configuration, int pmin_value, string pmax_configuration, int pmax_value, int passumed_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarCamposInteger", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.Parameters.AddWithValue("@pdefault_value", pdefault_value);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@pmin_configuration", pmin_configuration);
                    cmd.Parameters.AddWithValue("@pmin_value", pmin_value);
                    cmd.Parameters.AddWithValue("@pmax_configuration", pmax_configuration);
                    cmd.Parameters.AddWithValue("@pmax_value", pmax_value);
                    cmd.Parameters.AddWithValue("@passumed_value", passumed_value);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Graboron Exitosamente lod datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
      
          //*****************************************************************************************************
        //***************AGREGAR  CAMPOS Integer**************
        [HttpPost]
        [Route("AgregarArticulos/{pcodigo}/{pnombre}/{pprecio:decimal}/{pnroregistro}/{idtipo :int}/{idsector :int}/{stockminimo :int}/{sockmedio :int}/{stockmaximo :int}/{pusuario :int}/{pinstitucionid :int}")]
        public IActionResult AgregarArticulos(string pcodigo, string pnombre, decimal pprecio, string pnroregistro, int idtipo,int idsector, int stockminimo, int sockmedio, int stockmaximo, int pusuario, int pinstitucionid)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarArticulos", conexion);
                    cmd.Parameters.AddWithValue("@pcodigo", pcodigo);
                    cmd.Parameters.AddWithValue("@pnombre", pnombre);
                    cmd.Parameters.AddWithValue("@pprecio", pprecio);
                    cmd.Parameters.AddWithValue("@pnroregistro", pnroregistro);
                    cmd.Parameters.AddWithValue("@pusuario", pusuario);
                    cmd.Parameters.AddWithValue("@pinstitucionid", pinstitucionid);
                    cmd.Parameters.AddWithValue("@idtipo", idtipo);
                    cmd.Parameters.AddWithValue("@idsector", idsector);
                    cmd.Parameters.AddWithValue("@stockminimo", stockminimo);
                    cmd.Parameters.AddWithValue("@sockmedio", sockmedio);
                    cmd.Parameters.AddWithValue("@stockmaximo", stockmaximo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Graboron Exitosamente lod datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************AGREGAR  CAMPOS Date**************
        [HttpPost]
                               [Route("AgregarCamposDate/{pTipo:int}/{pdate_id:int}/{penable_format}/{puse_date_format}/{pdate_format}/{pvalue_list}/{puse_range}/{pupper_bound}/{pupper_date}/{plower_bound}/{plower_date}/{passume_value}")]
        public IActionResult AgregarCamposDate(int pTipo, int pdate_id, string penable_format, string puse_date_format, string pdate_format, string pvalue_list, string puse_range, string pupper_bound, string pupper_date, string plower_bound, string plower_date, string passume_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarCamposDate", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pdate_id", pdate_id);
                    cmd.Parameters.AddWithValue("@penable_format", penable_format);
                    cmd.Parameters.AddWithValue("@puse_date_format", puse_date_format);
                    cmd.Parameters.AddWithValue("@pdate_format", pdate_format);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@puse_range", puse_range);
                    cmd.Parameters.AddWithValue("@pupper_bound", pupper_bound);
                    cmd.Parameters.AddWithValue("@pupper_date", pupper_date);
                    cmd.Parameters.AddWithValue("@plower_bound", plower_bound);
                    cmd.Parameters.AddWithValue("@plower_date", plower_date);
                    cmd.Parameters.AddWithValue("@passume_value", passume_value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Grabaron Exitosamente lod datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************Modificar  CAMPOS Date**************
        [HttpPut]
        [Route("ModificarCamposDate/{pTipo:int}/{pdate_id:int}/{penable_format}/{puse_date_format}/{pdate_format}/{pvalue_list}/{puse_range}/{pupper_bound}/{pupper_date}/{plower_bound}/{plower_date}/{passume_value}")]
        public IActionResult ModificarCamposDate(int pTipo, int pdate_id, string penable_format, string puse_date_format, string pdate_format, string pvalue_list, string puse_range, string pupper_bound, string pupper_date, string plower_bound, string plower_date, string passume_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificarCamposDate_SP", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pdate_id", pdate_id);
                    cmd.Parameters.AddWithValue("@penable_format", penable_format);
                    cmd.Parameters.AddWithValue("@puse_date_format", puse_date_format);
                    cmd.Parameters.AddWithValue("@pdate_format", pdate_format);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@puse_range", puse_range);
                    cmd.Parameters.AddWithValue("@pupper_bound", pupper_bound);
                    cmd.Parameters.AddWithValue("@pupper_date", pupper_date);
                    cmd.Parameters.AddWithValue("@plower_bound", plower_bound);
                    cmd.Parameters.AddWithValue("@plower_date", plower_date);
                    cmd.Parameters.AddWithValue("@passume_value", passume_value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Grabaron Exitosamente los datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************Modificar  CAMPOS DateTime**************
        [HttpPut]
        [Route("ModificarCamposDateTime/{pTipo:int}/{pdatetime_id:int}/{penable_format}/{puse_date_format}/{pdate_format}/{puse_time_format}/{ptime_format}/{pvalue_list}/{puse_range}/{pupper_bound}/{pupper_date}/{pupper_time}/{plower_bound}/{plower_date}/{plower_time}/{passume_value}")]
        public IActionResult ModificarCamposDateTime(int pTipo, int pdatetime_id, string penable_format, string puse_date_format, string pdate_format,string puse_time_format, string ptime_format, string pvalue_list, string puse_range, string pupper_bound, string pupper_date,string pupper_time, string plower_bound, string plower_date,string plower_time, string passume_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificarCamposDateTime", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pdatetime_id", pdatetime_id);
                    cmd.Parameters.AddWithValue("@penable_format", penable_format);
                    cmd.Parameters.AddWithValue("@puse_date_format", puse_date_format);
                    cmd.Parameters.AddWithValue("@pdate_format", pdate_format);
                    cmd.Parameters.AddWithValue("@puse_time_format", puse_time_format);
                    cmd.Parameters.AddWithValue("@ptime_format", ptime_format);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@puse_range", puse_range);
                    cmd.Parameters.AddWithValue("@pupper_bound", pupper_bound);
                    cmd.Parameters.AddWithValue("@pupper_date", pupper_date);
                    cmd.Parameters.AddWithValue("@pupper_time", pupper_time);
                    cmd.Parameters.AddWithValue("@plower_bound", plower_bound);
                    cmd.Parameters.AddWithValue("@plower_date", plower_date);
                    cmd.Parameters.AddWithValue("@plower_time", plower_time);
                    cmd.Parameters.AddWithValue("@passume_value", passume_value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Grabaron Exitosamente los datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************Modificar  CAMPOS DateTime**************
        [HttpPost]
        [Route("AgregarCamposDateTime/{pTipo:int}/{pdatetime_id:int}/{penable_format}/{puse_date_format}/{pdate_format}/{puse_time_format}/{ptime_format}/{pvalue_list}/{puse_range}/{pupper_bound}/{pupper_date}/{pupper_time}/{plower_bound}/{plower_date}/{plower_time}/{passume_value}")]
        public IActionResult AgregarCamposDateTime(int pTipo, int pdatetime_id, string penable_format, string puse_date_format, string pdate_format, string puse_time_format, string ptime_format, string pvalue_list, string puse_range, string pupper_bound, string pupper_date, string pupper_time, string plower_bound, string plower_date, string plower_time, string passume_value)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarCamposDateTime", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pdatetime_id", pdatetime_id);
                    cmd.Parameters.AddWithValue("@penable_format", penable_format);
                    cmd.Parameters.AddWithValue("@puse_date_format", puse_date_format);
                    cmd.Parameters.AddWithValue("@pdate_format", pdate_format);
                    cmd.Parameters.AddWithValue("@puse_time_format", puse_time_format);
                    cmd.Parameters.AddWithValue("@ptime_format", ptime_format);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@puse_range", puse_range);
                    cmd.Parameters.AddWithValue("@pupper_bound", pupper_bound);
                    cmd.Parameters.AddWithValue("@pupper_date", pupper_date);
                    cmd.Parameters.AddWithValue("@pupper_time", pupper_time);
                    cmd.Parameters.AddWithValue("@plower_bound", plower_bound);
                    cmd.Parameters.AddWithValue("@plower_date", plower_date);
                    cmd.Parameters.AddWithValue("@plower_time", plower_time);
                    cmd.Parameters.AddWithValue("@passume_value", passume_value);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Se Grabaron Exitosamente los datos" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************
        //***************MODIFICA  CAMPOS**************
        [HttpPut]
        [Route("ModificaCampos/{pTipo:int}/{pId:int}/{pdefault_value}/{pvalue_list}/{pmask_library}/{passumed_value}/{plength:int}")]
        public IActionResult ModificaCampos(int pTipo, int pId, string pdefault_value, string pvalue_list, string  pmask_library, string passumed_value, int plength)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ModificaCamposString", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.Parameters.AddWithValue("@pdefault_value", pdefault_value);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@pmask_library", pmask_library);
                    cmd.Parameters.AddWithValue("@passumed_value", passumed_value);
                    cmd.Parameters.AddWithValue("@plength", plength);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Modificacion Exitosa" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************
        //********************************************************
        //***************Agregar  CAMPOS**************
        [HttpPost]
        [Route("AgregarCampos/{pTipo:int}/{pId:int}/{pdefault_value}/{pvalue_list}/{pmask_library}/{passumed_value}/{plength:int}")]
        public IActionResult AgregarCampos(int pTipo, int pId, string pdefault_value, string pvalue_list, string pmask_library, string passumed_value, int plength)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarCamposString", conexion);
                    cmd.Parameters.AddWithValue("@pTipo", pTipo);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    cmd.Parameters.AddWithValue("@pdefault_value", pdefault_value);
                    cmd.Parameters.AddWithValue("@pvalue_list", pvalue_list);
                    cmd.Parameters.AddWithValue("@pmask_library", pmask_library);
                    cmd.Parameters.AddWithValue("@passumed_value", passumed_value);
                    cmd.Parameters.AddWithValue("@plength", plength);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Guardado Exitosa" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }


        //***************LISTAR FORMULARIOS CRUD**************
        [HttpGet]
        [Route("ListaFormulariosCRUD")]
        public IActionResult ListaFormCRUD()
        {
            List<ConfigFormCRUD> lista = new List<ConfigFormCRUD>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ObtenerFormulariosCRUD", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new ConfigFormCRUD()
                            {
                                IdConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
                                Titulo = rd["titulo"].ToString(),
                                Descripcion = rd["descripcion"].ToString()
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //*****************************************************************************************************

        //***************MARCAR FORMULARIO COMO ELIMINADO**************
        [HttpPut]
        [Route("EliminarModulo/{IdConfigForm:int}")]
        public IActionResult EliminarModulo(int IdConfigForm)//Actualizar el campo fecha_eliminacion
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("MarcarFormularioComoEliminado", conexion);
                    cmd.Parameters.AddWithValue("@Id_Formulario", IdConfigForm);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "eliminado" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************

        //***************MOSTRAR FORMULARIO COMPLT**************
        [HttpGet]
        [Route("MostrarFormularioCompleto/{IdConfigForm:int}")]
        public IActionResult MostrarFormularios(int IdConfigForm)//Mostrar formulario completo segun su id
        {
            ConfigFormCRUD formulariodata = new ConfigFormCRUD();
            List<Field> campodata = new List<Field>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ObtenerFormularioYCampos", conexion);
                    cmd.Parameters.AddWithValue("@Id_Formulario", IdConfigForm);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            formulariodata.IdConfigForm = reader.GetInt32(reader.GetOrdinal("Id_ConfigForm"));
                            formulariodata.Titulo = reader.GetString(reader.GetOrdinal("TituloFormulario"));
                            formulariodata.Descripcion = reader.GetString(reader.GetOrdinal("DescripcionFormulario"));
                            //formulariodata.FechaCreacionFormulario = reader.GetDateTime(reader.GetOrdinal("FechaCreacionFormulario"));
                            //formulariodata.FechaModificacionFormulario = reader.GetDateTime(reader.GetOrdinal("FechaModificacionFormulario"));

                        }
                        reader.NextResult();//ir al siguiente resultado (field)
                        while (reader.Read())
                        {
                            Field campo = new Field();
                            campo.Id_Field = reader.GetInt32(reader.GetOrdinal("Id_Field"));
                            campo.nombre = reader.GetString(reader.GetOrdinal("NombreCampo"));
                            campo.orden = reader.GetInt32(reader.GetOrdinal("OrdenCampo"));
                            campo.etiqueta = reader.GetString(reader.GetOrdinal("EtiquetaCampo"));
                            campo.tipo = reader.GetString(reader.GetOrdinal("TipoCampo"));
                            campo.requerido = reader.GetInt32(reader.GetOrdinal("RequeridoCampo"));
                            campo.marcador = reader.GetString(reader.GetOrdinal("MarcadorCampo"));
                            campo.opciones = reader.GetString(reader.GetOrdinal("OpcionesCampo"));
                            campo.visible = reader.GetInt32(reader.GetOrdinal("VisibleCampo"));
                            campo.clase = reader.GetString(reader.GetOrdinal("ClaseCampo"));
                            campo.estado = reader.GetInt32(reader.GetOrdinal("EstadoCampo"));
                            campo.posi = reader.GetString(reader.GetOrdinal("posi"));
                            campo.urlapi = reader.GetString(reader.GetOrdinal("urlapi"));

                            campodata.Add(campo);
                        }

                    }


                }
                //formulariodata.Campos = campodata;
                //return formulariodata;
                return StatusCode(StatusCodes.Status200OK, new { datosForm = formulariodata, datosField = campodata });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //*****************************************************************************************************

        //***************GUARDAR FORMULARIO COMPLT**************

        [HttpPost]
        [Route("GuardarFormularioCreado")]
        public IActionResult GuardarFormularioCampos(ConfigForm Field)
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        var insertConfigFormSql = "INSERT INTO ConfigForm (Titulo, Descripcion, Fecha_Creacion) VALUES (@Titulo, @Descripcion, @Fecha_Creacion); SELECT SCOPE_IDENTITY();";
                        int configFormId = conexion.QuerySingle<int>(insertConfigFormSql, new
                        {
                            Titulo = Field.Titulo,
                            Descripcion = Field.Descripcion,
                            Fecha_Creacion = DateTime.Now
                        }, transaction);

                        foreach (var fieldInput in Field.Campos)
                        {
                            var insertFieldSql = "INSERT INTO Field (nombre, orden, etiqueta, tipo, requerido, marcador, opciones, visible, clase, estado, Id_ConfigForm, fecha_eliminacion) VALUES (@nombre, @orden, @etiqueta, @tipo, @requerido, @marcador, @opciones, @visible, @clase, @estado, @Id_ConfigForm, @fecha_eliminacion);";
                            conexion.Execute(insertFieldSql, new
                            {
                                nombre = fieldInput.nombre,
                                orden = fieldInput.orden,
                                etiqueta = fieldInput.etiqueta,
                                tipo = fieldInput.tipo,
                                requerido = fieldInput.requerido,
                                marcador = fieldInput.marcador,
                                opciones = fieldInput.opciones,
                                visible = fieldInput.visible,
                                clase = fieldInput.clase,
                                estado = fieldInput.estado,
                                Id_ConfigForm = configFormId,
                                fecha_eliminacion = fieldInput.fecha_eliminacion
                            }, transaction);
                        }

                        transaction.Commit();

                        // Devuelve el ID generado como respuesta HTTP 200 (éxito)
                        return Ok(new { Id = configFormId });
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        //***************AgregarContenido**************

        [HttpPost]
        [Route("AgregarContenido/{pIdConfigForm:int}/{pidentificador_fila:int}")]
        public IActionResult AgregarContenido(int pIdConfigForm, int pidentificador_fila)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AgregarCContenido", conexion);
                    cmd.Parameters.AddWithValue("@pIdConfigForm", pIdConfigForm);
                    cmd.Parameters.AddWithValue("@pidentificador_fila", pidentificador_fila);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();


                }
                return StatusCode(StatusCodes.Status200OK, new { message = "Guardado Exitosa" });
            }
            catch (Exception erx)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = erx.Message });
            }
        }
        //***************GUARDAR FORMULARIO COMPLT**************

        [HttpPost]
        [Route("AgregarFormularioCreado")]
        public IActionResult AgregarFormularioCreado(ConfigForm Field)
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {

                        int configFormId = Field.IdConfigForm;
                 

                        foreach (var fieldInput in Field.Campos)
                        {
                            var insertFieldSql = "INSERT INTO Field (nombre, orden, etiqueta, tipo, requerido, marcador, opciones, visible, clase, estado, Id_ConfigForm, fecha_eliminacion) VALUES (@nombre, @orden, @etiqueta, @tipo, @requerido, @marcador, @opciones, @visible, @clase, @estado, @Id_ConfigForm, @fecha_eliminacion);";
                            conexion.Execute(insertFieldSql, new
                            {
                               // configFormId = fieldInput.Id_ConfigForm,
                                nombre = fieldInput.nombre,
                                orden = fieldInput.orden,
                                etiqueta = fieldInput.etiqueta,
                                tipo = fieldInput.tipo,
                                requerido = fieldInput.requerido,
                                marcador = fieldInput.marcador,
                                opciones = fieldInput.opciones,
                                visible = fieldInput.visible,
                                clase = fieldInput.clase,
                                estado = fieldInput.estado,
                                Id_ConfigForm = fieldInput.Id_ConfigForm,
                                fecha_eliminacion = fieldInput.fecha_eliminacion
                            }, transaction); ;
                        }

                        transaction.Commit();

                        // Devuelve el ID generado como respuesta HTTP 200 (éxito)
                        return Ok(new { Id = 1 });
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        //***************LISTAR RESPUESTAS**************
        [HttpGet]
		[Route("ListaRespuestas/{IdConfigForm:int}")]
		public IActionResult ListaRespuesta(int IdConfigForm)
		{
			List<RespuestasLista> lista = new List<RespuestasLista>();
			try
			{
				using (var conexion = new SqlConnection(cadenaSQL))
				{
					conexion.Open();
					var cmd = new SqlCommand("ListarRespuestas", conexion);
					cmd.Parameters.AddWithValue("@FormularioID", IdConfigForm);
					cmd.CommandType = CommandType.StoredProcedure;

					using (var rd = cmd.ExecuteReader())
					{
						while (rd.Read())
						{
							lista.Add(new RespuestasLista()
							{
                                Id_ConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
                                Id_Field = Convert.ToInt32(rd["Id_Field"]),
                                Id_Answer = Convert.ToInt32(rd["Id_Answer"]),
                                nombre = rd["nombre"].ToString(),
                                //titulo = rd["titulo"].ToString(),
                                valor = rd["valor"].ToString(),
                                identificador_fila = Convert.ToInt32(rd["identificador_fila"])
                                
                            });
						}
					}
				}
				return StatusCode(StatusCodes.Status200OK, new { lista });
			}
			catch (Exception error)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
			}
		}
        //*****************************************************************************************************

        //***************GUARDAR RESPUESTA***************************************


        [HttpPost]
        [Route("Respuestas")]

        public async Task<IActionResult> GuardarRespuesta([FromBody] AnswerModel Answer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaSQL))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO Answer (Id_ConfigForm, Id_Field, valor, fecha_creacion, fecha_modificacion) VALUES (@Id_ConfigForm, @Id_Field, @valor, @fecha_creacion, @fecha_modificacion)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_ConfigForm", Answer.Id_ConfigForm);
                        command.Parameters.AddWithValue("@Id_Field", Answer.Id_Field);
                        command.Parameters.AddWithValue("@valor", Answer.valor);
                        command.Parameters.AddWithValue("@fecha_creacion", DateTime.Now);
                        command.Parameters.AddWithValue("@fecha_modificacion", DateTime.Now);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok("Respuesta del formulario guardada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar la respuesta: {ex.Message}");
            }
        }
		//***************EDITAR RESPUESTA***************************************
		[HttpPost]
		[Route("Respuestas/Editar")]
		public IActionResult ActualizarDatos([FromBody] List<AnswerModel> actualizaciones)
		{
			try
			{
				// Obtén la cadena de conexión a la base de datos desde la configuración
				using (var conexion = new SqlConnection(cadenaSQL))
				{
					conexion.Open();

					// Crea una tabla de valores para los datos de actualización
					DataTable actualizacionesTable = new DataTable();
					actualizacionesTable.Columns.Add("Id_Answer", typeof(int));
					actualizacionesTable.Columns.Add("valor", typeof(string));

					foreach (var actualizacion in actualizaciones)
					{
						actualizacionesTable.Rows.Add(actualizacion.Id_Answer, actualizacion.valor);
					}

					using (SqlCommand cmd = new SqlCommand("EditarRegistrosAnswer", conexion))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						// Asigna el parámetro del procedimiento almacenado
						SqlParameter parameter = cmd.Parameters.AddWithValue("@Actualizaciones", actualizacionesTable);
						parameter.SqlDbType = SqlDbType.Structured;

						cmd.ExecuteNonQuery();
					}
				}

				return Ok("Registros actualizados exitosamente");
			}
			catch (Exception ex)
			{
				return BadRequest($"Error: {ex.Message}");
			}
		}
		//*************************************************************
		//***************GUARDAR RESPUESTA***************************************
		[HttpPost]
		[Route("Respuestas/Guardar")]
		public ActionResult<int> GuardarRespuesta([FromBody] List<NuevaRespuestasGuardar> registros)
		{
			try
			{
				using (var conexion = new SqlConnection(cadenaSQL))
				{
					conexion.Open();

					// Obtener el próximo identificador_fila una vez
					int proximoIdentificador = ObtenerProximoIdentificador(conexion);

					foreach (var registro in registros)
					{
						// Construye la consulta SQL para insertar un registro en la tabla Answer
						string query = "INSERT INTO Answer (Id_ConfigForm, Id_Field, valor, fecha_creacion, identificador_fila) " +
									   "VALUES (@Id_ConfigForm, @Id_Field, @valor, GETDATE(), @IdentificadorFila);";

						using (SqlCommand cmd = new SqlCommand(query, conexion))
						{
							cmd.Parameters.AddWithValue("@Id_ConfigForm", registro.Id_ConfigForm);
							cmd.Parameters.AddWithValue("@Id_Field", registro.Id_Field);
							cmd.Parameters.AddWithValue("@valor", registro.valor);

							// Utiliza el mismo valor de identificador_fila para todos los registros
							cmd.Parameters.AddWithValue("@IdentificadorFila", proximoIdentificador);

							cmd.ExecuteNonQuery();
						}
					}

					return Ok(registros.Count);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private int ObtenerProximoIdentificador(SqlConnection conexion)
		{
			// Obtener el próximo identificador_fila
			string query = "SELECT ISNULL(MAX(identificador_fila), 0) + 1 FROM Answer;";

			using (SqlCommand cmd = new SqlCommand(query, conexion))
			{
				object resultado = cmd.ExecuteScalar();
				return resultado is DBNull ? 1 : (int)resultado;
			}
		}
        //----------------------------
        //-------Listar Datos ----
        //----------------------------
        [HttpGet]
        [Route("ListarDatos/{IdConfigForm:int}/{dato}")]

        public IActionResult ListarDatos(int IdConfigForm, string dato)
        {
            List<RespuestasLista> lista = new List<RespuestasLista>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("ListarDatos", conexion);
                    cmd.Parameters.AddWithValue("@FormularioID", IdConfigForm);
                    cmd.Parameters.AddWithValue("@dato", dato);

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new RespuestasLista()
                            {
                                Id_ConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
                                Id_Field = Convert.ToInt32(rd["Id_Field"]),
                                Id_Answer = Convert.ToInt32(rd["Id_Answer"]),
                                nombre = rd["nombre"].ToString(),
                                valor = rd["valor"].ToString(),
                                identificador_fila = Convert.ToInt32(rd["identificador_fila"])
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        //----------------------------
        //----------------------------
        //----------------------------

        //--------------------------
        //-------BUSCAR

        [HttpGet]
        [Route("Buscar/{IdConfigForm:int}/{dato}")]

        public IActionResult Buscar(int IdConfigForm, string dato)
        {
            List<RespuestasLista> lista = new List<RespuestasLista>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Buscar", conexion);
                    cmd.Parameters.AddWithValue("@FormularioID", IdConfigForm);
                    cmd.Parameters.AddWithValue("@dato", dato);

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new RespuestasLista()
                            {
                                Id_ConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
                                Id_Field = Convert.ToInt32(rd["Id_Field"]),
                                Id_Answer = Convert.ToInt32(rd["Id_Answer"]),
                                nombre = rd["nombre"].ToString(),
                                valor = rd["valor"].ToString(),
                                identificador_fila = Convert.ToInt32(rd["identificador_fila"])
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }
        //------------------------------------------	
        //******************************************************************
        //****LISTAR RESPUESTAS X IDENTIFICADOR DE FILA
        [HttpGet]
		[Route("ListaRespuestasIdentificadorFila/{IdConfigForm:int}/{identificador_fila:int}")]

		public IActionResult ListaRespuestaIdentificadorFila(int IdConfigForm, int identificador_fila)
		{
			List<RespuestasLista> lista = new List<RespuestasLista>();
			try
			{
				using (var conexion = new SqlConnection(cadenaSQL))
				{
					conexion.Open();
					var cmd = new SqlCommand("ListarRespuestasPorIdentificadorFila", conexion);
					cmd.Parameters.AddWithValue("@FormularioID", IdConfigForm);
					cmd.Parameters.AddWithValue("@IdentificadorFila", identificador_fila);

					cmd.CommandType = CommandType.StoredProcedure;
					using (var rd = cmd.ExecuteReader())
					{
						while (rd.Read())
						{
							lista.Add(new RespuestasLista()
							{
								Id_ConfigForm = Convert.ToInt32(rd["Id_ConfigForm"]),
								Id_Field = Convert.ToInt32(rd["Id_Field"]),
								Id_Answer = Convert.ToInt32(rd["Id_Answer"]),
								nombre = rd["nombre"].ToString(),
								valor = rd["valor"].ToString(),
								identificador_fila = Convert.ToInt32(rd["identificador_fila"])
							});
						}
					}
				}
				return StatusCode(StatusCodes.Status200OK, new { lista });
			}
			catch (Exception error)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
			}
		}
		//***************ELIMINAR RESPUESTA***************************************
		[HttpPut]
        [Route("Respuestas/Eliminar/{id_fila}")]
        public async Task<IActionResult> EliminarRespuesta(int id_fila, AnswerErase Answer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaSQL))
                {
                    await connection.OpenAsync();

                    string query = "UPDATE Answer SET fecha_eliminacion = @fecha_eliminacion WHERE identificador_fila = @id_fila";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_fila", id_fila);
                        command.Parameters.AddWithValue("@fecha_eliminacion", DateTime.Now);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok("Respuesta del formulario eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al editar la respuesta: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditarFormulario")]
        public IActionResult EditarFormulario(int id, ConfigForm Field)
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // Verifica si el formulario con el ID proporcionado existe
                        var existingForm = conexion.QuerySingleOrDefault<ConfigForm>("SELECT * FROM ConfigForm WHERE Id_ConfigForm = @Id", new { Id = id }, transaction);

                        if (existingForm == null)
                        {
                            // El formulario no existe, devolver un error
                            return NotFound("Formulario no encontrado");
                        }

                        // Actualiza los datos del formulario
                        DateTime fechaModificacion = DateTime.Now;
                        var updateConfigFormSql = "UPDATE ConfigForm SET Titulo = @Titulo, Descripcion = @Descripcion, fecha_modificacion = @fecha_modificacion WHERE Id_ConfigForm = @Id";
                        conexion.Execute(updateConfigFormSql, new
                        {
                            Id = id,
                            Titulo = Field.Titulo,
                            Descripcion = Field.Descripcion,
                            fecha_modificacion = fechaModificacion
                        }, transaction);

                       

                        // Inserta los nuevos campos
                        foreach (var fieldInput in Field.Campos)
                        {
                            var insertFieldSql = "INSERT INTO Field (nombre, orden, etiqueta, tipo, requerido, marcador, opciones, visible, clase, estado, Id_ConfigForm, fecha_eliminacion) " +
                                "VALUES (@nombre, @orden, @etiqueta, @tipo, @requerido, @marcador, @opciones, @visible, @clase, @estado, @Id_ConfigForm, @fecha_eliminacion);";
                            conexion.Execute(insertFieldSql, new
                            {
                                nombre = fieldInput.nombre,
                                orden = fieldInput.orden,
                                etiqueta = fieldInput.etiqueta,
                                tipo = fieldInput.tipo,
                                requerido = fieldInput.requerido,
                                marcador = fieldInput.marcador,
                                opciones = fieldInput.opciones,
                                visible = fieldInput.visible,
                                clase = fieldInput.clase,
                                estado = fieldInput.estado,
                                Id_ConfigForm = id,
                                fecha_eliminacion = fieldInput.fecha_eliminacion
                            }, transaction);
                        }

                        transaction.Commit();

                        // Devuelve el ID del formulario actualizado como respuesta HTTP 200 (éxito)
                        return Ok(new { Id = id , Estado = "Cargado correctamente"});
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }



    }
}





