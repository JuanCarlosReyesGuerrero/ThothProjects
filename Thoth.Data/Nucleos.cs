//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thoth.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nucleos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nucleos()
        {
            this.Instituciones = new HashSet<Instituciones>();
        }
    
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public long DepartamentoId { get; set; }
        public long MunicipioId { get; set; }
        public string NombreDirector { get; set; }
        public string TelefonoDirector { get; set; }
        public bool Activo { get; set; }
        public Nullable<long> UsuarioRegistra { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<long> UsuarioModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Instituciones> Instituciones { get; set; }
        public virtual Municipios Municipios { get; set; }
    }
}
