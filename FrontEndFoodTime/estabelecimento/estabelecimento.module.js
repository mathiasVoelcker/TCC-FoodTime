angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliacao = authConfig.urlAvaliacao;
  let urlAvaliacaoRegistro = authConfig.urlAvaliacaoRegistro;
  let urlEstabelecimento = authConfig.urlEstabelecimento;

  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliacaoRegistro, avaliacao)
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
    debugger
    return result;
  }

  function buscarEstabelecimentoPorId(id){
    return $http.get(urlEstabelecimento + id)
  }

  function buscarAvaliacoesEstab(id){
    return $http.get(urlAvaliacao + "buscarPorIdEstabelecimento?idEstab=" + id)
  }

  return{
    criarAvaliacao: criarAvaliacao,
    listar: listar,
    listarCinco: listarCinco,
    buscarPorFiltro: buscarPorFiltro,
    buscarEstabelecimentoPorId: buscarEstabelecimentoPorId,
    buscarAvaliacoesEstab: buscarAvaliacoesEstab
  }


})
