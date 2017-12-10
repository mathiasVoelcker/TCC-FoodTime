angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliiacaoRegistro = authConfig.urlAvaliiacaoRegistro;
  let urlEstabelecimento = authConfig.urlEstabelecimento;

  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliiacaoRegistro, avaliacao)
  }

  function listar(){
    let result =  $http.get(urlEstabelecimento+"listar");
    return result;
  }

  function buscarPorFiltro(filtro){
    debugger
    let result =  $http.get(urlEstabelecimento+"buscarPorFiltro", filtro);
    return result;
  }

  return{
    criarAvaliacao: criarAvaliacao,
    listar: listar
  } 
  

})
