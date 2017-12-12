angular.module('auth').factory('preferenciasService', function($http, authConfig){
    
      let urlPreferencia = authConfig.urlPreferencia;
    
      function listar(){
        let result =  $http.get(urlPreferencia + "listar");
        return result;
      }

      // function listarCinco(){
      //   let result =  $http.get(urlPreferencia + "listarCinco");
      //   return result;
      // }
    
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
      }
    })
    