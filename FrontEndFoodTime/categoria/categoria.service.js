angular.module('auth').factory('categoriaService', function($http, authConfig){
    
      let urlCategoria = authConfig.urlCategoria;
    
      function listar(){
        let result =  $http.get(urlCategoria + "listar");
        return result;
      }
    
      function buscarCategoria(id){
        return $http.get(urlCategoria + id);
      }
    
      function addCategoria(categoria){
        return $http.post(urlCategoria + "novaCategoria", categoria);
      }
    
      function removeCategoria(id){
        return $http.delete(urlCategoria + id);
      }
      
    
      return {
        listar: listar,
        buscarCategoria: buscarCategoria,
        addCategoria: addCategoria,
        removeCategoria: removeCategoria,
      }
    })
    