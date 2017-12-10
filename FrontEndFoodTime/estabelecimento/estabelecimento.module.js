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

  function listarCinco(){
    let result =  $http.get(urlEstabelecimento+"listarCinco");
    return result;
  }
 

  function buscarPorFiltro(filtro){
    debugger
    let result =  $http.get(urlEstabelecimento+"buscarPorFiltro", filtro);
    return result;
  }

  function buscarEstabelecimentoPorId(id){
    return $http.get(urlEstabelecimento + id)
  }

  return{
    criarAvaliacao: criarAvaliacao,
    listar: listar,
    listarCinco: listarCinco,
    buscarPorFiltro: buscarPorFiltro,
    buscarEstabelecimentoPorId: buscarEstabelecimentoPorId 
  }


})
