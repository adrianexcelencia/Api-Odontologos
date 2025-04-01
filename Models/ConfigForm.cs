using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace APIformbuilder.Models
{
    public class ConfigForm
    {
        public int IdConfigForm { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime? Fecha_Creacion { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public DateTime? Fecha_Modificacion { get; set; }                       

        [Display(Name = "Fecha de Eliminación")]
        public DateTime? Fecha_Eliminacion { get; set; }

        //Propiedad lista apara almacenar campos
        public List<Field> Campos { get; set; }
    }
}


    //Clase ConfigFormListaMenu proyeccion
    public class ConfigFormMenu
    {
        public int IdConfigForm { get; set; }
        public string Titulo { get; set; }
    }



    //Clase ConfigFormListaCRUD proyeccion
    public class ConfigFormCRUD
    {
        public int IdConfigForm { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
//Listar Medicamentos Clinicas
public class Listarmedicamentosclinicas
{
    public int Id_ConfigForm { get; set; }
    public int Id_Field { get; set; }
    public int Id_Answer { get; set; }
    public string nombre { get; set; }
    public string valor { get; set; }
      
    public int identificador_fila { get; set; }
  

    //public string IdArticulo { get; set; }
    //public string Nombre { get; set; }
    //public string Codigo { get; set; }
    //public string Tipo_Articulo { get; set; }
    //public string Precio_Venta { get; set; }
    //public string Precio_Costo { get; set; }
    //public string Modifica_Manual { get; set; }
    //public string Stock_Maximo { get; set; }
    //public string Stock_Medio { get; set; }
    //public string Stock_Minimo { get; set; }
    //public string Troquel { get; set; }
    //public string Barra { get; set; }
    //public string Descartable_art { get; set; }
    //public string Urgencia { get; set; }
    //public string Gastosnn { get; set; }
    //public string SinCargo { get; set; }
    //public string Afacturar { get; set; }
    //public string SinCargoIn { get; set; }
    //public string AfacturarIn { get; set; }
    //public string Anulado { get; set; }
    //public string IdInstitucion { get; set; }

}
//clase de Campos String
public class ListaCamposString
{
    public int string_id { get; set; }
    public string default_value { get; set; }
    
    public string value_list { get; set; }
    public string mask_library { get; set; }
    public string assumed_value { get; set; }
 
    public int length { get; set; }
}
//clase de Campos AlfaBeta
public class ListaAlfaBeta
{
    public string troquel { get; set; }
    public string CodBarras { get; set; }

    public string NroRegistro { get; set; }
    public string nombre { get; set; }
    public string presentacion { get; set; }

    public string Unidades { get; set; }
    public string IdMonodroga { get; set; }
    public string CodLab { get; set; }
    public string Laboratorio { get; set; }
    public string Monodroga { get; set; }
    public string precio { get; set; }
}
//clase de Campos Integer
public class ListaCamposInteger
{
    public int integer_id { get; set; }
    public int default_value { get; set; }

    public string value_list { get; set; }
    public string min_configuration { get; set; }
    public int min_value { get; set; }

    public string max_configuration { get; set; }
    public int  max_value { get; set; }
    public int assumed_value { get; set; }
}
//clase de Campos Integer
public class ListaCamposDouble
{
    public int double_id { get; set; }
    public int default_value { get; set; }

    public string value_list { get; set; }
    public string min_configuration { get; set; }
    public int min_value { get; set; }

    public string max_configuration { get; set; }
    public int max_value { get; set; }
    public int assumed_value { get; set; }
}
//clase de Campos Bollean
public class ListaCamposBoolean
{
    public int boolean_id { get; set; }
    public int  true_value { get; set; }

    public int false_value { get; set; }
    public string assumed_value { get; set; }
    
}
//clase de Campos Label
public class ListaCamposLabel
{
    public int label_id { get; set; }
    public string text_value { get; set; }

    public string default_value { get; set; }
    public string assumed_value { get; set; }

}
//clase de Campos Label
public class ListaGrillas
{
    public int idConfigForm { get; set; }
    public string metodo { get; set; }
    public string urlmodi { get; set; }


}
//clase de Campos Label
public class ListaBotones
{
    public int idConfigForm { get; set; }
    public string metodo { get; set; }
    public string texto { get; set; }
    public string color { get; set; }
    public string icono { get; set; }


}
//clase de Campos Text
public class ListaCamposText
{
    public int text_id { get; set; }
    public string text_value { get; set; }

    public string default_value { get; set; }
    public string value_list { get; set; }
    public string assumed_value { get; set; }

    public int editable { get; set; }
}
//clase de Campos Textpublic class Field
public class ListaField
{
    public int Id_Field { get; set; }
    public string nombre { get; set; }
    public string opciones { get; set; }
    public string posi { get; set; }
    public string ver { get; set; }
    public string urlapi { get; set; }
    public string orden { get; set; }

}
//ListarCombo
public class ListarCombo
{
    public int codigo { get; set; }
    public string nombre { get; set; }
    public string campo { get; set; }

}
public class ListarTipos
{
    public int identificador { get; set; }
    public string nombre { get; set; }
   

}
//ListarCombo
public class ListarArticulos
{
    public int articulosid { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public decimal precio { get; set; }
    public string nroregistro { get; set; }
   }
public class ListarConsumo
{
    public int consumoid { get; set; }

    public string fecha { get; set; }
    public string NInternado { get; set; }
    public string codigoarticulo { get; set; }
    public string nomarticulo { get; set; }
     
    public string dosis { get; set; }
    public string detalleInternado { get; set; }
    public string  cantidad { get; set; }

    public string precio { get; set; }
    public string receta { get; set; }


}

public class ListarArticulosTodos
{
    public int articulosid { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public decimal precio { get; set; }
    public string nroregistro { get; set; }
    public string tipomedicamentos { get; set; }
    public string sector { get; set; }
    public string stockminimo { get; set; }
    public string stockmedio { get; set; }
    public string stockmaximo { get; set; }
    public string troquel { get; set; }
    public string codbarra { get; set; }



}
//clase de Campos Date
public class ListaCamposDate
{
    public int date_id { get; set; }
    public int enable_format { get; set; }
    public int use_date_format { get; set; }
    
    public string date_format { get; set; }

    public string value_list { get; set; }

    public int use_range { get; set; }
    public int upper_bound { get; set; }
    public DateTime upper_date { get; set; }
    public int lower_bound { get; set; }

    public DateTime lower_date { get; set; }
    public DateTime assume_value { get; set; }

   }
//clase de Campos Date
public class ListaCamposTime
{
    public int time_id { get; set; }
    public int enable_format { get; set;}
    public int use_time_format { get; set; }
    public string time_format { get; set; }
    public string value_list { get; set; }
    public int use_range { get; set; }
    public int upper_bound { get; set; }
    public string upper_time { get; set; }
    public int lower_bound { get; set; }
    public string lower_time { get; set; }
    public string assume_value { get; set; }

}

//clase de Campos Date
public class ListaCamposDateTime
{
    public int datetime_id { get; set; }
    public int enable_format { get; set; }
    public int use_date_format { get; set; }
    public string date_format { get; set; }
    public int use_time_format { get; set; }
    public string  time_format { get; set; }
    public DateTime value_list { get; set; }
    public int use_range { get; set; }
    public int upper_bound { get; set; }
    public DateTime upper_date { get; set; }
    public string upper_time { get; set; }
    public int lower_bound { get; set; }
    public DateTime lower_date { get; set; }
    public string lower_time { get; set; }
    public string assume_value { get; set; }

}

//Clase MostrarFormularios proyeccion
// public class MostrarFormularios 
//{
//  public int IdConfigForm { get; set; }
//  public string Titulo { get; set; }
//  public string Descripcion { get; set; }
//  }


