using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string UserGuid { get; set; }
        //public string? Username { get; set; }
        public string? RequestNumber { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Open;
        public RequestType RequestType { get; set; }
    }

    public enum RequestType
    {
        [Display(Name = "Incidente Crítico")]
        Incident,

        [Display(Name = "Solicitud de Servicio")]
        Service,

        [Display(Name = "Solicitud de Cambio")]
        Change,

        [Display(Name = "Solicitud de Acceso")]
        Access,

        [Display(Name = "Problema Técnico")]
        Technical,

        [Display(Name = "Problema de Cuenta")]
        Account,

        [Display(Name = "Fallo de Hardware")]
        HardwareFailure,

        [Display(Name = "Problema de Software")]
        Software,

        [Display(Name = "Problema de Red")]
        Network,

        [Display(Name = "Incidente de Seguridad")]
        Security,

        [Display(Name = "Solicitud de Información")]
        Information,

        [Display(Name = "Solicitud de Mejora")]
        Enhancement,

        [Display(Name = "Solicitud de Capacitación")]
        Training,

        [Display(Name = "Otro")]
        Other
    }

    public enum Status
    {
        [Display(Name = "Abierto")]
        Open,              
        [Display(Name = "En Espera")]
        OnHold,            
        [Display(Name = "En Proceso")]
        InProgress,        
        [Display(Name = "Cerrado")]
        Closed,            
        [Display(Name = "Cerrado sin Resolver")]
        CloseUnresolved    
    }
}
