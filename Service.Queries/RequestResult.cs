using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Queries
{
    //
    // Resumen:
    //     Encapsula el resultado de la petición
    //
    // Parámetros de tipo:
    //   T:
    //     Tipo del resultado
    public sealed class RequestResult<T>
    {
//
        // Resumen:
        //     Obtiene un valor que indica si el resultado de la petición fue satisfactorio
        public bool IsSuccessful { get; set; }
        //
        // Resumen:
        //     Obtiene un valor que indica si ocurrió algún error al ejecutar la petición
        public bool IsError { get; set; }
        //
        // Resumen:
        //     Obtiene el mensaje del error ocurrido
        public string ErrorMessage { get; set; }
        //
        // Resumen:
        //     Obtiene la enumeración de mensajes de las validaciones que no permitieron que
        //     el resultado fuera satisfactorio
        public IEnumerable<string> Messages { get; set; }
        //
        // Resumen:
        //     Obtiene el objeto resultado de la petición
        public T Result { get; set; }
       
    }
}
