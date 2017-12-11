angular.module('auth').factory('fotoService', function($http, authConfig){
    
      let urlFoto = authConfig.urlFoto;
    
      function listar(){
        let result =  $http.get(urlFoto + "listar");
        return result;
      }
    
      function buscarFoto(id){
        return $http.get(urlFoto + id);
      }
    
      function addFoto(formData){
        var request = {
            method: 'POST',
            url: 'http://localhost:65510/api/foto/novafoto',
            data: formData,
            headers : {
              'Content-Type' : undefined
             }
        }
        debugger;
        return $http(request);
      }
    
      function removeFoto(id){
        return $http.delete(urlFoto + id);
      }
      
    
      return {
        listar: listar,
        buscarFoto: buscarFoto,
        addFoto: addFoto,
        removeFoto: removeFoto,
      }
    })
    