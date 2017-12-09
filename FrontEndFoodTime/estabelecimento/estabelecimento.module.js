angular.module('auth').factory('estabService', function (authConfig, $http, $q, $location, $localStorage, $rootScope) {

  let urlAvaliiacaoRegistro = authConfig.urlAvaliiacaoRegistro;
  let urlEstabelecimento = authConfig.urlEstabelecimento;


  function criarAvaliacao(avaliacao){
    return $http.post(urlAvaliiacaoRegistro, avaliacao)
  }

  function buscarAvaliacaoPorId(id){
    return $http.get(urlEstabelecimento + id)
  }

  return{
    criarAvaliacao: criarAvaliacao,
    buscarAvaliacaoPorId: buscarAvaliacaoPorId
  }
})
