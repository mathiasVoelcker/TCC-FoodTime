angular.module('auth').factory('preferenciasService', function($http, authConfig){
    
      let urlPreferencia = authConfig.urlPreferencia;
    
      function listar(){
        let result =  $http.get(urlPreferencia + "listar");
        return result;
      }

      function listarPreferenciasMenosAsDoUsuario(idUsuario){
        let result =  $http.get(urlPreferencia + "listarPreferenciasMenosAsDoUsuario?idUsuario=" + idUsuario);
        return result;
      }
      function buscarPreferencia(id){
        return $http.get(urlPreferencia + id);
      }
    
      function addPreferencia(categoria){
        return $http.post(urlPreferencia + "registro", categoria);
      }
          
    
      return {
        listar: listar,
        buscarPreferencia: buscarPreferencia,
        addPreferencia: addPreferencia,
        listarPreferenciasMenosAsDoUsuario: listarPreferenciasMenosAsDoUsuario
      }
    })
    