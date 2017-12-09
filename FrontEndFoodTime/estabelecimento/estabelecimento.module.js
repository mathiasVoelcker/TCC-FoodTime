angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliiacaoRegistro = authConfig.urlAvaliiacaoRegistro;
  let urlEstabelecimento = authConfig.urlEstabelecimento;

  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliiacaoRegistro, avaliacao)
  }

  function listar(){
    debugger
    let result =  $http.get(urlEstabelecimento+"listar");
    return result;
  }

  return{
    criarAvaliacao: criarAvaliacao,
    listar: listar
  } 
  

})
